using System.ComponentModel.DataAnnotations;

namespace BOL.Validations
{
    public class ConfirmPasswordAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            if (value == null)
            {
                return new ValidationResult("confirm password is required");
            }
            string password = (validationContext.ObjectInstance as User).Password;
            if(password!=null)

            if (value.Equals(password))
                return null;
            return new ValidationResult("confirm password not match to password");
        }
    }
}
