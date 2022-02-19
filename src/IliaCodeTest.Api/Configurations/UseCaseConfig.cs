using IliaCodeTest.Borders.UseCases;
using IliaCodeTest.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace IliaCodeTest.Configurations
{
    public static class UseCaseConfig
    {
        public static void ConfigureUseCase(this IServiceCollection services)
        {
            services.AddScoped<IAddConsumerUseCase, AddConsumerUseCase>();
            services.AddScoped<IGetConsumersUseCase, GetConsumersUseCase>();
            services.AddScoped<IGetConsumerWithOrdersUseCase, GetConsumerWithOrdersUseCase>();
            services.AddScoped<IRegisterNewOrderUseCase, RegisterNewOrderUseCase>();
            services.AddScoped<IGetOrdersByConsumerUseCase, GetOrdersByConsumerUseCase>();
            services.AddScoped<IUpdateOrderStatusUseCase, UpdateOrderStatusUseCase>();
        }


    }
}
