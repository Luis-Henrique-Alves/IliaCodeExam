using FluentValidation;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Properties;

namespace IliaCodeTest.Borders.Validators
{
    public class AddConsumerRequestValidator : AbstractValidator<AddConsumerRequest>
    {
        public AddConsumerRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Resources.ValidateUserNameMustBeInformed);
            RuleFor(x => x.Email).EmailAddress().WithMessage(Resources.ValidateEmailIsValid);
        }
    }
}
