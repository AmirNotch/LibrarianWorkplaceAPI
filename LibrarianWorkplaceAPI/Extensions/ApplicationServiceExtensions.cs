using System.Collections.Generic;
using Application.Core;
using Application.LibrarianWorkplace;
using LibrarianWorkplaceAPI.Behaviors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace LibrarianWorkplaceAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseNpgsql(config.GetConnectionString("Default"),
                    b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName));
            });
            
            // services.AddDbContext<DataContext>(opt =>
            // {
            //     opt.UseSqlServer(config.GetConnectionString("Default"),
            //         b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName));
            // });
            
            services.AddMediatR(typeof(ListBooks.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            return services;
        }
    }
}