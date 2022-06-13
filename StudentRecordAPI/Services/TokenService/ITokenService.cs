using StudentRecordAPI.Database.Entities;
using StudentRecordAPI.Models.Others;
using System;
using System.Threading.Tasks;

namespace StudentRecordAPI.Services.TokenService
{
    public interface ITokenService
    {
        (string, DateTime) CreateAccessToken(UserEntity user);
        Task<string> CreateRefreshToken(string userId);
        Task<TokenOutput> RefreshToken(string refreshtoken);
        Task RemoveRefreshToken(string userid);
    }
}
