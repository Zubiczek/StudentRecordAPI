using StudentRecordAPI.Models.Others;

namespace StudentRecordAPI.Services.ExceptionService
{
    public interface IExceptionService
    {
        void LogError(LogInformation loginformations);
    }
}
