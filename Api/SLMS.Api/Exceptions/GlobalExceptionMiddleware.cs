using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace SLMS.Api.Exceptions
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new ProblemDetails();
            switch (exception)
            {
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    response.Title = "Resource Not Found";
                    response.Detail = exception.Message;
                    break;
                case Application.Exceptions.ValidationException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    response.Title = "Validation Error";
                    response.Detail = exception.Message;
                    break;

                case ConflictException:
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    response.Title = "Conflict";
                    response.Detail = exception.Message;
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Title = "Server Error";
                    response.Detail = "An unexpected error occurred.";
                    break;
            }
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}