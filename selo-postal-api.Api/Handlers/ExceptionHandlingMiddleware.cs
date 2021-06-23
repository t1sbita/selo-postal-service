using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;

namespace selo_postal_api.Api.Handlers
{
    public class ExceptionHandlingMiddleware : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Get(
            [FromServices] IWebHostEnvironment env
        )
        {
            if (env.EnvironmentName != "Development")
            {
                return Problem();
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            if (exception.GetType().Name == "NotFoundException")
            {
                return Problem(
                    title: exception.Message,
                    type: exception.GetType().Name,
                    statusCode: 404
                );
            }

            return Problem(
                //detail: exception.StackTrace,
                title: exception.Message,
                type: exception.GetType().Name
            );
        }
    }
}