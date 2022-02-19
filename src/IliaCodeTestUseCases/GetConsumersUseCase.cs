using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IliaCodeTest.UseCases
{
    public class GetConsumersUseCase : IGetConsumersUseCase
    {
        private readonly ILogger<GetConsumersUseCase> _logger;

        public GetConsumersUseCase(
            ILogger<GetConsumersUseCase> logger
        )
        {
            _logger = logger;

        }

        public async Task<UseCaseResponse<PagedResult<GetConsumerResponse>>> Execute (GetConsumerRequest getConsumerRequest)
        {

            var response = new UseCaseResponse<PagedResult<GetConsumerResponse>>();

            try
            {
                return response.SetResult(new PagedResult<GetConsumerResponse>());
            }

            catch (Exception ex)
            {

                _logger.LogError(ex, "teste");
                return response.SetInternalServerError("error");

            }


        }
    }
}
