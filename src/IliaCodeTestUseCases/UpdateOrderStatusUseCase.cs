using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IliaCodeTest.UseCases
{
    public class UpdateOrderStatusUseCase : IUpdateOrderStatusUseCase
    {
        private readonly ILogger<UpdateOrderStatusUseCase> _logger;

        public UpdateOrderStatusUseCase(
            ILogger<UpdateOrderStatusUseCase> logger
        )
        {
            _logger = logger;

        }

        public async Task<UseCaseResponse<bool>> Execute (UpdateOrderStatusRequest updateOrderStatusRequest)
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
