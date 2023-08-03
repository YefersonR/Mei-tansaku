using Core.Application.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("MeiTansakuConnectionString"),
                m =>
                {
                    m.MigrationsAssembly(typeof(DBContext).Assembly.FullName);
                    //m.EnableRetryOnFailure(
                    //    maxRetryCount: 5,
                    //    maxRetryDelay:TimeSpan.FromSeconds(10),
                    //    errorNumbersToAdd: null
                    //    );
                });
            });
            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IValue_AttributeRepository, Value_AttributesRepository>();
            services.AddTransient<IAttribute_ProductRepository, Attribute_ProductRepository>();
            services.AddTransient<IShopping_ListRepository, Shopping_ListRepository>();
            services.AddTransient<IProduct_ListRepository, Product_ListRepository>();
        }

    }
}
