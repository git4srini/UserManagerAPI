using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManager.API.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var errorDetails = new ProblemDetails()
            {
                Instance = "usermanager.api.error"
            };

            if (context.Exception is ArgumentNullException || context.Exception is ArgumentException)
            {
                errorDetails.Status = 400;
                errorDetails.Title = "Input is invalid!";
                errorDetails.Detail = context.Exception.Message;
                errorDetails.Type = "Input";
            }
            else
            {
                errorDetails.Status = 500;
                errorDetails.Title = "An unexpected error occured in the system. Please contact support!";
                errorDetails.Detail = context.Exception.Message;
                errorDetails.Type = "Unknown";
            }

            // always return a JSON result
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)errorDetails.Status;
            context.Result = new ObjectResult(errorDetails);

            base.OnException(context);

            return Task.CompletedTask;
        }
    }
}
