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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using IliaCodeTest.Borders.Properties;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using Bogus;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Dtos;

namespace IliaCodeTest.Test.Use_Cases.GetOrdersByConsumerUseCaseTest
{
    public class GetOrdersByConsumerUseCaseTest
    {

        private readonly Mock<IOrderRepository> _repositoryMock;
        private readonly GetOrdersByConsumerUseCase _useCase;

        public GetOrdersByConsumerUseCaseTest()
        {
            _repositoryMock = new Mock<IOrderRepository>();
            _useCase = new GetOrdersByConsumerUseCase(_repositoryMock.Object, Mock.Of<ILogger<GetOrdersByConsumerUseCase>>());

        }

        [Fact]
        public async Task Execute_GetOrdersByConsumer_Success()
        {
            //Arrenge
            var request = new GetOrdersByConsumerRequestBuilder().Build();
            var faker = new Faker<OrderDTO>();
            var rows = 10;
            var Orders = faker.Generate(rows);
            var pageResult = new PagedResult<OrderDTO>
            {
                Data = Orders,
                Total = rows
            };

            _repositoryMock.Setup(repository => repository.GetOrdersByConsumer(request)).ReturnsAsync(pageResult);


            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.Result.Should().BeEquivalentTo(pageResult);

        }

        [Fact]
        public async Task Execute_GetOrdersByConsumer_WhenInternalServerErrorResponse()
        {
            //Arrenge
            var request = new GetOrdersByConsumerRequestBuilder().Build();
            _repositoryMock.Setup(repository => repository.GetOrdersByConsumer(request)).ThrowsAsync(new Exception());

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.GetErrorKind().Should().Be(UseCaseResponseKind.InternalServerError);

        }


    }
}
