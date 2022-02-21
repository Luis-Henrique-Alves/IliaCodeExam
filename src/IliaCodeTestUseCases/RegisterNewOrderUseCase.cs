using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Repositories;
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
        private readonly IOrderRepository _orderRepository;

        public RegisterNewOrderUseCase(
         IOrderRepository orderRepository,
        ILogger<RegisterNewOrderUseCase> logger
        )
        {
            _orderRepository = orderRepository;
            _logger = logger;

        }

        public async Task<UseCaseResponse<bool>> Execute (RegisterNewOrderRequest registerNewOrderUseCase)
        {

            var response = new UseCaseResponse<bool>();

            try
            {
                await _orderRepository.RegisterNewOrderRequestAsync(registerNewOrderUseCase);
                return response.SetResult(true);
            }

            catch (Exception ex)
            {

                _logger.LogError(ex, "Erro Inesperado Ao Registrar novo Pedido");
                return response.SetInternalServerError("Erro Inesperado Ao Registrar novo Pedido");

            }


        }
    }
}
