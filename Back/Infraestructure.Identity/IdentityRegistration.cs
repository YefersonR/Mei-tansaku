using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infraestructure.Identity.Context;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Identity.Entities;
using Core.Domain.Settings;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Core.Application.Dtos.Account;
using Core.Application.Inferfaces.Service;
using Infrastructure.Identity.Services;
using Core.Application.Services;
using Core.Application.Interface.Services;

namespace Infraestructure.Identity
{
    public static class IdentityRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<IdentityContext>(option =>
            {
                option.EnableSensitiveDataLogging();
                option.UseSqlServer(configuration.GetConnectionString("MeiTansakuConnectionString"), m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            }, ServiceLifetime.Scoped);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Account";
                option.AccessDeniedPath = "/User/AccessDenied";
            });
            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; //patrue
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]!))
                };
                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnChallenge = c =>
                    {
                        c.HandleResponse();
                        c.Response.StatusCode = 401;
                        c.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new JwtResponse { Error = "You're Not Authorized", HasError = true });
                        return c.Response.WriteAsync(result);
                    },
                    OnForbidden = c =>
                    {
                        c.Response.StatusCode = 404;
                        c.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new JwtResponse { Error = "You're Not Authorized to access to this resource", HasError = true });
                        return c.Response.WriteAsync(result);
                    }
                };
            });

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}