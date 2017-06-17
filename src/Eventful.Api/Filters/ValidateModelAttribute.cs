using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Eventful.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private const string InvalidModelCode = "InvalidModel";
        private const string InvalidOrMissingParameter = "InvalidOrMissingParameter";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
