using FluentValidation;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace IliaCodeTest.Configurations
{
    public static class ValidatorConfig
    {
        public static void ConfigureValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AddConsumerRequest>, AddConsumerRequestValidator>();

        }
        


    }
}
