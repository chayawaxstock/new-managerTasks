﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BOL.Validations
{
    class UniqueProjectNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                //Take userId and ProjectName of the user parameter
                int projectId = (validationContext.ObjectInstance as Project).ProjectId;
                string projectName = value.ToString();

                //Invoke method 'GetAllProjects' from 'LogicProjects' in 'BLL project' by reflection (not by adding reference!)

                //1. Load 'BLL' project
                Assembly assembly = Assembly.LoadFrom(Directory.GetParent(AppContext.BaseDirectory).Parent.FullName + @"\BLL\bin\Debug\BLL.dll");


                //2. Get 'UserService' type
                Type userServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicProjects"));

                //3. Get 'GetAllUsers' method
                MethodInfo getAllProjectsMethod = userServiceType.GetMethods().First(m => m.Name.Equals("GetAllProjects"));

                //4. Invoke this method
                List<Project> projects = getAllProjectsMethod.Invoke(Activator.CreateInstance(userServiceType), new object[] { }) as List<Project>;

                //The result of this method is list of users

                if (projects == null)
                    return validationResult;
                bool isUnique = projects.Any(project => project.ProjectName.Equals(projectName) && project.ProjectId != projectId) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "project name must be unique";
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
