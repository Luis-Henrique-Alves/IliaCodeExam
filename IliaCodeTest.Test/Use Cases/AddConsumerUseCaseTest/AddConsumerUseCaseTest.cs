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

namespace IliaCodeTest.Test.Use_Cases.AddConsumerUseCaseTest
{
    public class AddConsumerUseCaseTest
    {

        private readonly Mock<IConsumerRepository> _repositoryMock;
        private readonly AddConsumerUseCase _useCase;
        private readonly IValidator<AddConsumerRequest> _validator;

        public AddConsumerUseCaseTest()
        {
            _repositoryMock = new Mock<IConsumerRepository>();
            _validator = new AddConsumerRequestValidator();
            _useCase = new AddConsumerUseCase(_repositoryMock.Object, _validator,Mock.Of<ILogger<AddConsumerUseCase>>());

        }

        [Fact]
        public async Task Execute_AddConsumer_Success()
        {
            //Arrenge
            var request = new AddConsumerRequestBuilder().Build();
            bool Expected = true;

            var result = _repositoryMock.Setup(repository => repository.AddConsumerAsync(request));

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.Result.Should().Be(Expected);

        }

        [Fact]
        public async Task Execute_AddConsumer_AlreadyExist()
        {
            //Arrenge
            var request = new AddConsumerRequestBuilder().Build();
            _repositoryMock.Setup(repository => repository.CheckIfExist(request.Email, request.MainDocument)).ReturnsAsync(true);

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.GetErrorKind().Should().Be(UseCaseResponseKind.BadRequest);

        }

        [Fact]
        public async Task Execute_AddConsumer_WhenRequestIsInvalid()
        {
            //Arrenge
            var request = new AddConsumerRequestBuilder()
                .WithNameIsEmpty()
                .WithEmailInvalid()
                .WithMainDocumentInvalid()
                .Build();

            _repositoryMock.Setup(repository => repository.CheckIfExist(request.Email, request.MainDocument)).ReturnsAsync(true);

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.GetErrorKind().Should().Be(UseCaseResponseKind.UnprocessableEntity);

        }

        [Fact]
        public async Task Execute_AddConsumer_WhenInternalServerErrorResponse()
        {
            //Arrenge
            var request = new AddConsumerRequestBuilder().Build();
            var result = _repositoryMock.Setup(repository => repository.AddConsumerAsync(request)).ThrowsAsync(new Exception());

            //Act
            var response = await _useCase.Execute(request);

            //Assert
            response.GetErrorKind().Should().Be(UseCaseResponseKind.InternalServerError);

        }
    }
}
