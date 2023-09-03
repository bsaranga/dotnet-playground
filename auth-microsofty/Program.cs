using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

const string AUTH_SCHEME = "my-cookie-auth";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(AUTH_SCHEME)
                .AddCookie(AUTH_SCHEME);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapGet("/username", (HttpContext context) =>
{
    return context.User.FindFirst("usr")?.Value;
});

app.MapGet("/login", async (HttpContext context, [FromQuery] string username) =>
{
    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
    {
        new Claim("usr", username)
    }, AUTH_SCHEME));
    
    await context.SignInAsync(AUTH_SCHEME, claimsPrincipal);
    return "ok";
});

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync();
    return "signed out";
});

app.Run();
