using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading.Tasks;

namespace IliaCodeTest.UseCases
{
    public class GetOrdersByConsumerUseCase : IGetOrdersByConsumerUseCase
    {
        private readonly ILogger<GetOrdersByConsumerUseCase> _logger;

        public GetOrdersByConsumerUseCase(
            ILogger<GetOrdersByConsumerUseCase> logger
        )
        {
            _logger = logger;

        }

        public async Task<UseCaseResponse<PagedResult<GetOrdersByConsumerResponse>>> Execute (GetOrdersByConsumerRequest getOrdersByConsumerRequest)
        {

            var response = new UseCaseResponse<PagedResult<GetOrdersByConsumerResponse>>();

            try
            {
                return response.SetResult(new PagedResult<GetOrdersByConsumerResponse>());
            }

            catch (Exception ex)
            {

                _logger.LogError(ex, "teste");
                return response.SetInternalServerError("error");

            }


        }
    }
}
