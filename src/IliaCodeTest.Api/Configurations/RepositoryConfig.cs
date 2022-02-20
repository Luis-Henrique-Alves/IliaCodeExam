using IliaCodeTest.Borders.Repositories;
using IliaCodeTest.Models;
using IliaCodeTest.Repository.DbContext;
using IliaCodeTest.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IliaCodeTest.Configurations
{
    public static class RepositoryConfig
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<IIliaCodeTestDbContext, IliaCodeTestDbContext>();
            services.AddTransient<IConsumerRepository, ConsumerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
        }


    }
}
