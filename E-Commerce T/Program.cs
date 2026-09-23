
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using E_Commerce_T.Data;
using E_Commerce_T.Services;
using E_Commerce_T.DTO.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace E_Commerce_T
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")
                ));

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            builder.Services.AddScoped<RegisterService>();
            builder.Services.AddSingleton<JwtSettings>();
            builder.Services.AddSingleton<JwtCon>();


            var app = builder.Build();
            var siginingKey = builder.Configuration.GetSection("JwtSettings:SigningKey").Value;

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(
                options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(siginingKey)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero

                });

            builder.Services.AddAuthorization();

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
