using Application.DTOs.Response;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Presentation.Handlers
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            if(context.Exception is LoginException)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = context.Exception.Message;

            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "Ha ocurrido un error interno.";
            }
            
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(
                new ResponseDto() 
                { 
                    Message = message 
                }
            );
        }

    }
}
