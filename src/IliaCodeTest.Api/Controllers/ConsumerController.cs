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
    [Route("api/Consumer")]
    public class ConsumerController : ControllerBase
    {
        private readonly IAddConsumerUseCase _addConsumerUseCase;
        private readonly IGetConsumersUseCase _getConsumersUseCase;
        private readonly IGetConsumerWithOrdersUseCase _getConsumerWithOrdersUseCase;
        private readonly IActionResultConverter _actionResultConverter;
        private readonly ILogger<ConsumerController> _logger;

        public ConsumerController(IAddConsumerUseCase addConsumerUseCase, IGetConsumersUseCase getConsumersUseCase, IActionResultConverter actionResultConverter, IGetConsumerWithOrdersUseCase getConsumerWithOrdersUseCase, ILogger<ConsumerController> logger)
        {
            _addConsumerUseCase = addConsumerUseCase;
            _getConsumersUseCase = getConsumersUseCase;
            _getConsumerWithOrdersUseCase = getConsumerWithOrdersUseCase;
            _actionResultConverter = actionResultConverter;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorMessage[]))]
        [Route("addConsumer")]
        public async Task<IActionResult> AddConsumer([FromBody]AddConsumerRequest request)
        {
            return _actionResultConverter.Convert(await _addConsumerUseCase.Execute(request));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorMessage[]))]
        [Route("getConsumers")]
        public async Task<IActionResult> GetConsumers([FromQuery] GetConsumerRequest request)
        {
            return _actionResultConverter.Convert(await _getConsumersUseCase.Execute(request));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorMessage[]))]
        [Route("getConsumersWithOrders")]

        public async Task<IActionResult> GetConsumersWithOrders([FromQuery] GetConsumerWithOrdersRequest request)
        {
            return _actionResultConverter.Convert(await _getConsumerWithOrdersUseCase.Execute(request));
        }
    }
}
