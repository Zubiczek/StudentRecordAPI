using StudentRecordAPI.Services.EmailService.EmailModels;
using System.Threading.Tasks;

namespace StudentRecordAPI.Services.EmailService
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailrequest);
    }
}
