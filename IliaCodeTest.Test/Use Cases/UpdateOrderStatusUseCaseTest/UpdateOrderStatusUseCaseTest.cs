using FluentValidation;
using FluentAssertions;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Repositories;
using IliaCodeTest.Borders.Validators;
using IliaCodeTest.Test.Builders;
using IliaCodeTest.UseCases;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using IliaCodeTest.Borders.Shared;

namespace IliaCodeTest.Test.Use_Cases.UpdateOrderStatusUseCaseTest
{
    public class UpdateOrderStatusUseCaseTest
    {

        private readonly Mock<IOrderRepository> _repositoryMock;
        private readonly UpdateOrderStatusUseCase _useCase;

        public UpdateOrderStatusUseCaseTest()
        {
            _repositoryMock = new Mock<IOrderRepository>();
            _useCase = new UpdateOrderStatusUseCase(Mock.Of<ILogger<UpdateOrderStatusUseCase>>(), _repositoryMock.Object);

        }

        [Fact]
        public async Task Execute_UpdateOrderStatus_Success()
        {
            //Arrenge
            var request = new UpdateOrderStatusRequestBuilder().Build();
            bool Expected = true;

            var result = _repositoryMock.Setup(repository => repository.UpdateOrderStatus(request));

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.Result.Should().Be(Expected);

        }


        [Fact]
        public async Task Execute_UpdateOrderStatus_WhenInternalServerErrorResponse()
        {
            //Arrenge
            var request = new UpdateOrderStatusRequestBuilder().Build();
            var result = _repositoryMock.Setup(repository => repository.UpdateOrderStatus(request)).ThrowsAsync(new Exception());

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.GetErrorKind().Should().Be(UseCaseResponseKind.InternalServerError);

        }
    }
}
