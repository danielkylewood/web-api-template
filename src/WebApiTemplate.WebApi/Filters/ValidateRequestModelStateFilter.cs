﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiTemplate.WebApi.Models;
using BadRequestObjectResult = Microsoft.AspNetCore.Mvc.BadRequestObjectResult;

namespace WebApiTemplate.WebApi.Filters
{
    public class ValidateRequestModelStateFilter : IActionFilter
    {
        private const string RequestInvalidErrorType = "request_invalid";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext == null) throw new ArgumentNullException(nameof(context));

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(
                    new ValidationError(RequestInvalidErrorType, new[] { "request_model_invalid" })
                );
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
