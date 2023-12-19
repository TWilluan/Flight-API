

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
public class ErrorController : ApiController
{
    private readonly ILogger<ErrorController> _logger;

    private Exception? Exception;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        Exception = HttpContext.Features.Get<IExceptionHandlerFeature>()!.Error;
    }

    private void LogException()
    {
        if (Exception == null)
            return;
        
        _logger.LogError(Exception, Exception.Message);
    }

    [Route("/error-development")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public IActionResult HandleError_InDevelopment([FromServices] IHostEnvironment host)
    {
        LogException();

        if (!host.IsDevelopment())
            return NotFound();

        return Problem(
            statusCode: StatusCodes.Status500InternalServerError,
            type: "[ErrorController] Error",
            detail: Exception?.StackTrace,
            title: Exception?.Message
        );
    }

    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public IActionResult HandleError_InProduction()
    {
        LogException();

        return Problem();
    }
}