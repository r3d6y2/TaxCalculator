using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaxCalculator.Infrastructure.Api.Filters;

public class ExceptionHandlerFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Result = new ContentResult
        {
            Content = context.Exception.Message,
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}