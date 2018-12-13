
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BOL.Validations
{
    public class UniquePasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                //Take userId and password of the user parameter
                int userId = (validationContext.ObjectInstance as User).UserId;
                if (value != null)
                {
                    string password = value.ToString();

                    //Invoke method 'getAllUsers' from 'UserService' in 'BLL project' by reflection (not by adding reference!)

                    //1. Load 'BLL' project
                    Assembly assembly = Assembly.LoadFrom(Directory.GetParent(AppContext.BaseDirectory).Parent.FullName + @"\BLL\bin\Debug\BLL.dll");

                    //2. Get 'UserService' type
                    Type userServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicManager"));

                    //3. Get 'GetAllUsers' method
                    MethodInfo getAllUsersMethod = userServiceType.GetMethods().First(m => m.Name.Equals("PasswordUnique"));

                    //4. Invoke this method
                    bool isUnique = Convert.ToBoolean( getAllUsersMethod.Invoke(Activator.CreateInstance(userServiceType), new object[] { password })) ;

                    //The result of this method is bool if exists this password
                    if (isUnique == false)
                    {
                        ErrorMessage = "password must be unique";
                        validationResult = new ValidationResult(ErrorMessageString);
                    }
                }
                else
                {
                    ErrorMessage = "password required";
                    validationResult = new ValidationResult(ErrorMessageString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return validationResult;
        }

    }
}
