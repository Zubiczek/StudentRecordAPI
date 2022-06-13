using System;

namespace StudentRecordAPI.Services.ValidationService
{
    public interface IValidationService
    {
        (bool, string) Validate(object model);
    }
}
