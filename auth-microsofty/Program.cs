using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

const string AUTH_SCHEME = "my-cookie-auth";
const string POLICY = "saarc-passport";
const string SAARC_CLAIM = "saarcpp";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(AUTH_SCHEME)
                .AddCookie(AUTH_SCHEME, opt =>
                {
                    opt.LoginPath = "/unauthenticated";
                    opt.AccessDeniedPath = "/forbidden";
                });

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy(POLICY, pol =>
    {
        pol.RequireAuthenticatedUser()
           .AddAuthenticationSchemes(AUTH_SCHEME)
           .RequireClaim(SAARC_CLAIM, "saarc passport");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapGet("/username", (HttpContext context) =>
{
    return context.User.FindFirst("usr")?.Value;
});

app.MapGet("/login", async (HttpContext context, [FromQuery] string username, [FromQuery] bool? hasPassport) =>
{
    var claims = new List<Claim> { new Claim("usr", username) };
    if (hasPassport.HasValue && hasPassport.Value) claims.Add(new Claim(SAARC_CLAIM, "saarc passport"));

    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, AUTH_SCHEME));
    
    await context.SignInAsync(AUTH_SCHEME, claimsPrincipal);
    return "ok";
});

app.MapGet("/malaysia", () =>
{
    return "allowed";
}).RequireAuthorization(POLICY);

app.MapGet("/forbidden", (context) =>
{
    context.Response.StatusCode = 403;
    return Task.CompletedTask;
});

app.Map("/unauthenticated", () =>
{
    return "You are not authenticated, please login.";
});

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync();
    return "signed out";
});

app.Run();
