
namespace rbac_demo
{
    public class Program
    {
        // WATCH THIS AND WRITE THE CODE: https://youtu.be/W5T6713KRzg?si=lt9BhyWctCHqxHxt

        const string AUTH_SCHEME = "my-authentication-scheme";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(AUTH_SCHEME)
                            .AddCookie(AUTH_SCHEME);

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddEndpointsApiExplorer();

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

            app.MapControllers();

            app.Run();
        }
    }
}