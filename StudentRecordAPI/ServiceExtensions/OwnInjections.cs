using Microsoft.Extensions.DependencyInjection;
using StudentRecordAPI.Queries.ScheduleQueries;
using StudentRecordAPI.Queries.NoteQueries;
using StudentRecordAPI.Queries.GradeQueries;
using StudentRecordAPI.Queries.ClassQueries;
using StudentRecordAPI.Queries.AttendanceQueries;
using StudentRecordAPI.Queries.UserQueries;
using StudentRecordAPI.Services.ExceptionService;
using StudentRecordAPI.Services.LoggedInUserService;
using StudentRecordAPI.Services.LoginService;
using StudentRecordAPI.Services.PasswordService;
using StudentRecordAPI.Services.RegistrationService;
using StudentRecordAPI.Services.TokenService;
using StudentRecordAPI.Services.ValidationService;

namespace StudentRecordAPI.ServiceExtensions
{
    public static class OwnInjections
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRandomPassword, RandomPassword>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IRegisterQueries, UserQueries>();
            services.AddScoped<IExceptionService, ExceptionLogService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IValidationService, ModelValidationService>();
            services.AddScoped<IAttendanceGetQueries, AttendanceQueries>();
            services.AddScoped<IClassGetQueries, ClassQueries>();
            services.AddScoped<IGradeGetQueries, GradeQueries>();
            services.AddScoped<INoteGetQueries, NoteQueries>();
            services.AddScoped<IScheduleGetQueries, ScheduleQueries>();
        }
    }
}
