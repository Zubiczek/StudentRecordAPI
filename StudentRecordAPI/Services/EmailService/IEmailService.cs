using StudentRecordAPI.Services.EmailService.EmailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmail(string email, string token);
    }
}
