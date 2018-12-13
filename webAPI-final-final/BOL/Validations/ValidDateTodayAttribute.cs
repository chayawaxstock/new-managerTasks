using BOL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Validations
{
    class ValidDateTodayAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;

            if (DateTime.Parse(value.ToString())>DateTime.Now.AddMinutes(60))
            {
                ErrorMessage = "date pressent grate than now";
                validationResult = new ValidationResult(ErrorMessageString);
            }

            return validationResult;
        }
    }
}
