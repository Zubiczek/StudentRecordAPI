using System;

namespace StudentRecordAPI.Services.PasswordService
{
    public interface IRandomPassword
    {
        string Generate();
    }
}
