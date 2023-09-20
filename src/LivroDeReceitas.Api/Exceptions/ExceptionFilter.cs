using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace LivroDeReceitas.Api.Exceptions;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseException)
        {
            ThrowBaseException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowBaseException(ExceptionContext context)
    {
        if (context.Exception is ValidatorErrors)
        {
            ThrowValidatorsErrors(context);
        }
    }

    private void ThrowValidatorsErrors(ExceptionContext context)
    {
        var errors = context.Exception as ValidatorErrors; 

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(errors!.MessageErrors);
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult("Erro desconhecido");
    }
}
