using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace AspCoreWebApplicationWithRestAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log the exception to a file in the app root
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "errors.log");
            File.AppendAllText(logPath,
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} – {context.Exception.Message}{Environment.NewLine}");

            // Return a 500 response
            context.Result = new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}
