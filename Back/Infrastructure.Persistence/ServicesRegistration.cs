using Core.Application.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddRepositories(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(option => option.UseSqlServer(configuration.GetConnectionString("ConnectionString"), m => m.MigrationsAssembly(typeof(DBContext).Assembly.FullName)));
            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
        }

    }
}
