using System;
using System.Threading.Tasks;
using ELearningApp.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApp.Api.Extensions
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Instance = $"urn:elearningapp:{Guid.NewGuid()}"
            };

            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Detail = exception.Message;
                problemDetails.Title = Constants.InternalServerError;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.WriteJson(problemDetails);
            }
        }
    }
}