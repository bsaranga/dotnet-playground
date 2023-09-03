using auth_reinventing;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddDataProtection();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Use((context, next) =>
{
    var idp = context.RequestServices.GetRequiredService<IDataProtectionProvider>();

    var protector = idp.CreateProtector("auth-cookie");
    var authCookie = context.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));
    var payload = protector.Unprotect(authCookie?.Split("=").Last()!);
    var parts = payload?.Split(":");
    var key = parts?[0];
    var value = parts?[1];

    var claims = new List<Claim>
    {
        new Claim(key ?? "undefined-key", value ?? "undefined-value")
    };

    context.User = new ClaimsPrincipal(new ClaimsIdentity(claims));

    return next();
});

app.MapGet("/username", (HttpContext context) =>
{
    return context.User.FindFirst("usr")?.Value;
});

app.MapGet("/login", (AuthService authService, [FromQuery] string username) =>
{
    authService.SignIn(username);
    return "ok";
});

app.Run();
