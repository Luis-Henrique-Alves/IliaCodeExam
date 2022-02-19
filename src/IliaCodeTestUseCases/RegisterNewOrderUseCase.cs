using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IliaCodeTest.UseCases
{
    public class RegisterNewOrderUseCase : IRegisterNewOrderUseCase
    {
        private readonly ILogger<RegisterNewOrderUseCase> _logger;

        public RegisterNewOrderUseCase(
            ILogger<RegisterNewOrderUseCase> logger
        )
        {
            _logger = logger;

        }

        public async Task<UseCaseResponse<bool>> Execute (RegisterNewOrderRequest registerNewOrderUseCase)
        {

            var response = new UseCaseResponse<bool>();

            try
            {
                return response.SetResult(true);
            }

            catch (Exception ex)
            {

                _logger.LogError(ex, "teste");
                return response.SetInternalServerError("error");

            }


        }
    }
}
