using StudentRecordAPI.Services.EmailService.EmailModels;
using System.Threading.Tasks;

namespace StudentRecordAPI.Services.EmailService
{
    public class RegistrationEmailService
    {
        private readonly IMailService _mailService;
        public RegistrationEmailService(IMailService mailService)
        {
            _mailService = mailService;
        }
        public async Task SendEmail(string email, string token)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = email;
            mailRequest.Subject = "wymienksiazke.com - Weryfikacja konta";
            string mailtext = "<div style = 'background-color: #696969; color: white; margin-left: auto; margin-right: auto; width: 100%;'>" +
            "<div style = 'padding-top: 30px; text-align: center;'>" +
                "Witamy, Twoje konto zostało utworzone!" +
            "</div>" +
            "<div style = 'padding-top: 30px; text-align: center;'>" +
                "Poniżej znajduje się hasło do konta. Proszę je zmienić po zalogowaniu!" +
            "</div>" +
            "<div style = 'background-color: #228B22; padding: 10px; width: 100px; margin-left: 42%; margin-top: 30px;'>" +
                "<div style = 'text-align: center; color: white;'>" +
                    token +
                "</div>" +
            "</div>" +
            "<div style = 'background-color: black; text-align: center; margin-top: 20px; color: white;'>" +
                "wymienksiazke.com &copy Wszelkie prawa zastrzeżone!" +
            "</div>" +
            "</div>";
            mailRequest.Body = mailtext;
            await _mailService.SendEmailAsync(mailRequest);
        }
    }
}
