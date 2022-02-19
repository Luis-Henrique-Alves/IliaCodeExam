using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IliaCodeTest.UseCases
{
    public class AddConsumerUseCase : IAddConsumerUseCase
    {
        private readonly ILogger<AddConsumerUseCase> _logger;

        public AddConsumerUseCase(
            ILogger<AddConsumerUseCase> logger
        )
        {
            _logger = logger;

        }

        public async Task<UseCaseResponse<bool>> Execute (AddConsumerRequest addConsumerRequest)
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
