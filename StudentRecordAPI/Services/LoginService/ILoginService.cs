using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;
using System.Threading.Tasks;

namespace StudentRecordAPI.Services.LoginService
{
    public interface ILoginService
    {
        Task<TokenOutput> LogIn(LoginDTO logindata);
        Task<TokenOutput> RefreshSession();
        Task LogOut();
    }
}
