using MediatR;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;

namespace StudentRecordAPI.Features.UserFeatures.Commands
{
    public class LogInCommand : IRequest<TokenOutput>
    {
        public LoginDTO logindata { get; set; }
        public LogInCommand(LoginDTO logindata)
        {
            this.logindata = logindata;
        }
    }
}
