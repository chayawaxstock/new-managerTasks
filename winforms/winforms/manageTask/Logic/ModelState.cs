using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace manageTask.Logic
{
    public static class ModelState
    {
        public static List<ValidationResult> Results = new List<ValidationResult>();

        /// <summary>
        /// Check if model valid
        /// </summary>
        /// <typeparam name="T">type of model</typeparam>
        /// <param name="model">model</param>
        /// <returns>bool- true if valid, false if not valid</returns>
        public static bool IsValid<T>(T model)
        {
            var validationContext = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(model, validationContext, results, true))
            {
                return true;
            }
            else
            {
                Results = results;
                return false;
            }
        }
    }
}
