using Business.Contract;
using Business.Implement;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
using DataAccess.Models;
using DataAccess.Models.Mapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public static class IoCRegister
    {
        

        public static IServiceCollection AddRepository(IServiceCollection services)
        {
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IEditorialRepository, EditorialRepository>();
            services.AddScoped<ILibroRepository, LibroRepository>();
            services.AddScoped<IAutorHLRepository, AutorHasLibroRepository>();
            return services;
        }

        public static IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddScoped<IAutorServices, AutorServices>();
            services.AddAutoMapper(typeof(AutorProfileMap));

            services.AddScoped<IEditorialServices, EditorialServices>();
            services.AddAutoMapper(typeof(EditorialProfileMap));

            services.AddScoped<ILibroServices, LibroServices>();
            services.AddAutoMapper(typeof(LibroProfileMap));

            services.AddScoped<IAutorHLServices, AutorHasLibroServices>();
            services.AddAutoMapper(typeof(AutorHasLibroProfMap));

            return services;
        }

        public static IServiceCollection AddDbContext(IServiceCollection services, string DefaultConnection)
        {            
            services.AddDbContext<DbCrudContext>(options =>
            options.UseSqlServer(DefaultConnection));

            return services;
        }
    }
}
