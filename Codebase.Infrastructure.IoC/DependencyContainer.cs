using System;
using Codebase.Application.Interfaces;
using Codebase.Application.Services;
using Codebase.Domain.Interfaces;
using Codebase.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Codebase.Infrastructure.IoC;

public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CleanArchitecture.Application
            services.AddScoped<IAuthService, AuthService>();

            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
