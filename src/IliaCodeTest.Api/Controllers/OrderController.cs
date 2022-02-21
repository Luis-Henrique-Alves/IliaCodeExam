using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IliaCodeTest.Borders.UseCases;
using IliaCodeTest.Borders.Dtos;
using System.Threading.Tasks;
using IliaCodeTest.Models;
using System.Net;
using IliaCodeTest.Borders.Shared;

namespace IliaCodeExam.Controllers
{
    [ApiController]
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IRegisterNewOrderUseCase _registerNewOrderUseCase;
        private readonly IGetOrdersByConsumerUseCase _getOrdersByConsumerUseCase;
        private readonly IUpdateOrderStatusUseCase _updateOrderStatusUseCase;
        private readonly IActionResultConverter _actionResultConverter;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IRegisterNewOrderUseCase registerNewOrderUseCase, IUpdateOrderStatusUseCase updateOrderStatusUseCase, IGetOrdersByConsumerUseCase getOrdersByConsumerUseCase, IActionResultConverter actionResultConverter, ILogger<OrderController> logger)
        {
            _registerNewOrderUseCase = registerNewOrderUseCase;
            _getOrdersByConsumerUseCase = getOrdersByConsumerUseCase;
            _updateOrderStatusUseCase = updateOrderStatusUseCase;
            _actionResultConverter = actionResultConverter;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorMessage[]))]
        [Route("registerNewOrder")]
        public async Task<IActionResult> RegisterNewOrder([FromBody] RegisterNewOrderRequest request)
        {
            return _actionResultConverter.Convert(await _registerNewOrderUseCase.Execute(request));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorMessage[]))]
        [Route("getOrdersByConsumer")]
        public async Task<IActionResult> GetOrdersByConsumerUseCase([FromQuery] GetOrdersByConsumerRequest request)
        {
            return _actionResultConverter.Convert(await _getOrdersByConsumerUseCase.Execute(request));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorMessage[]))]
        [Route("updateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatus([FromQuery] UpdateOrderStatusRequest request)
        {
            return _actionResultConverter.Convert(await _updateOrderStatusUseCase.Execute(request));
        }
    }
}
