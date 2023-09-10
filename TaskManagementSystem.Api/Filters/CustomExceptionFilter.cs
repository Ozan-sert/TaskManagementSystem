using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManagementSystem.Api.Exceptions;

namespace TaskManagementSystem.Api.Filters;

public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        // Handle the exception here
        if (context.Exception is NotFoundException)
        {
            // Handle the NotFoundException
            context.Result = new NotFoundObjectResult(new
            {
                
                message = context.Exception.Message
            });
        }
        else if (context.Exception is ValidationException validationException)
        {
            var errorMessages = validationException.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            
            // Handle ValidationException (Custom Response)
            context.Result = new BadRequestObjectResult(new
            {
              
                message = "One or more validation errors occurred.",
                errors = errorMessages.ToArray().Select(errorMessage => new { errorMessage })
            });
         
        }
        else if (context.Exception is InvalidOperationException)
        {
            // Handle the InvalidOperationException
            context.Result = new BadRequestObjectResult(new
            {
                error = "Invalid operation.",
                message = context.Exception.Message
            });
        }
        else
        {
            // Handle other exceptions (e.g., return a generic error response)
            context.Result = new ObjectResult(new
            {
                error = "An unhandled exception occurred.",
                message = context.Exception.Message
            })
            {
                StatusCode = (int)System.Net.HttpStatusCode.InternalServerError
            };
        }

        // Mark the exception as handled to prevent further processing
        context.ExceptionHandled = true;
    }
}
