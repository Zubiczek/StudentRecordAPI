using MediatR;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.UserFeatures.Commands
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, TokenOutput>
    {
        private readonly ILoginService _loginService;
        public LogInCommandHandler(ILoginService loginService)
        {
            _loginService = loginService ?? throw new ArgumentNullException();
        }
        public async Task<TokenOutput> Handle(LogInCommand command, CancellationToken cancellationToken)
        {
            return await _loginService.LogIn(command.logindata);
        }
    }
}
