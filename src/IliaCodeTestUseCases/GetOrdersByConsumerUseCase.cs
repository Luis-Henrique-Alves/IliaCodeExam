using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Repositories;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using IliaTestExam.Borders.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IliaCodeTest.UseCases
{
    public class GetOrdersByConsumerUseCase : IGetOrdersByConsumerUseCase
    {
        private readonly ILogger<GetOrdersByConsumerUseCase> _logger;
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByConsumerUseCase(
            IOrderRepository orderRepository,
            ILogger<GetOrdersByConsumerUseCase> logger
        )
        {
            _logger = logger;
            _orderRepository = orderRepository;

        }

        public async Task<UseCaseResponse<PagedResult<OrderDTO>>> Execute (GetOrdersByConsumerRequest getOrdersByConsumerRequest)
        {

            var response = new UseCaseResponse<PagedResult<OrderDTO>>();

            try
            {
                return response.SetResult(await _orderRepository.GetOrdersByConsumer(getOrdersByConsumerRequest));
            }

            catch (Exception ex)
            {

                _logger.LogError(ex, "Erro Inesperado Ao Obter Ordens po Cliente");
                return response.SetInternalServerError("Erro Inesperado Ao Obter Ordens po Cliente");

            }


        }
    }
}
