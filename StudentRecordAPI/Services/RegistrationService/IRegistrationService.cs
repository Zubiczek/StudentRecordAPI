using StudentRecordAPI.Models.AddDTO;
using System.Threading.Tasks;

namespace StudentRecordAPI.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Task<string> CreateNewUser(NewUserDTO newuser, string role);
    }
}
