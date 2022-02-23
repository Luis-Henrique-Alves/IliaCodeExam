using FluentValidation;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Properties;
using IliaCodeTest.Borders.Repositories;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IliaCodeTest.UseCases
{
    public class AddConsumerUseCase : IAddConsumerUseCase
    {
        private readonly ILogger<AddConsumerUseCase> _logger;
        private readonly IValidator<AddConsumerRequest> _validator;
        private readonly IConsumerRepository _consumerRepository;

        public AddConsumerUseCase(IConsumerRepository consumerRepository,
            IValidator<AddConsumerRequest> validator,
            ILogger<AddConsumerUseCase> logger
        )
        {
            _validator = validator;
            _consumerRepository = consumerRepository;
            _logger = logger;

        }

        public async Task<UseCaseResponse<bool>> Execute (AddConsumerRequest addConsumerRequest)
        {   

            var response = new UseCaseResponse<bool>();

            try
            {

                await _validator.ValidateAndThrowAsync(addConsumerRequest);

                if (await _consumerRepository.CheckIfExist(addConsumerRequest.Email, addConsumerRequest.MainDocument))
                {
                    return response.SetBadRequest(Resources.ValidateUniqueCPFandEmail);
                }


                await _consumerRepository.AddConsumerAsync(addConsumerRequest);
                return response.SetResult(true);
            }

            catch (ValidationException ex)
            {   
                return response.SetRequestValidationError(ex.Errors);

            }

            catch (Exception ex)
            {

                _logger.LogError(ex, Resources.UnexpectedErrorAddConsumer);
                return response.SetInternalServerError(Resources.UnexpectedErrorAddConsumer);

            }



        }
    }
}
