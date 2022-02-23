using FluentAssertions;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Repositories;
using IliaCodeTest.Test.Builders;
using IliaCodeTest.UseCases;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using IliaCodeTest.Borders.Shared;
using Bogus;
using IliaCodeTest.Borders.Models.Pagination;

namespace IliaCodeTest.Test.Use_Cases.GetConsumerUseCaseTest
{
    public class GetConsumerUseCaseTest
    {

        private readonly Mock<IConsumerRepository> _repositoryMock;
        private readonly GetConsumersUseCase _useCase;

        public GetConsumerUseCaseTest()
        {
            _repositoryMock = new Mock<IConsumerRepository>();
            _useCase = new GetConsumersUseCase(Mock.Of<ILogger<GetConsumersUseCase>>(), _repositoryMock.Object);

        }

        [Fact]
        public async Task Execute_GetConsumers_Success()
        {
            //Arrenge
            var request = new GetConsumerRequestBuilder().Build();
            var faker = new Faker<GetConsumerResponse>();
            var rows = 10;
            var consumers = faker.Generate(rows);
            var pageResult = new PagedResult<GetConsumerResponse>
            {
                Data = consumers,
                Total = rows
            };

            _repositoryMock.Setup(repository => repository.GetConsumersAsync(request)).ReturnsAsync(pageResult);


            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.Result.Should().BeEquivalentTo(pageResult);

        }

        [Fact]
        public async Task Execute_GetConsumers_WhenInternalServerErrorResponse()
        {
            //Arrenge
            var request = new GetConsumerRequestBuilder().Build();
            _repositoryMock.Setup(repository => repository.GetConsumersAsync(request)).ThrowsAsync(new Exception());

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.GetErrorKind().Should().Be(UseCaseResponseKind.InternalServerError);

        }


    }
}
