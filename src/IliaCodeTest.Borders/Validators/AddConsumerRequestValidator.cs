using FluentValidation;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Properties;
using IliaCodeTest.Borders.Utils;

namespace IliaCodeTest.Borders.Validators
{
    public class AddConsumerRequestValidator : AbstractValidator<AddConsumerRequest>
    {
        public AddConsumerRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Resources.ValidateUserNameMustBeInformed);

            RuleFor(x => x.Email).NotEmpty().WithMessage(Resources.ValidateEmailMustBeInformed);
            RuleFor(x => x.Email).EmailAddress().WithMessage(Resources.ValidateEmailIsValid);

            RuleFor(x => x.MainDocument).NotEmpty().WithMessage(Resources.ValidateCPFMustBeInformed);
            RuleFor(x => x.MainDocument).Must(x => CpfUtils.IsValid(x)).WithMessage(Resources.ValidateMainDocumentIsValid);
           
        }
    }
}
