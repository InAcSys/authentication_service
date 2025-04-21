using System.Reflection;
using AuthenticationService.Application.Services.Concretes;
using AuthenticationService.Application.Services.Interfaces;
using AuthenticationService.Application.Validators;
using AuthenticationService.Domain.Entities.Concretes;
using AuthenticationService.Infrastructure.Context;
using AuthenticationService.Infrastructure.Repositories.Concretes;
using AuthenticationService.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Presentation.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            var connection = Environment.GetEnvironmentVariable("AUTHENTICATION_SERVICE_DATABASE_STRING_CONNECTION");

            if (string.IsNullOrEmpty(connection))
            {
                throw new ArgumentException("Connection not found");
            }

            services.AddDbContext<DbContext, AuthenticationServiceDbContext>(
                options => options.UseMySql
                (
                    connection,
                    new MySqlServerVersion(
                        new Version(8, 0, 23)
                    ),
                    mysqlOptions =>
                    {
                        mysqlOptions.EnableRetryOnFailure();
                    }
                )
            );

            services.AddScoped<IService<Session, Guid>, SessionService>();
            services.AddScoped<ILogInService, SessionService>();
            services.AddScoped<IRepository<Session, Guid>, SessionRepository>();
            services.AddScoped<ILogInRepository, SessionRepository>();

            services.AddValidatorsFromAssemblyContaining<SessionValidator>();

            return services;
        }
    }
}
