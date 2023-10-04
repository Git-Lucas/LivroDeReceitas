using LivroDeReceitas.Domain.Exceptions;
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
        else if (context.Exception is RepositoryErrors)
        {
            ThrowRepositoryErrors(context);
        }
    }

    private void ThrowValidatorsErrors(ExceptionContext context)
    {
        ValidatorErrors? errors = context.Exception as ValidatorErrors;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new
        {
            messageErrors = errors!.MessageErrors
        });
    }

    private void ThrowRepositoryErrors(ExceptionContext context)
    {
        if (context.Exception is InvalidLoginError)
        {
            InvalidLoginError? error = context.Exception as InvalidLoginError;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            if (error != null)
                context.Result = new ObjectResult(new
                {
                    messageError = error.MessageError
                });
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult("Erro desconhecido");
    }
}
