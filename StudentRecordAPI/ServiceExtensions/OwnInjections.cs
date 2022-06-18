using Microsoft.Extensions.DependencyInjection;
using StudentRecordAPI.Queries.ScheduleQueries;
using StudentRecordAPI.Queries.NoteQueries;
using StudentRecordAPI.Queries.GradeQueries;
using StudentRecordAPI.Queries.ClassQueries;
using StudentRecordAPI.Queries.AttendanceQueries;
using StudentRecordAPI.Services.ExceptionService;
using StudentRecordAPI.Services.LoggedInUserService;
using StudentRecordAPI.Services.LoginService;
using StudentRecordAPI.Services.PasswordService;
using StudentRecordAPI.Services.RegistrationService;
using StudentRecordAPI.Services.TokenService;
using StudentRecordAPI.Services.ValidationService;
using StudentRecordAPI.Services.EmailService;

namespace StudentRecordAPI.ServiceExtensions
{
    public static class OwnInjections
    {
        public static void Add(IServiceCollection services)
        {
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<IEmailService, RegistrationEmailService>();
            services.AddSingleton<IExceptionService, ExceptionLogService>();
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRandomPassword, RandomPassword>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IExceptionService, ExceptionLogService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IValidationService, ModelValidationService>();
            services.AddScoped<IAttendanceGetQueries, AttendanceQueries>();
            services.AddScoped<IAttendancePostQueries, AttendanceQueries>();
            services.AddScoped<IClassGetQueries, ClassQueries>();
            services.AddScoped<IClassPostQueries, ClassQueries>();
            services.AddScoped<IGradeGetQueries, GradeQueries>();
            services.AddScoped<IGradePostQueries, GradeQueries>();
            services.AddScoped<INoteGetQueries, NoteQueries>();
            services.AddScoped<INotePostQueries, NoteQueries>();
            services.AddScoped<IScheduleGetQueries, ScheduleQueries>();
            services.AddScoped<ISchedulePostQueries, ScheduleQueries>();
        }
    }
}
