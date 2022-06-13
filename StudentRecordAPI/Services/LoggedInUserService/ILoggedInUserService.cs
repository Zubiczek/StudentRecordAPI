using System.Threading.Tasks;

namespace StudentRecordAPI.Services.LoggedInUserService
{
    public interface ILoggedInUserService
    {
        string GetUserId();
        Task LogOut();
    }
}
