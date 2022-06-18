using System;

namespace StudentRecordAPI.Services.EmailService.EmailModels
{
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public MailSettings()
        {
            Mail = "*************";
            DisplayName = "*************";
            Password = "*************";
            Host = "smtp.gmail.com";
            Port = 587;
        }
    }
}
