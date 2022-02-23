using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Properties;
using IliaCodeTest.Borders.Repositories;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IliaCodeTest.UseCases
{
    public class GetConsumerWithOrdersUseCase : IGetConsumerWithOrdersUseCase
    {
        private readonly ILogger<GetConsumerWithOrdersUseCase> _logger;
        private readonly IConsumerRepository _consumerRepository;


        public GetConsumerWithOrdersUseCase(
            IConsumerRepository  consumerRepository,
            ILogger<GetConsumerWithOrdersUseCase> logger
        )
        {
            _consumerRepository = consumerRepository;
            _logger = logger;

        }

        public async Task<UseCaseResponse<PagedResult<GetConsumerWithOrdersResponse>>> Execute (GetConsumerWithOrdersRequest getConsumerWithRequest)
        {

            var response = new UseCaseResponse<PagedResult<GetConsumerWithOrdersResponse>>();

            try
            {
                return response.SetResult(await _consumerRepository.GetConsumersWithOrdersAsync(getConsumerWithRequest));
            }

            catch (Exception ex)
            {

                _logger.LogError(ex, Resources.ValidateUserNameMustBeInformed);
                return response.SetInternalServerError(Resources.ValidateUserNameMustBeInformed);

            }


        }
    }
}
