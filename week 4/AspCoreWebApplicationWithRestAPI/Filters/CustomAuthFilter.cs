﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspCoreWebApplicationWithRestAPI.Filters
{
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            if (!headers.TryGetValue("Authorization", out var authHeader))
            {
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
                return;
            }

            if (!authHeader.ToString().Contains("Bearer "))
            {
                context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
