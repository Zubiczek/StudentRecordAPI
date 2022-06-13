using Microsoft.Extensions.Logging;
using StudentRecordAPI.Models.Others;
using System;

namespace StudentRecordAPI.Services.ExceptionService
{
    public class ExceptionLogService : IExceptionService
    {
        private readonly ILogger _logger;
        public ExceptionLogService(ILogger<ExceptionLogService> logger)
        {
            _logger = logger;
        }
        public void LogError(LogInformation loginformations)
        {
            string messageinfo = "An error occured on " + DateTime.UtcNow.ToString() + " during request " + loginformations.Request +
                ". Exception Message : " + loginformations.ErrorMessage;
            _logger.LogError(messageinfo);
        }
    }
}
