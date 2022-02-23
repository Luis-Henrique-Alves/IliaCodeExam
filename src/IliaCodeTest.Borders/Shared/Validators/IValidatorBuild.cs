using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IliaCodeTest.Borders.Shared.Validators
{
    public interface IValidatorBuilder
    {
        List<ValidationFailure> BuildErrors();
    }
}
