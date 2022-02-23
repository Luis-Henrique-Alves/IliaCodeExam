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

namespace IliaCodeTest.Test.Use_Cases.GetConsumerWithOrdersUseCaseTest
{
    public class GetConsumerWithOrdersUseCaseTest
    {

        private readonly Mock<IConsumerRepository> _repositoryMock;
        private readonly GetConsumerWithOrdersUseCase _useCase;

        public GetConsumerWithOrdersUseCaseTest()
        {
            _repositoryMock = new Mock<IConsumerRepository>();
            _useCase = new GetConsumerWithOrdersUseCase(_repositoryMock.Object, Mock.Of<ILogger<GetConsumerWithOrdersUseCase>>());

        }

        [Fact]
        public async Task Execute_GetConsumersWithOrder_Success()
        {
            //Arrenge
            var request = new GetConsumerWithOrderRequestBuilder().Build();
            var faker = new Faker<GetConsumerWithOrdersResponse>();
            var rows = 10;
            var consumersWithOrders = faker.Generate(rows);
            var pageResult = new PagedResult<GetConsumerWithOrdersResponse>
            {
                Data = consumersWithOrders,
                Total = rows
            };

            _repositoryMock.Setup(repository => repository.GetConsumersWithOrdersAsync(request)).ReturnsAsync(pageResult);


            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.Result.Should().BeEquivalentTo(pageResult);

        }

        [Fact]
        public async Task Execute_GetConsumersWithOrder_WhenInternalServerErrorResponse()
        {
            //Arrenge
            var request = new GetConsumerWithOrderRequestBuilder().Build();
            _repositoryMock.Setup(repository => repository.GetConsumersWithOrdersAsync(request)).ThrowsAsync(new Exception());

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.GetErrorKind().Should().Be(UseCaseResponseKind.InternalServerError);

        }


    }
}
