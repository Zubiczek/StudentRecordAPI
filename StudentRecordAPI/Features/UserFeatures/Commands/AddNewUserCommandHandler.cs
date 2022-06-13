using MediatR;
using StudentRecordAPI.Services.RegistrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.UserFeatures.Commands
{
    public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, string>
    {
        private readonly IRegistrationService _registrationService;
        public AddNewUserCommandHandler(IRegistrationService registrationService)
        {
            _registrationService = registrationService ?? throw new ArgumentNullException();
        }
        public async Task<string> Handle(AddNewUserCommand command, CancellationToken cancellationToken)
        {
            string userid = await _registrationService.CreateNewUser(command.newuser, command.role);
            return userid;
        }
    }
}
