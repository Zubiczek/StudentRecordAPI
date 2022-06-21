using Microsoft.Extensions.DependencyInjection;
using StudentRecordAPI.Services.ValidationService;
using System;

namespace StudentRecordAPI.UnitTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IValidationService, ModelValidationService>();
        }
    }
}
