using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRecordAPI.Services.ValidationService
{
    public class ModelValidationService : IValidationService
    {
        public (bool, string) Validate(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            if (!Validator.TryValidateObject(model, context, results)) return (false, results[0].ErrorMessage);
            else return (true, null);
        }
    }
}
