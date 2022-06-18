using Microsoft.AspNetCore.Builder;
using StudentRecordAPI.ExceptionsMiddleware;

namespace StudentRecordAPI.ServiceExtensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
