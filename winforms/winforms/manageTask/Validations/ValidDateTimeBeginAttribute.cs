using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace manageTask.Validations
{
    public class ValidDateTimeBeginAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            if (DateTime.Parse(value.ToString()) >= DateTime.Now)
                return null;
            return new ValidationResult("date begin project less than today",new List<string>() { "DateBegin"});
        }

    }
}
