using MediatR;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.TokenService;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.UserFeatures.Commands
{
    public class RefreshSessionCommandHandler : IRequestHandler<RefreshSessionCommand,TokenOutput>
    {
        private readonly ITokenService _tokenService;
        public RefreshSessionCommandHandler(ITokenService tokenService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException();
        }
        public async Task<TokenOutput> Handle(RefreshSessionCommand command, CancellationToken cancellationToken)
        {
            return await _tokenService.RefreshToken(command.refreshtoken);
        }
    }
}
