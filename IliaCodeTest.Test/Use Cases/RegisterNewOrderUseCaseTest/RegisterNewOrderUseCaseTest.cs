using FluentAssertions;
using IliaCodeTest.Borders.Repositories;
using IliaCodeTest.Test.Builders;
using IliaCodeTest.UseCases;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using IliaCodeTest.Borders.Shared;

namespace IliaCodeTest.Test.Use_Cases.RegisterNewOrderUseCaseTest
{
    public class RegisterNewOrderUseCaseTest
    {

        private readonly Mock<IOrderRepository> _repositoryMock;
        private readonly RegisterNewOrderUseCase _useCase;

        public RegisterNewOrderUseCaseTest()
        {
            _repositoryMock = new Mock<IOrderRepository>();
            _useCase = new RegisterNewOrderUseCase(_repositoryMock.Object, Mock.Of<ILogger<RegisterNewOrderUseCase>>());

        }

        [Fact]
        public async Task Execute_RegisterNewOrder_Success()
        {
            //Arrenge
            var request = new RegisterNewOrderRequestBuilder().Build();
            bool Expected = true;

            _repositoryMock.Setup(repository => repository.RegisterNewOrderRequestAsync(request));

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.Result.Should().Be(Expected);

        }

        [Fact]
        public async Task Execute_AddConsumer_WhenInternalServerErrorResponse()
        {
            //Arrenge
            var request = new RegisterNewOrderRequestBuilder().Build();
            var result = _repositoryMock.Setup(repository => repository.RegisterNewOrderRequestAsync(request)).ThrowsAsync(new Exception());

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.GetErrorKind().Should().Be(UseCaseResponseKind.InternalServerError);

        }
    }
}
