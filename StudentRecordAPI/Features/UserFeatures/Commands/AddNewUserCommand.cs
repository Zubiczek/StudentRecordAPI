using MediatR;
using StudentRecordAPI.Models.AddDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.UserFeatures.Commands
{
    public class AddNewUserCommand : IRequest<string>
    {
        public NewUserDTO newuser { get; set; }
        public string role { get; set; }
        public AddNewUserCommand(NewUserDTO newuser, string role)
        {
            this.newuser = newuser;
            this.role = role;
        }
    }
}
