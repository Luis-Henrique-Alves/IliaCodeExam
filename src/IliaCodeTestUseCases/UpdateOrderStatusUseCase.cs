using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Repositories;
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
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderStatusUseCase(
            ILogger<UpdateOrderStatusUseCase> logger,
            IOrderRepository orderRepository
        )
        {
             _orderRepository = orderRepository;
            _logger = logger;

        }

        public async Task<UseCaseResponse<bool>> Execute (UpdateOrderStatusRequest updateOrderStatusRequest)
        {

            var response = new UseCaseResponse<bool>();

            try
            {
                await _orderRepository.UpdateOrderStatus(updateOrderStatusRequest);
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
