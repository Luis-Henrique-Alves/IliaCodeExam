using System.Collections.Generic;
using FluentValidation.Results;
using IliaCodeTest.Borders.Shared.Validators;

namespace Pottencial.Channels.Portals.Authorization.Shared.Validators
{
    public abstract class ValidatorBuilder : IValidatorBuilder
    {
        protected List<ValidationFailure> Errors { get; }

        protected ValidatorBuilder()
        {
            Errors = new List<ValidationFailure>();
        }

        public List<ValidationFailure> BuildErrors()
        {
            return Errors;
        }
    }
}