using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.ExceptionService;
using System;
using System.Threading.Tasks;

namespace StudentRecordAPI.ExceptionsMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly IExceptionService _exceptionService;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException();
        }
        public async Task InvokeAsync(HttpContext httpcontext, IExceptionService exceptionService)
        {
            try
            {
                await _next(httpcontext);
            }
            catch(HttpResponseException ex)
            {
                await HandleExceptionAsync(httpcontext, ex.StatusCode, ex.Message);
            }
            catch(Exception ex)
            {
                exceptionService.LogError(new LogInformation() {
                    Request = httpcontext.Request.GetEncodedUrl(),
                    ErrorMessage = ex.Message
                });
                await HandleExceptionAsync(httpcontext, 500, ex.Message);
            }
        }
        private async Task HandleExceptionAsync(HttpContext httpcontext, int statuscode, string errormessage)
        {
            httpcontext.Response.ContentType = "application/json";
            httpcontext.Response.StatusCode = statuscode;
            await httpcontext.Response.WriteAsync(
                new ErrorDetails(statuscode, errormessage).ToString()
                );
        }
    }
}
