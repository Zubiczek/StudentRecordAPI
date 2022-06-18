using MediatR;
using StudentRecordAPI.Models.Others;

namespace StudentRecordAPI.Features.UserFeatures.Commands
{
    public class RefreshSessionCommand : IRequest<TokenOutput>
    {
        public string refreshtoken { get; set; }
        public RefreshSessionCommand(string refreshtoken)
        {
            this.refreshtoken = refreshtoken;
        }
    }
}
