using MediatR;
using StudentRecordAPI.Services.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.UserFeatures.Commands
{
    public class LogOutCommandHandler : IRequestHandler<LogOutCommand, Unit>
    {
        private readonly ILoginService _loginService;
        public LogOutCommandHandler(ILoginService loginService)
        {
            _loginService = loginService ?? throw new ArgumentNullException();
        }
        public async Task<Unit> Handle(LogOutCommand command, CancellationToken cancellationToken)
        {
            await _loginService.LogOut();
            return Unit.Value;
        }
    }
}
