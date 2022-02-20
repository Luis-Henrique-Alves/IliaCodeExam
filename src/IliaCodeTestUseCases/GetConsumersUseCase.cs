using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Repositories;
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
        private readonly IConsumerRepository _consumerRepository;

        public GetConsumersUseCase(
            ILogger<GetConsumersUseCase> logger,
            IConsumerRepository consumerRepository
        )
        {
            _consumerRepository = consumerRepository;
            _logger = logger;

        }

        public async Task<UseCaseResponse<PagedResult<GetConsumerResponse>>> Execute (GetConsumerRequest getConsumerRequest)
        {

            var response = new UseCaseResponse<PagedResult<GetConsumerResponse>>();

            try
            {
                return response.SetResult( await _consumerRepository.GetConsumersAsync(getConsumerRequest));
            }

            catch (Exception ex)
            {

                _logger.LogError(ex, "teste");
                return response.SetInternalServerError("error");

            }


        }
    }
}
