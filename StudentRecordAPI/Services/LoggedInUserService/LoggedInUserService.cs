using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using StudentRecordAPI.Models.Others;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentRecordAPI.Services.LoggedInUserService
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserId()
        {
            var userid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userid == null) throw new HttpResponseException("Unauthorized!", 401);
            return userid;
        }

        public async Task LogOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}
