using StudentRecordAPI.Models.AddDTO;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.UserQueries
{
    public interface IRegisterQueries
    {
        Task CreateNewUser(NewUserDTO newuser, string role);
    }
}
