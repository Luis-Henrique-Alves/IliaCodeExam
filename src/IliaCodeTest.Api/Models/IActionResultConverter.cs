using System.Linq;
using IliaCodeTest.Borders.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace IliaCodeTest.Models
{
    public interface IActionResultConverter
    {
        IActionResult Convert<T>(UseCaseResponse<T> response);
    }

    public class ActionResultConverter : IActionResultConverter
    {
        private readonly string _path;

        public ActionResultConverter(IHttpContextAccessor accessor)
        {
            _path = accessor.HttpContext.Request.Path.Value;
        }

        public IActionResult Convert<T>(UseCaseResponse<T> response)
        {
            if (response == null)
                return BuildError(new[] { new ErrorMessage("000", "ActionResultConverter Error") }, UseCaseResponseKind.InternalServerError);

            if (response.Success())
            {
                return new OkObjectResult(response.Result);
            }
            else
            {
                var useCaseResponseErrorKind = response.GetErrorKind();
                if (useCaseResponseErrorKind == null)
                    return BuildError(new[] { new ErrorMessage("000", "ActionResultConverter Error") }, UseCaseResponseKind.InternalServerError);

                var hasErrors = response.Errors == null || !response.Errors.Any();
                var errorResult = hasErrors
                    ? new[] { new ErrorMessage("000", response.ErrorMessage ?? "Unknown error") }
                    : response.Errors;

                return BuildError(errorResult, useCaseResponseErrorKind.Value);
            }
        }

        ObjectResult BuildError(object data, UseCaseResponseKind statusCode)
        {
            if (statusCode == UseCaseResponseKind.InternalServerError)
                Log.Error($"[ERROR] {_path} ({{@data}})", data);

            return new ObjectResult(data)
            {
                StatusCode = (int)statusCode
            };
        }
    }
}
