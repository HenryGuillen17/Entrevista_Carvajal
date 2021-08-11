using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserBackEnd.Domain.Contracts.Services;
using UserBackEnd.Infraestructure.Context;
using UserBackEnd.Infraestructure.Contracts.Context;
using UserBackEnd.Infraestructure.Contracts.Repository;
using UserBackEnd.Infraestructure.Repositories;
using UserBackEnd.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UserBackEnd.UserApi.Configuration
{
    public static class DependencyConfiguration
    {
        public static void AddDataBaseConfig(
            this IServiceCollection service, IConfiguration configuracion
        )
        {
            service
                .AddScoped<IUserDbContext, UserDbContext>()
                .AddDbContext<UserDbContext>(options =>
                    options.UseSqlServer(configuracion.GetConnectionString("MSSQL")))
                ;
        }

        public static void AddRepositoryConfig(
            this IServiceCollection service
        )
        {
            service
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IIdentificationTypeRepository, IdentificationTypeRepository>()
                ;
        }

        public static void AddServicesConfig(
            this IServiceCollection service
        )
        {
            service
                .AddScoped<IUserService, UserService>()
                .AddScoped<IIdentificationTypeService, IdentificationTypeService>()
                ;
        }

        public static void AddJwtBearer(this IServiceCollection services, IConfiguration configuracion)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuracion["Jwt:Issuer"],
                        ValidAudience = configuracion["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuracion["Jwt:Key"])),
                        ClockSkew = TimeSpan.FromMinutes(5)
                    };
                });

        }

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void AddSwagger(this IServiceCollection services, IConfiguration configuracion)
        {
            services.AddSwaggerGen(options =>
            {
                // Specify two versions 
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Version = "v1.0",
                        Title = "UserBackEnd User API V1",
                        Description = "API Documentation UserBackEnd V1",
                        Contact = new OpenApiContact
                        {
                            Name = configuracion["Swagger:NameContact"],
                            Email = configuracion["Swagger:EmailContact"],
                            Url = new Uri(configuracion["Swagger:UrlContact"])
                        }
                    });

                // This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter the JWT Bearer token to obtain results."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }


    }
}
