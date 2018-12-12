# Task Managmant

## Using this technologies:

* MySql
* Web api
* PHP
* WinForm
* Angular
* windows service

## Authors

* **Chaya Waxstock** - *a depeloper* - (c0556777462@gmail.com)
* **Chana Valder** - *a depeloper* - (chani@gmail.com)

## Description
 
 * [To desciption of the project follow this link](https://github.com/AnnaKarpf/Full-stack-web-development_4578-2/blob/master/12_Web%20api/final%20project.docx)

## Development server

To install the app in your computer you have to:
  1. [Run the `mySql` code](https://github.com/chayawaxstock/finishcourseseldat/blob/master/%D7%A4%D7%A8%D7%95%D7%99%D7%A7%D7%98%20%D7%A1%D7%95%D7%A4%D7%99%20%D7%A1%D7%9C%D7%93%D7%98/%D7%93%D7%98%D7%94%20%D7%91%D7%99%D7%99%D7%A1/database.sql)
      To see some data in the live demo, you should add data to your tabels or
      [Run the data- script code](https://github.com/tamarosenzweig/TaskManagmant/blob/master/mysql-script.md)
      

  2. Run the `back-end` project.(the web api one)  This is the server. Navigate to `http://localhost:12988/`. 
     The app will automatically reload 
     
     
  3.  Run the `php` server by 
        ```sh 
        shift+f6
        ```
        on the index.php page

  4.  Run `ng serve` for a dev server, if you want to run the angular project. Navigate to `http://localhost:4200/`. 
      The app will automatically reload if you change any of the source files.
      shoose which server you want to: the web api or the php one in the `global` page. update it.

  5. Run the winform project, if you want it to be the client.
  
  6. Run the windows service
      * Go to Start, Microsoft Visual Studio 2012, Visual Studio Tools, then Developer Command Prompt for VS2012. (Right click on it and         select Run as administrator).
      * Set path of your Windows Service's .exe file in command prompt (e.g. "C:\Users\USER1\Documents\Visual Studio 
        2012\Projects\WindowsServiceProject1\bin\Debug\").
      * Then run the command: "InstallUtil WindowsServiceProject1.exe". Now your service is successfully installed in your system.
      * Now go to Control Panel, Administrative Tools, then Services and find the service name as your windows service (eg.  
        TestService).
        
        Windows Service is implemented and installed successfully in your system and will send mail daily itself at the time which 
        specified App.Config file. 

      
          *important note: in order to `send email` feature  from the php server(just if you have xampp) in your computer follow this
           instruction:* 
        
        in php.ini file find [mail function] and change
        ```sh
        SMTP=smtp.gmail.com
        smtp_port=587
        sendmail_from = my-gmail-id@gmail.com
        sendmail_path = "\"C:\xampp\sendmail\sendmail.exe\" -t"
        
        ```

        Now Open C:\xampp\sendmail\sendmail.ini. Replace all the existing code in sendmail.ini with following code
        ```sh
        [sendmail]

        smtp_server=smtp.gmail.com
        smtp_port=587
        error_logfile=error.log
        debug_logfile=debug.log
        auth_username=my-gmail-id@gmail.com
        auth_password=my-gmail-password
        force_sender=my-gmail-id@gmail.com
        ``` 

        PS: don't forgot to replace my-gmail-id and my-gmail-password in above code.
        Also remember to restart the server using the XAMMP control panel so the changes take effect.
## Tech

Task Managmant uses a number of extension:

*in php platform we use:*

* [xampp](https://www.apachefriends.org/index.html) - Installers and Downloads for Apache Friends!

*in web api platform we use:*
   
* from [Nuget](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Cors/) we use the Microsoft.AspNet.WebApi.Cors
* from [Nuget](https://www.nuget.org/packages/MySql.Data/) we use the MySql.Data

*in angular platform we use:*
    
  * [Angular CLI](https://github.com/angular/angular-cli) version 7.0.4.
        
    * [Angular kendo](https://www.telerik.com/kendo-angular-ui/) Kendo UI for Angular 
        
    * [Sweet Alert](https://sweetalert2.github.io/) beatifull java script pop up   

*in winform platform we use:* 

* [Telerik](https://docs.telerik.com/devtools/winforms/introduction) Performance you demand, UI you can't believe

## System diagram:
![picture](step1.png)

***
## Web api

### Models
* User:

    * UserId - int, auto increament,primary key
    * UserName - string - minLength: 2, maxLength:15, reqiered,unique
    * Email - string -  reqiered ,pattern, unique
    * Password - string - minLength: 8, maxLength:10, reqiered, unique
    * Ip- string
    * NumHoursWork- int between 6-12
    * ManagerId - int
    * DepartmentId - int, required
    * Navigation  properties:
        * Department - `Department` type
        * Manager - `User` type
        * ProjectsWorkers- `ProjectsWorkers` type

* Project:

    * ProjectId - int, auto increament,primary key
    * ProjectName - string - minLength: 2, maxLength:15, reqiered
    * TotalHours - int, required
    * StartDate - dateTime, required
    * endDate - dateTime, required
    * Customer - int, required
    * IsFinish- bool 
    * ManagerId - int, required 
    * Navigation  properties:
        * Customer - `Customer` type
        * List<HoursForDepartment> - `HoursForDepartment` type

* DepartmentHours:

    * DepartmentHoursId - int, auto increament,primary key
    * ProjectId - int
    * DepartmentId -int
    * numHours -int
     * Navigation  properties:
        * Project - `Project` type
        * Department - `Department` type 
        * List<ProjectWorker> `ProjectWorker` type

* ProjectWorker:

    * WorkerHours - int, auto increament,primary key
    * ProjectId - int
    * WorkerId -int
    * numHours -int
     * Navigation  properties:
        * Project - `Project` type
        * Worker - `User` type

* PresenceHours:

    * PresenceHours - int, auto increament,primary key
    * ProjectId - int
    * WorkerId -int
    * TimeBegin- dateTime
    * TimeEnd- dateTime
    * SumHoursDay -int
     * Navigation  properties:
        * Project - `Project` type
        * Worker - `User` type       

* Department:

    * DepartmentId - int, auto increament,primary key
    * DepartmentName - string - minLength: 2, maxLength:15, reqiered 
 
### Help Models

* Email:

    * Subject - string
    * Body - string , reqiered 

* Login:

     * Email - string -  reqiered ,pattern
     * Password - string - minLength: 8, maxLength:20, reqiered
     * Ip- string
     

### Controllers

* User controller:

     * Post- Login - sign in to the system    
     requierd data: a `Login` object
     If the user is valid - we will check his status and navigate him to the currect main page, else a suitable message will be send to      him.

     * Get- GetAllUsers- get all the workers in this company.
     
     * Post- Add user - add a new user    
      requierd data: a `User` object
      If the user details is valid - we will add the user to the UsersList, and return true, Else - we will return a matching                 error
     * Post- Edit user- edit worker's details 
      requierd data: a `User` object
      If the update was successful - we will return true, else a suitable message will be send to him.
     * Delete- Delete user- the manager can delete worker
      requierd data:`user id` 
      If the delete prompt was successful - we will return true, else a suitable message will be send to him.
     * Put- Edit pemission - allow the worker to work in other projects, not in his team leader's group. 
      requierd data:`List<projectWorker>` 
      If the projectWorker details is valid - we will add the projectWorker to the projectWorkersList, and return                             true, Else - we will return a matching error

 * Project Controller:

     * Get- GetAllProjects- get all the projects in this company.
     * Post- Add project - add a new project   
             requierd data: a `Project` object
             If the project details is valid - we will add the project to the ProjectsList, and return true, Else - we will return a matching error
             
     * Post- Edit project- edit project's details 
           requierd data: a `Project` object
           If the update was successful - we will return true, else a suitable message will be send to him.
     * Get- GetProjectsReports-  get all the details that the manager needs to the report. The manager can also filter the report assign to his needs
      and to exporet it into an Excel file,Pdf file.
    * Get- GetWorkersReports-  get all the details that the manager needs to the report. The manager can also filter the report assign to his needs
      and to exporet it into an Excel file,Pdf file.
 

    * Get- GetAllWorkers- get all the workers in this company,that belongs to this team leader.

    * Post- Update hours- the team leader can update (edit add or delete) the workers' hours details.
        every data saved in a suitable list and when `save` button clicked- the server check the lists in 
        the crud function- add user, edit user or delete hours. see details above.


    * Get- GetAllProjects- get all the projects in this company,that belongs to this team leader.
        The team leader can see the status of each project. 

    * Get- GetPresenceStatusPerWorkers- by this function the team leader can see a graph of his workers.   
           requierd data: `teamLeaderId`
              
     * Post- Send Email- send email from the worker to his manager.
         requierd data: `Email` objeat 
       
     * Get- GetAllProjects- get all the projects in this company,that belongs to this worker.
          The worker can see the status of each project. 

     * Get- The worker can see also a graph of his hours done for his projects.
     
# Code of each tier

### DAL
```csharp
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace _00_DAL
{
    public static class DBAccess
    {

        static MySqlConnection Connection = new MySqlConnection(ConfigurationManager.AppSettings["conectionString1"].ToString());

 
        public static int? RunNonQuery(string query)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public static object RunScalar(string query)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    return command.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }

        }

        public static List<T> RunReader<T>(string query, Func<MySqlDataReader, List<T>> func)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    return func(reader);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public static int? RunStore(string nameStore, List<string> conditionValue, List<string> condition)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(nameStore, Connection);
                    command.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < condition.Count; i++)
                    {
                        command.Parameters.AddWithValue(condition[i], conditionValue[i]);
                    }

                    return command.ExecuteNonQuery();
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }


        public static List<T> RunReader<T>(Func<MySqlDataReader, List<T>> func, string nameStore, List<string> conditionValue, List<string> condition)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(nameStore, Connection);
                    command.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < condition.Count; i++)
                    {
                        command.Parameters.AddWithValue(condition[i], conditionValue[i]);
                    }
                    MySqlDataReader reader = command.ExecuteReader();
                    return func(reader);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }
    }
}

```

### BOL
 * Model

```csharp

using BOL.Models;
using BOL.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BOL
{
    public class User
    {
        public User()
        {
            ProjectsWorkers = new List<ProjectWorker>();
            Users = new List<User>();
        }

        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "name must be more than 2 chars"), MaxLength(15, ErrorMessage = "name must be less than 15 chars")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [UniquePassword]
        [MinLength(64), MaxLength(64)]
        public string Password { get; set; }

        [MinLength(64), MaxLength(64)]
        [Required(ErrorMessage = "ConfirmPassword is required")]
        [ConfirmPassword]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [UniqueEmail]
        [EmailAddress]
        public string Email { get; set; }

        public string UserComputer { get; set; } = "";

        [Range(1,12,ErrorMessage = "NumHoursWork betwween 1-12")]
        public decimal NumHoursWork { get; set; } = 9;

        public int? ManagerId { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }

        public DepartmentUser DepartmentUser { get; set; }
        public List<ProjectWorker> ProjectsWorkers { get; set; }
        public User Manager { get; set; }
        public List<User> Users { get; set; }

    }
}


using BOL.Models;
using BOL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class Project
    {

        public Project()
        {

            HoursForDepartment = new List<HourForDepartment>();
            PresentsDayUser = new List<PresentDay>();
            ProjectWorkers = new List<ProjectWorker>();
        }

        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "ProjectName grade than 15 chars"), MinLength(2, ErrorMessage = "ProjectName less than 2 chars")]
        [UniqueProjectName]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "CustomerName is required")]
        [MaxLength(15, ErrorMessage = "CustomerName grade than 15 chars"), MinLength(2, ErrorMessage = "CustomerName less than 2 chars")]
        public string CustomerName { get; set; }

        [Required]
        [Range(2, int.MaxValue, ErrorMessage = "numHourForProject not grate than 2")]
        public decimal NumHourForProject { get; set; }


        [Required(ErrorMessage = "DateBegin is required")]
        [ValidDateTimeBegin]
        public DateTime DateBegin { get; set; }


        [Required(ErrorMessage = "DateEnd is required")]
        [ValidDateTimeEnd]
        public DateTime DateEnd { get; set; }

        public bool IsFinish { get; set; } = false;
        [DefaultValue(1)]
        public int IdManager { get; set; }

        public User Manager { get; set; }
        public List<HourForDepartment> HoursForDepartment { get; set; }

        public List<PresentDay> PresentsDayUser { get; set; }

        public List<ProjectWorker> ProjectWorkers { get; set; }

    }
}


using System.ComponentModel.DataAnnotations;

namespace BOL.Models
{
    public class ProjectWorker
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int UserId { get; set; }

        public decimal HoursForProject { get; set; }

        public bool IsActive { get; set; } = true;

        public Project Project { get; set; }

        public User User { get; set; }

        public decimal SumHoursDone { get; set; }

        public decimal MadePercent { get; set; }

        public double DaysLeft  { get; set; }
    }
}


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BOL.HelpModel;

namespace BOL.Models
{
    public class HourForDepartment
    {

        [Required(ErrorMessage = "ProjectId is required")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Sum hours must be more than 0 hours")]
        public int SumHours { get; set; }

        public Project Project { get; set; }

        public DepartmentUser DepartmentUser { get; set; }

        public List<ReportProject> WorkersInDepartment { get; set; }
    }
}


using BOL.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace BOL.Models
{
    public class PresentDay
    {
        public int PresentDayId { get; set; }

        [ValidDateToday]
        public DateTime TimeBegin { get; set; }

        [ValidDateToday]
        public DateTime TimeEnd { get; set; }

        public decimal SumHoursDay { get; set; }

        [Required(ErrorMessage = "UserId is Required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "ProjectId is Required")]
        public int ProjectId { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }

    }
}

using System.Collections.Generic;

namespace BOL.Models
{
    public class DepartmentUser
    {
        public DepartmentUser()
        {
            HourForDepartments = new List<HourForDepartment>();
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string Department { get; set; }
        public List<HourForDepartment> HourForDepartments { get; set; }
        public List<User> Users { get; set; }

    }
}

```

 * Help Model
```csharp

using System.ComponentModel.DataAnnotations;


namespace BOL.HelpModel
{
   public class LoginUser
    {
        [Required]
        [MinLength(64),MaxLength(64)]
        public string Password { get; set; }
        [Required]
        [MinLength(2), MaxLength(15)]
        public string UserName { get; set; }
        public string Ip { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BOL.HelpModel
{
    public class ReportProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal TotalHours { get; set; }
        public decimal SumHoursDo { get; set; }
        public decimal PrecentsDone { get; set; }
        public int Daysleft { get; set; }
        public bool IsFinish { get; set; }
        public string TeamLeader { get; set; }
        public List<ReportProject> Items { get; set; } = new List<ReportProject>();
    }
}


using System.Collections.Generic;

namespace BOL.HelpModel
{
    public  class ReportWorker
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalHours { get; set; }
        public decimal SumHoursDoMonth { get; set; }
        public decimal SumHoursDo { get; set; }
        public decimal PrecentsDone { get; set; }
        public string TeamLeader { get; set; }
        public List<ReportWorker> Items { get; set; } = new List<ReportWorker>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace BOL.HelpModel
{
    public  class SendEmail
    {
        public string Subject { get; set; }

        [Required(ErrorMessage ="body of email required")]
        [MinLength(2,ErrorMessage ="body contain less than two charecters")]
        public string Body { get; set; }
    }
}


namespace BOL.HelpModel
{
    public class SendEmailEndProject
    {
        public string UserName { get; set; }
        public string EmailUser { get; set; }
        public string nameProject { get; set; }
        public string userNameManager { get; set; }
        public string EmailManager { get; set; }
        public decimal HourDo { get; set; }
        public decimal hoursForProject { get; set; }
        public decimal stayToDo { get; set; }
    }
}


namespace BOL.HelpModel
{
    public  class SumHoursDoneUser
    {
        public string Label { get; set; }
        public decimal Data { get; set; }
    }
}

```

 * Validation
```csharp
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BOL.Validations
{
    class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                //Take userId and email of the user parameter
                int userId = (validationContext.ObjectInstance as User).UserId;
                string email = value.ToString();

                //Invoke method 'getAllUsers' from 'UserService' in 'BLL project' by reflection (not by adding reference!)

                //1. Load 'BLL' project
                Assembly assembly = Assembly.LoadFrom(Directory.GetParent(AppContext.BaseDirectory).Parent.FullName + @"\BLL\bin\Debug\BLL.dll");

                //2. Get 'UserService' type
                Type userServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicManager"));

                //3. Get 'GetAllUsers' method
                MethodInfo getAllUsersMethod = userServiceType.GetMethods().First(m => m.Name.Equals("GetAllUsers"));

                //4. Invoke this method
                List<User> users = getAllUsersMethod.Invoke(Activator.CreateInstance(userServiceType), new object[] { }) as List<User>;

                //The result of this method is list of users

                //check if email of the user parameter is unique
                bool isUnique = users.Any(user => user.Email.Equals(email) && user.UserId != userId) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "email nust be unique";
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


using System;
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


using System;
using System.ComponentModel.DataAnnotations;

namespace BOL.Validations
{
    public class ValidDateTimeBeginAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;

            if (DateTime.Parse(value.ToString()).Date >= (DateTime.Parse(DateTime.Now.ToString()).Date))
                return null;
            return new ValidationResult("date begin project less than today");
        }

    }
}


using System;
using System.ComponentModel.DataAnnotations;

namespace BOL.Validations
{
    class ValidDateTimeEndAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;

            //Take userId and email of the user parameter
            DateTime dateBegin = (validationContext.ObjectInstance as Project).DateBegin;

            if (dateBegin >= DateTime.Parse(value.ToString()))
            {
                ErrorMessage = "date end project grate than date begin project";
                validationResult = new ValidationResult(ErrorMessageString);
            }

            return validationResult;
        }

    }
}


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

```
  * Convertors
```csharp
using BOL.Models;
using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertDepartment
    {

        public static DepartmentUser convertDBtoDepartment(MySqlDataReader readerRow)
        {
            return new DepartmentUser()
            {
                Id = readerRow.GetInt32(0),
                Department = readerRow.GetString(1)
            };
        }


        public static HourForDepartment ConvertToHoursDepartmentProject(MySqlDataReader readerRow)
        {
            return new HourForDepartment()
            {
                ProjectId = readerRow.GetInt32(0),
                DepartmentId = readerRow.GetInt32(1),
                SumHours = readerRow.GetInt32(2),
                DepartmentUser = new DepartmentUser()
                {
                    Department = readerRow.GetString(4)
                }
            };
        }
    }
}

using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertorUser
    {

        public static User convertDBtoUserWithManager(MySqlDataReader readerRow)
        {
            return new User()
            {
                UserId = readerRow.GetInt32(0),
                UserName = readerRow.GetString(1),
                UserComputer = readerRow.IsDBNull(2) ? "" : readerRow.GetString(2),
                DepartmentId = readerRow.GetInt32(4),
                Email = readerRow.GetString(5),
                NumHoursWork = readerRow.GetDecimal(6),
                ManagerId = readerRow.IsDBNull(7) ? 0 : readerRow.GetInt32(7),
                DepartmentUser = new Models.DepartmentUser()
                {
                    Id = readerRow.GetInt32(8),
                    Department = readerRow.GetString(9)
                }
               ,
                Manager = new User()
                {
                    UserId = readerRow.IsDBNull(10) ? 0 : readerRow.GetInt32(10),
                    UserName = readerRow.IsDBNull(11) ? string.Empty : readerRow.GetString(11),
                    Email = readerRow.IsDBNull(15) ? string.Empty : readerRow.GetString(15)
                }
            };
        }


        public static User convertDBtoUser(MySqlDataReader readerRow)
        {
            return new User()
            {
                UserId = readerRow.GetInt32(0),
                UserName = readerRow.GetString(1),
                UserComputer = readerRow.IsDBNull(2) ? "" : readerRow.GetString(2),
                DepartmentId = readerRow.GetInt32(4),
                Email = readerRow.GetString(5),
                NumHoursWork = readerRow.GetDecimal(6),
                ManagerId = readerRow.IsDBNull(7) ? 0 : readerRow.GetInt32(7),
            };
        }

        public static User convertDBtoUserWithDepartment(MySqlDataReader readerRow)
        {
            return new User()
            {
                UserId = readerRow.GetInt32(0),
                UserName = readerRow.GetString(1),
                UserComputer = readerRow.IsDBNull(2) ? "" : readerRow.GetString(2),
                Password = readerRow.GetString(3),
                DepartmentId = readerRow.GetInt32(4),
                Email = readerRow.GetString(5),
                NumHoursWork = readerRow.GetDecimal(6),
                ManagerId = readerRow.IsDBNull(7) ? 0 : readerRow.GetInt32(7),
                DepartmentUser = new Models.DepartmentUser()
                {
                    Id = readerRow.GetInt32(8),
                    Department = readerRow.GetString(9)
                }
            };
        }

        public static User convertDBtoNameUser(MySqlDataReader readerRow)
        {
            return new User()
            {
                UserId = readerRow.GetInt32(0),
                UserName = readerRow.GetString(1),
            };
        }
    }
}

using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertProject
    {
        public static Project convertDBtoProjectsWithManager(MySqlDataReader readerRow)
        {
            return new Project()
            {
                ProjectId = readerRow.GetInt32(0),
                NumHourForProject = readerRow.GetDecimal(1),
                ProjectName = readerRow.GetString(2),
                DateBegin = readerRow.GetMySqlDateTime(3).GetDateTime(),
                DateEnd = readerRow.GetMySqlDateTime(4).GetDateTime(),
                IsFinish = readerRow.GetBoolean(5),
                CustomerName = readerRow.GetString(6),
                IdManager = readerRow.GetInt32(7),
                Manager = new User()
                {
                    UserId = readerRow.GetInt32(8),
                    UserName = readerRow.GetString(9),
                    UserComputer = readerRow.IsDBNull(10) ? "" : readerRow.GetString(10),
                    DepartmentId = readerRow.GetInt32(12),
                    Email = readerRow.GetString(13),
                    NumHoursWork = readerRow.GetDecimal(14),
                    ManagerId = readerRow.IsDBNull(15) ? 0 : readerRow.GetInt32(15)
                }
            };


        }

        public static Project convertDBtoProjects(MySqlDataReader readerRow)
        {
            return new Project()
            {
                ProjectId = readerRow.GetInt32(0),
                NumHourForProject = readerRow.GetDecimal(1),
                ProjectName = readerRow.GetString(2),
                DateBegin = readerRow.GetMySqlDateTime(3).GetDateTime(),
                DateEnd = readerRow.GetMySqlDateTime(4).GetDateTime(),
                IsFinish = readerRow.GetBoolean(5),
                CustomerName = readerRow.GetString(6),
                IdManager = readerRow.IsDBNull(7) ? 0 : readerRow.GetInt32(7),
            };
        }
    }
}

using BOL.Models;
using MySql.Data.MySqlClient;
using System;

namespace BOL.Convertors
{
    public class ConvertProjectWorker
    {
        public static ProjectWorker convertDBtoProjectWorkersWithProjectAndUser(MySqlDataReader readerRow)
        {
            return new ProjectWorker()
            {
                ProjectId = readerRow.GetInt32(0),
                HoursForProject = readerRow.IsDBNull(9) ? 0 : readerRow.GetDecimal(9),
                UserId = readerRow.GetInt32(10),
                User = new User()
                {
                    UserId = readerRow.GetInt32(10),
                    UserName = readerRow.GetString(13),
                    UserComputer = readerRow.IsDBNull(14) ? "" : readerRow.GetString(14),

                    DepartmentId = readerRow.GetInt32(16),
                    Email = readerRow.GetString(17),
                    NumHoursWork = readerRow.GetDecimal(18),
                    ManagerId = readerRow.IsDBNull(19) ? 0 : readerRow.GetInt32(19),
                },
                Project = new Project()
                {
                    ProjectId = readerRow.GetInt32(0),
                    NumHourForProject = readerRow.GetDecimal(1),
                    ProjectName = readerRow.GetString(2),
                    DateBegin = readerRow.GetMySqlDateTime(3).GetDateTime(),
                    DateEnd = readerRow.GetMySqlDateTime(4).GetDateTime(),
                    IsFinish = readerRow.GetBoolean(5),
                    CustomerName = readerRow.GetString(6),
                    IdManager = readerRow.GetInt32(7),
                }
            };
        }

        public static ProjectWorker convertDBtoProjectWorkersWithProjectAndUserShort(MySqlDataReader readerRow)
        {
            return new ProjectWorker()
            {
                ProjectId = readerRow.GetInt32(0),
                UserId = readerRow.GetInt32(1),
                HoursForProject = readerRow.IsDBNull(2) ? 0 : readerRow.GetDecimal(2),
                Project = new Project()
                {
                    ProjectName = readerRow.GetString(3),
                },
                User = new User()
                {
                    UserName = readerRow.GetString(4),
                }

            };

        }

        public static ProjectWorker convertDBtoProjectWorkersWithProject(MySqlDataReader readerRow)
        {
            return new ProjectWorker()
            {
                ProjectId = readerRow.GetInt32(0),
                HoursForProject = readerRow.IsDBNull(1) ? 0 : readerRow.GetDecimal(1),
                UserId = readerRow.GetInt32(2),
                SumHoursDone = readerRow.IsDBNull(12) ? 0 : readerRow.GetDecimal(12),
                DaysLeft = (readerRow.GetMySqlDateTime(8).GetDateTime() - DateTime.Now).TotalDays,
                MadePercent = readerRow.IsDBNull(12) || readerRow.IsDBNull(1) || readerRow.GetDecimal(1) == 0 ? 0 : readerRow.GetDecimal(12) / readerRow.GetDecimal(1) * 100,
                Project = new Project()
                {
                    ProjectId = readerRow.GetInt32(4),
                    NumHourForProject = readerRow.GetDecimal(5),
                    ProjectName = readerRow.GetString(6),
                    DateBegin = readerRow.GetMySqlDateTime(7).GetDateTime(),
                    DateEnd = readerRow.GetMySqlDateTime(8).GetDateTime(),
                    IsFinish = readerRow.GetBoolean(9),
                    CustomerName = readerRow.GetString(10),
                    IdManager = readerRow.GetInt32(11),
                }
            };

        }
    }
}

using BOL.HelpModel;
using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertReport
    {
        public static ReportProject ConvertDBtoReport(MySqlDataReader readerRow)
        {
            return new ReportProject()
            {
                Id = readerRow.GetInt32(0),
                TotalHours = readerRow.GetDecimal(1),
                Name = readerRow.GetString(2),
                DateBegin = readerRow.GetDateTime(3),
                DateEnd = readerRow.GetDateTime(4),
                IsFinish = readerRow.GetBoolean(5),
                CustomerName = readerRow.GetString(6),
                TeamLeader = readerRow.GetString(8),
                SumHoursDo = readerRow.IsDBNull(9) ? 0 : readerRow.GetDecimal(9),
                Daysleft = readerRow.GetInt32(10),
                PrecentsDone = readerRow.IsDBNull(11) ? 0 : readerRow.GetDecimal(11)
            };
        }

        public static ReportWorker ConvertDBtoReportWorker(MySqlDataReader readerRow)
        {
            return new ReportWorker()
            {
                Id = readerRow.GetInt32(0),
                Name = readerRow.GetString(1),
                SumHoursDo = readerRow.GetInt32(2),
                TotalHours = readerRow.GetInt32(3)
            };
        }

        public static ReportProject ConvertDBtoDepartment(MySqlDataReader readerRow)
        {
            return new ReportProject()
            {
                Id = readerRow.GetInt32(0),
                Name = readerRow.GetString(1),
                TotalHours = readerRow.IsDBNull(2) ? 0 : readerRow.GetDecimal(2),
                SumHoursDo = readerRow.IsDBNull(3) ? 0 : readerRow.GetDecimal(3),
                PrecentsDone = readerRow.IsDBNull(4) ? 0 : readerRow.GetDecimal(4)
            };
        }

        public static ReportProject ConvertDBtoWorkerInReport(MySqlDataReader readerRow)
        {
            return new ReportProject()
            {
                SumHoursDo = readerRow.IsDBNull(0) ? 0 : readerRow.GetDecimal(0),
                PrecentsDone = readerRow.IsDBNull(1) ? 0 : readerRow.GetDecimal(1),
                TotalHours = readerRow.IsDBNull(2) ? 0 : readerRow.GetDecimal(2),
                Name = readerRow.GetString(5),
                Id = readerRow.GetInt32(4)
            };
        }

        public static ReportWorker ConvertDBtoWorkersReport(MySqlDataReader readerRow)
        {
            return new ReportWorker()
            {
                Year = readerRow.GetInt32(0),
                Month = readerRow.GetInt32(1),
                Name = readerRow.GetString(2),
                TotalHours = readerRow.GetDecimal(3),
                SumHoursDo = readerRow.GetDecimal(4),
                SumHoursDoMonth = readerRow.GetDecimal(5),
                PrecentsDone = readerRow.GetDecimal(3) == 0 ? 0 : readerRow.GetDecimal(5) / readerRow.GetDecimal(3) * 100
            };
        }
    }
}

using BOL.HelpModel;
using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertSendEmail
    {
        public static SendEmailEndProject convertDBtoProjects(MySqlDataReader readerRow)
        {
            return new SendEmailEndProject()
            {
                UserName = readerRow.GetString(0),
                EmailUser = readerRow.GetString(1),
                nameProject = readerRow.GetString(2),
                userNameManager = readerRow.GetString(3),
                EmailManager = readerRow.GetString(4),
                HourDo = readerRow.GetDecimal(5),
                hoursForProject = readerRow.GetDecimal(6),
                stayToDo = readerRow.GetDecimal(7)
            };
        }
    }
}

using BOL.HelpModel;
using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertSumHoursUser
    {
        public static SumHoursDoneUser convertDBtoSumHoursUser(MySqlDataReader readerRow)
        {
            return new SumHoursDoneUser()
            {
                Label = readerRow.IsDBNull(1) ? "" : readerRow.GetString(1),
                Data = readerRow.IsDBNull(0) ? 0 : readerRow.GetDecimal(0)
            };
        }

        public static SumHoursDoneUser convertDBtoSumHoursUser1(MySqlDataReader readerRow)
        {
            return new SumHoursDoneUser()
            {
                Label = readerRow.IsDBNull(3) ? "" : readerRow.GetString(3),
                Data = readerRow.IsDBNull(0) ? 0 : readerRow.GetDecimal(0)
            };
        }
    }
}

```

### BLL
```csharp
using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace BLL
{
    public class BaseLogic
    {
        public static List<string> GetErorList(ICollection<ModelState> values)
        {
            List<string> ErrorList = new List<string>();
            foreach (var item in values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);
            return ErrorList;
        }
    }
}


using _00_DAL;
using BOL;
using BOL.Convertors;
using BOL.HelpModel;
using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;

namespace BLL
{
    public class LogicManager
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List<User> </returns>
        public static List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM user u JOIN department d ON u.departmentUserId=d.id LEFT JOIN user uu ON u.managerId=uu.id ;";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUserWithManager(reader));
                }
                return users;
            };
            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Check if exist user with same password
        /// </summary>
        /// <returns>bool true- exists user , false- no exists</returns>
        public static bool PasswordUnique(string password)
        {
            string query = $"select count(password) from user where user.password='{password}';";
            return Convert.ToInt32(DBAccess.RunScalar(query)) == 0 ? true : false;
        }

        /// <summary>
        /// Get all departments
        /// </summary>
        /// <returns> List<DepartmentUser>- all departments</returns>
        public static List<DepartmentUser> GetAllDepartments()
        {
            string query = $"SELECT * FROM managertasks.department  ";

            Func<MySqlDataReader, List<DepartmentUser>> func = (reader) =>
            {
                List<DepartmentUser> departments = new List<DepartmentUser>();
                while (reader.Read())
                {
                    departments.Add(ConvertDepartment.convertDBtoDepartment(reader));
                }
                return departments;
            };

            return DBAccess.RunReader(query, func);
        }


        /// <summary>
        /// Forgot password-check if userName exists if exists send Email with link to change password
        /// </summary>
        /// <param name="userName">userName</param>
        /// <returns>bool- true if exists false if not found</returns>
        public static bool ForgetPassword(string userName)
        {
            string query = $"SELECT * FROM managertasks.user WHERE userName='{userName}'";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }

                return users;
            };
            List<User> user = DBAccess.RunReader(query, func);
            //Inserts into table requestpassword- userName and idRequest
            if (user.Count > 0)
            {
                query = $" START TRANSACTION;INSERT INTO requestpassword(userName,startDate,endDate) value('{userName}','{DateTime.Now}' '{DateTime.Today.AddDays(1)}');  SELECT max(idRequest) from requestpassword;  commit";
                int result = Convert.ToInt32(DBAccess.RunScalar(query));
                return SendEmail("chany55488@gmail.com", user[0].Email, "change password", $@"<a href='http://localhost:4200/changePassword/{result}'>change password</a>");
            }
            return false;
        }


        /// <summary>
        /// Get users by department
        /// </summary>
        /// <param name="departmentName"> department name</param>
        /// <returns>List<User>-users in this department</returns>
        public static List<User> GetUserByDepartment(string departmentName)
        {
            string query = $"SELECT * FROM managertasks.user JOIN managertasks.department ON user.departmentUserId=department.id WHERE Department='{departmentName}'";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUserWithDepartment(reader));
                }
                return users;
            };
            return DBAccess.RunReader(query, func);
        }


        /// <summary>
        /// Gets the amount of hours they did the worker to a specific team project and project. 
        /// </summary>
        /// <param name="teamleaderId">teamLeaderId</param>
        /// <param name="projectId">projectId</param>
        /// <returns>List<SumHoursDoneUser>sum hours done worker</returns>
        public static List<SumHoursDoneUser> GetSumHoursDoneForUsers(int teamleaderId, int projectId)
        {
            string query = $"SELECT sum(sumHours),u.userName FROM presentday p JOIN user u on u.id= p.id WHERE u.managerId ={teamleaderId} AND projectId={projectId} GROUP BY u.id";

            Func<MySqlDataReader, List<SumHoursDoneUser>> func = (reader) =>
            {
                List<SumHoursDoneUser> users = new List<SumHoursDoneUser>();
                while (reader.Read())
                {
                    users.Add(ConvertSumHoursUser.convertDBtoSumHoursUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets sum of hours a worker has worked on according to his projects
        /// </summary>
        /// <param name="userId">workerId</param>
        /// <returns>List<SumHoursDoneUser>- sum hours worked according project</returns>
        public static List<SumHoursDoneUser> GetHoursForUserProjects(int userId)
        {
            string query = $"SELECT * FROM sumHoursForUserProject WHERE id={userId}";

            Func<MySqlDataReader, List<SumHoursDoneUser>> func = (reader) =>
            {
                List<SumHoursDoneUser> users = new List<SumHoursDoneUser>();
                while (reader.Read())
                {
                    users.Add(ConvertSumHoursUser.convertDBtoSumHoursUser1(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets hour for projects and all projects of worker
        /// </summary>
        /// <param name="userId">workerId</param>
        /// <returns>List<ProjectWorker></returns>
        public static List<ProjectWorker> GetHoursAndProjectForUser(int userId)
        {
            string query = $"SELECT pw.projectId,pw.id,pw.hoursForProject,p.name,u.userName FROM   project p JOIN projectworker pw ON  p.projectId =pw.projectId JOIN user u ON pw.id =u.id WHERE pw.id={userId}";

            Func<MySqlDataReader, List<ProjectWorker>> func = (reader) =>
            {
                List<ProjectWorker> users = new List<ProjectWorker>();
                while (reader.Read())
                {
                    users.Add(ConvertProjectWorker.convertDBtoProjectWorkersWithProjectAndUserShort(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets the amount of hours they did the worker to a specific team project and project. 
        /// </summary>
        /// <param name="teamleaderId">teamLeaderId</param>
        /// <param name="projectId">projectId</param>
        /// <returns>List<SumHoursDoneUser>sum hours done worker</returns>
        public static List<SumHoursDoneUser> GetWorkerHourDoProjects(int teamleaderId, int idProject)
        {
            string query = $"SELECT sum(pd.sumHours),u.userName  FROM user u JOIN projectworker pw ON pw.id = u.id LEFT JOIN presentday pd ON pd.id = u.id WHERE u.managerId = {teamleaderId} AND pw.projectId = {idProject} AND pd.projectId = {idProject} GROUP BY pw.projectId ,pw.id ";

            Func<MySqlDataReader, List<SumHoursDoneUser>> func = (reader) =>
            {
                List<SumHoursDoneUser> sumHoursDoneUser = new List<SumHoursDoneUser>();
                while (reader.Read())
                {
                    sumHoursDoneUser.Add(ConvertSumHoursUser.convertDBtoSumHoursUser(reader));
                }
                return sumHoursDoneUser;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets workers that work in this project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns> List<ProjectWorker>-worker in this project</returns>
        public static List<ProjectWorker> GetUsersBelongProjects(int projectId)
        {
            string query = $"SELECT * FROM project p JOIN projectworker pw ON  p.projectId =pw.projectId JOIN user u ON pw.id =u.id WHERE pw.projectId={projectId} AND pw.isActive=true";
            List<ProjectWorker> projectWorker = new List<ProjectWorker>();
            Func<MySqlDataReader, List<ProjectWorker>> func = (reader) =>
            {
                List<ProjectWorker> projectWorkers = new List<ProjectWorker>();
                while (reader.Read())
                {
                    projectWorkers.Add(ConvertProjectWorker.convertDBtoProjectWorkersWithProjectAndUser(reader));
                }
                return projectWorkers;
            };

            projectWorker = DBAccess.RunReader(query, func);
            if (projectWorker != null)
                foreach (var item in projectWorker)
                {
                    query = $" SELECT sum(sumHours) FROM managertasks.presentday where id ={item.UserId} and projectId ={item.ProjectId}";
                    string result = DBAccess.RunScalar(query).ToString();
                    item.SumHoursDone = result != string.Empty ? decimal.Parse(result.ToString()) : 0;
                }
            return projectWorker;
        }

        /// <summary>
        /// Gets simple workers not- manager, teamLeader
        /// </summary>
        /// <returns>List<User> users -simple workers</returns>
        public static List<User> GetWorkers()
        {
            string query = $"SELECT * FROM managertasks.user JOIN managertasks.department ON user.departmentUserId=department.id WHERE Department NOT IN ('teamLeader','manager')";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets projects of teamLeader
        /// </summary>
        /// <param name="id">teamLeaderId</param>
        /// <returns></returns>
        public static List<Project> GetProjectsManager(int tamLeaderId)
        {
            string query = $"SELECT * FROM managertasks.project  WHERE managerId ={tamLeaderId}";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projectsList = new List<Project>();
                while (reader.Read())
                {
                    projectsList.Add(ConvertProject.convertDBtoProjects(reader));
                }
                return projectsList;
            };

            List<Project> managerProjects = DBAccess.RunReader(query, func);
            managerProjects.ForEach(p =>
            {
                p.HoursForDepartment = LogicProjects.GetHoursDepartmentsProject(p.ProjectId);
            });
            return managerProjects;
        }

        /// <summary>
        /// Gets Worker projects
        /// </summary>
        /// <param name="id">workerId</param>
        /// <returns>List<ProjectWorker>- worker projects</returns>
        public static List<ProjectWorker> GetProjectsUser(int id)
        {
            string query = $"SELECT *,(select sum(sumHours) from presentday pd where pd.id=pw.id and pd.projectId=p.projectId group by id) as sumHoursDone FROM managertasks.projectworker pw join project p on  pw.projectId = p.projectId where pw.id = {id} and p.isFinish=false ";
            Func<MySqlDataReader, List<ProjectWorker>> func = (reader) =>
            {
                List<ProjectWorker> projectsList = new List<ProjectWorker>();
                while (reader.Read())
                {
                    projectsList.Add(ConvertProjectWorker.convertDBtoProjectWorkersWithProject(reader));
                }
                return projectsList;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets user details
        /// </summary>
        /// <param name="id">userId</param>
        /// <returns></returns>
        public static User GetUserDetails(int id)
        {
            string query = $"SELECT * FROM managertasks.user JOIN managertasks.department ON user.departmentUserId=department.id WHERE user.id={id}";
            List<User> users = new List<User>();
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> projectsWorker = new List<User>();
                while (reader.Read())
                {
                    projectsWorker.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return projectsWorker;
            };
            List<User> users1 = DBAccess.RunReader(query, func);
            return users1 != null && users1.Count > 0 ? users1[0] as User : null;
        }

        /// <summary>
        /// Gets user by Password- login
        /// </summary>
        /// <param name="user">user- contain userName and password</param>
        /// <returns>User</returns>
        public static User GetUserDetailsByPassword(LoginUser user)
        {
            string query = $"SELECT * FROM managertasks.user JOIN managertasks.department ON user.departmentUserId=department.id  WHERE password='{user.Password}' AND userName='{user.UserName}'";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUserWithDepartment(reader));
                }
                return users;
            };

            List<User> usersLogin = DBAccess.RunReader(query, func);
            if (usersLogin != null && usersLogin.Count > 0 && user.Ip != null)
            {
                query = $"SET SQL_SAFE_UPDATES=0;    UPDATE `managertasks`.`user`SET`userComputer` = '{user.Ip}' WHERE password = '{user.Password}' ";
                DBAccess.RunNonQuery(query);
                return usersLogin[0];
            }
            if (usersLogin != null && usersLogin.Count > 0)
                return usersLogin[0];
            return null;

        }

        /// <summary>
        /// Remove user
        /// </summary>
        /// <param name="id">userId</param>
        /// <returns></returns>
        public static bool RemoveUser(int id)
        {
            string query = $"DELETE FROM managertasks.user WHERE id={id}";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user">Userv to update</param>
        /// <returns>bool- true if succsess false- if failed </returns>
        public static bool UpdateUser(User user)
        {
            string query;
            query = user.ManagerId == 0 || user.ManagerId == null ? $"SET SQL_SAFE_UPDATES=0;  UPDATE managertasks.user SET userName='{user.UserName}',departmentUserId={user.DepartmentId} ,email='{user.Email}',userComputer='{user.UserComputer}',numHourWork={user.NumHoursWork}  WHERE id={user.UserId} " : $"SET SQL_SAFE_UPDATES=0; UPDATE managertasks.user SET userName='{user.UserName}',departmentUserId={user.DepartmentId} ,managerId={user.ManagerId} ,email='{user.Email}',userComputer='{user.UserComputer}',numHourWork={user.NumHoursWork}  WHERE id={user.UserId} ";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="user">User to add</param>
        /// <returns>bool- true if success to add user false if failed to add user</returns>
        public static bool AddUser(User user)
        {
            string query;
            if (user.ManagerId == 0 || user.ManagerId == null)
                query = $"INSERT INTO `managertasks`.`user`(`userName`,`userComputer`,`password`,`departmentUserId`,`email`,`numHourWork`) VALUES('{user.UserName}','{user.UserComputer}','{user.Password}',{user.DepartmentId},'{user.Email}',{user.NumHoursWork}); ";
            else query = $"INSERT INTO `managertasks`.`user`(`userName`,`userComputer`,`password`,`departmentUserId`,`email`,`numHourWork`,`managerId`) VALUES('{user.UserName}','{user.UserComputer}','{user.Password}',{user.DepartmentId},'{user.Email}',{user.NumHoursWork},{user.ManagerId}); ";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Gets user details by ip
        /// </summary>
        /// <param name="computerUser">ip</param>
        /// <returns></returns>
        public static User GetUserDetailsComputerUser(string computerUser)
        {
            string query = $" SELECT* FROM managertasks.user JOIN managertasks.department ON user.departmentUserId = department.id  WHERE userComputer = '{computerUser}'";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUserWithDepartment(reader));

                }
                return users;
            };

            List<User> usersLogin = DBAccess.RunReader(query, func);
            if (usersLogin != null && usersLogin.Count > 0)
            {
                return usersLogin[0];
            }
            return null;
        }

        /// <summary>
        /// Gets manager user
        /// </summary>
        /// <param name="idUser">userId</param>
        /// <returns></returns>
        public static User GetUserManager(int idUser)
        {
            string query = $" select uu.* from user u join user uu on u.managerId=uu.id where u.id={idUser}";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            List<User> manager = DBAccess.RunReader(query, func);
            if (manager != null && manager.Count > 0)
            {
                return manager[0];
            }
            return null;
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="requestId">requestId of changePassword</param>
        /// <param name="user">User- contain userName and new password</param>
        /// <returns></returns>
        public static bool ChangePassword(int requestId, LoginUser user)
        {
            string query = $"select count(*) from requestpassword where idRequest={requestId} and userName='{user.UserName}' and CURDATE()>";
            int result = Convert.ToInt32(DBAccess.RunScalar(query));
            if (result == 1)
            {
                query = $"SET SQL_SAFE_UPDATES=0;  UPDATE `managertasks`.`user`SET`password` = '{ user.Password }' WHERE `userName` = '{ user.UserName}'";
                return DBAccess.RunNonQuery(query) != null;
            }
            return false;
        }

        /// <summary>
        /// Send Message to Manager-TeamLeader User
        /// </summary>
        /// <param name="idUser">userId</param>
        /// <param name="message">message contain -subject and body of email</param>
        /// <returns></returns>
        public static bool SendMessageToManagers(int idUser, SendEmail message)
        {
            User manager = GetUserManager(idUser);
            User user = GetUserDetails(idUser);
            if (manager == null)
                return false;
            return SendEmail(user.Email, manager.Email, message.Subject, message.Body);
        }

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="emailFrom">from-address email</param>
        /// <param name="emailTo">to- address email</param>
        /// <param name="sub">subject email</param>
        /// <param name="message">body email</param>
        /// <returns>bool true- succses to send email, false- failed to send email</returns>
        public static bool SendEmail(string emailFrom, string emailTo, string sub, string message)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["emailManager"].ToString(),
               ConfigurationManager.AppSettings["emailManagerPassword"].ToString());
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(emailFrom);
            msg.To.Add(new MailAddress(emailTo));
            msg.Subject = sub;
            msg.IsBodyHtml = true;
            msg.Body = string.Format($"<html><head>הודעה שנשלחה</head><body><p>{message}</br></p></body>");
            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

using _00_DAL;
using BOL.Models;

namespace BLL
{
    public class LogicPresentDay
    {

        /// <summary>
        /// Update pressent- date time
        /// </summary>
        /// <param name="present">PresentDay contain- idUser, idProject, dateEnd</param>
        /// <returns>bool true- succsess to update, false- failed to update</returns>
        public static bool UpdatePresent(PresentDay present)
        {
            string dateEnd = present.TimeEnd.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ssss");
            string query = $"set @id=0;select max(presentDayId) into @id from presentday where id = {present.UserId} and projectId ={present.ProjectId}; UPDATE `managertasks`.`presentday`SET`timeEnd` = '{dateEnd}' WHERE presentDayId = @id and id ={present.UserId} and projectId = {present.ProjectId}";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Add pressent
        /// </summary>
        /// <param name="presentDay">presentDay- contain idUser, idProject, dateBegin </param>
        /// <returns></returns>
        public static bool AddPresent(PresentDay presentDay)
        {
            string dateBegin = presentDay.TimeBegin.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ssss");
            string dateEnd = presentDay.TimeEnd.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ssss");
            string query = $"INSERT INTO `managertasks`.`PresentDay`(`timeBegin`,`timeEnd`,`projectId`,`id`) VALUES('{dateBegin}','{dateEnd}',{presentDay.ProjectId},{presentDay.UserId}); ";
            return DBAccess.RunNonQuery(query) == 1;
        }
    }
}

using _00_DAL;
using BOL;
using BOL.Convertors;
using BOL.HelpModel;
using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BLL
{
    public class LogicProjects
    {
        public static int index = 100;

        /// <summary>
        /// Gets all projects
        /// </summary>
        /// <returns>List<Project> all projects</returns>
        public static List<Project> GetAllProjects()
        {
            string query = $"SELECT p.*,u.* FROM managertasks.project p join user u on u.id=p.managerId";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(ConvertProject.convertDBtoProjectsWithManager(reader));
                }
                return projects;
            };
            List<Project> allProjects = DBAccess.RunReader(query, func);
            allProjects.ForEach(p =>
            {
                p.HoursForDepartment = GetHoursDepartmentsProject(p.ProjectId);
            });
            return allProjects;
        }

        /// <summary>
        /// Gets hours and worker for departments project
        /// </summary>
        /// <param name="projectId">idProject</param>
        /// <returns>List<HourForDepartment>-HourForDepartment </returns>
        public static List<HourForDepartment> GetHoursDepartmentsProject(int projectId)
        {
            string query = $"SELECT * FROM managertasks.hourfordepartment h join department d on d.id=h.departmentId where projectId={projectId};";
            Func<MySqlDataReader, List<HourForDepartment>> func = (reader) =>
            {
                List<HourForDepartment> hoursDepartments = new List<HourForDepartment>();
                while (reader.Read())
                {
                    hoursDepartments.Add(ConvertDepartment.ConvertToHoursDepartmentProject(reader));
                }
                return hoursDepartments;
            };
            List<HourForDepartment> departmentsProject = DBAccess.RunReader(query, func);
            departmentsProject.ForEach(h =>
            {
                h.WorkersInDepartment = GetWorkersByDepartmentAndProject(h.DepartmentId, projectId);
            });
            return (departmentsProject.Count() != 0 ? departmentsProject : new List<HourForDepartment>());
        }

        /// <summary>
        /// Gets project details
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project</returns>
        public static Project GetProjectDetails(int projectId)
        {
            string query = $"SELECT * FROM managetasks.project WHERE projectId={projectId}";
            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(ConvertProject.convertDBtoProjects(reader));
                    projects.Last().HoursForDepartment = GetHoursDepartmentsProject(reader.GetInt32(0));
                }
                return projects;
            };

            return (DBAccess.RunReader(query, func).Count() != 0 ? DBAccess.RunReader(query, func)[0] : null);

        }

        /// <summary>
        /// Remove project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>bool true-succsess remove, false-failed remove</returns>
        public static bool RemoveProject(int projectId)
        {
            string query = $"DELETE FROM `managertasks`.`project`WHERE projectId ={projectId}";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="project">project</param>
        /// <returns>bool true-succsess update, false-failed update</returns>
        public static bool UpdateProject(Project project)
        {
            int finish = project.IsFinish ? 1 : 0;
            string query = $"UPDATE managertasks.project SET numHour='{project.NumHourForProject}',name='{project.ProjectName}',dateBegin='{project.DateBegin.ToString("yyyy-MM-dd")}' ,dateEnd='{project.DateEnd.ToString("yyyy-MM-dd")}' ,isFinish=b'{finish}',customerName='{project.CustomerName}'  WHERE projectId={project.ProjectId} ";
            if (DBAccess.RunNonQuery(query) != null)
            {
                foreach (var hoursDepartment in project.HoursForDepartment)
                {
                    if (UpdateHoursDepartmentForProject(hoursDepartment, project.ProjectId) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Update hours for departments project
        /// </summary>
        /// <param name="hourForDepartment">hourForDepartment- contain idDepartment, idProject, numHours</param>
        /// <param name="projectId">bool true-succsess update, false-failed update</param>
        /// <returns></returns>
        public static bool UpdateHoursDepartmentForProject(HourForDepartment hourForDepartment, int projectId)
        {
            string query = $"UPDATE  `managertasks`.`hourfordepartment` set sumHours={hourForDepartment.SumHours}  where departmentId={hourForDepartment.DepartmentId}  and projectId={projectId}";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Update status Project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>bool true-succsess update, false-failed update</returns>
        public static bool UpdateStatusProject(int projectId)
        {
            string query = $"UPDATE managetasks.project SET  isFinish='{true}'  WHERE id={projectId} ";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Add worker to project
        /// </summary>
        /// <param name="projectId">idProject</param>
        /// <param name="workers">List<ProjectWorker> contain list of userId, HoursForProject</param>
        /// <returns>bool true-succsess added, false-failed added</returns>
        public static bool AddWorkerToProject(int projectId, List<ProjectWorker> workers)
        {
            foreach (var item in workers)
            {
                string query = $"INSERT INTO `managertasks`.`projectworker`(`projectId`,`hoursForProject`,`id`)VALUES({ projectId},{item.HoursForProject},{ item.UserId }); ";
                if (DBAccess.RunNonQuery(query) == null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Add project
        /// </summary>
        /// <param name="project">project</param>
        /// <returns>bool true-succsess added, false-failed added</returns>
        public static bool AddProject(Project project)
        {
            string dateBegin = project.DateBegin.ToString("yyyy-MM-dd");
            string dateEnd = project.DateEnd.ToString("yyyy-MM-dd");
            int IsFinish = project.IsFinish ? 1 : 0;

            string query = $"start transaction; INSERT INTO `managertasks`.`project`(`numHour`,`name`,`dateBegin`,`dateEnd`,`isFinish`,`customerName`,`managerId`) VALUES({project.NumHourForProject},'{project.ProjectName}','{dateBegin}','{dateEnd}',{IsFinish},'{project.CustomerName}',{project.IdManager}); ";
            foreach (var item in project.HoursForDepartment)
            {
                query += $" SET @EE=0;SELECT MAX(projectId) FROM project INTO @EE; INSERT INTO `managertasks`.`hourfordepartment`(`projectId`,`departmentId`,`sumHours`)VALUES(@EE,{item.DepartmentId},{item.SumHours});";
            }
            query += " commit;";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        ///Send email day before dead line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void sendEmailDateProjectEnd(object sender, ElapsedEventArgs e)
        {
            Func<MySqlDataReader, List<SendEmailEndProject>> func = (reader) =>
            {
                List<SendEmailEndProject> workerSendEmail = new List<SendEmailEndProject>();
                while (reader.Read())
                {
                    workerSendEmail.Add(ConvertSendEmail.convertDBtoProjects(reader));
                }
                return workerSendEmail;
            };
            List<SendEmailEndProject> workerNotFinish = DBAccess.RunReader(func, "SendEmailEndProject", new List<string>(), new List<string>());
            foreach (var item in workerNotFinish)
            {
                string message = $"Hi {item.UserName}<br/> the project {item.nameProject} the deadline tommorow You did {item.HourDo} from {item.hoursForProject}, You stay to do {item.stayToDo} hours ";
                LogicManager.SendEmail(item.EmailManager, item.EmailUser, "end dead line", message);
            }
            var d = workerNotFinish.GroupBy(p => p.EmailManager);
            foreach (var item in d)
            {
                string message = "";
                item.ToList().ForEach(user =>
                {
                    message += user.UserName + " ";
                });
                LogicManager.SendEmail("c0556777462@gmail.com", item.Key, "end dead line", message);
            }
        }

        /// <summary>
        /// Dead line send email -run task that happen every day
        /// </summary>
        /// <returns></returns>
        public static async Task DeadLineEmail()
        {
            // Set up a timer that triggers every day.
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 60000;

            timer.Elapsed += new ElapsedEventHandler(sendEmailDateProjectEnd);

            string time = ConfigurationManager.AppSettings["deadLineEmailHour"];
            int hour = int.Parse(time.Split(':')[0]);
            int minute = int.Parse(time.Split(':')[1]);

            DateTime currentDateTime = DateTime.Now;
            DateTime dateTimeToStart = currentDateTime.Date + new TimeSpan(hour, minute, 0);
            if (dateTimeToStart < currentDateTime)
                dateTimeToStart = dateTimeToStart.AddDays(1);
            TimeSpan timeout = dateTimeToStart - currentDateTime;
            Thread.Sleep(timeout);
            timer.Start();
        }

        /// <summary>
        /// Create report WorkerReport
        /// </summary>
        /// <param name="viewName">viewName </param>
        /// <returns>List<ReportWorker></returns>
        public static List<ReportWorker> CreateReportsWorker(string viewName)
        {
            Func<MySqlDataReader, List<ReportWorker>> func = (reader) =>
            {
                List<ReportWorker> reportWorker = new List<ReportWorker>();
                while (reader.Read())
                {
                    reportWorker.Add(ConvertReport.ConvertDBtoReportWorker(reader));
                }
                return reportWorker;
            };

            List<ReportWorker> reportWorkers = DBAccess.RunReader(func, "report", new List<string>() { viewName }, new List<string>() { "viewName" });
            reportWorkers.ForEach(r =>
            {
                r.ParentId = 0;
                r.Items = GetReportWorkerDetailsById(r.Id);
            });

            return reportWorkers;
        }

        /// <summary>
        /// Gets report worker details- create report with self reference
        /// </summary>
        /// <param name="idWorker">idUser</param>
        /// <returns>List<ReportWorker>-</returns>
        public static List<ReportWorker> GetReportWorkerDetailsById(int idWorker)
        {
            Func<MySqlDataReader, List<ReportWorker>> func = (reader) =>
            {
                List<ReportWorker> reportWorker = new List<ReportWorker>();
                while (reader.Read())
                {
                    ReportWorker reportWorker1 = ConvertReport.ConvertDBtoWorkersReport(reader);
                    reportWorker1.Id = index++;
                    reportWorker1.ParentId = idWorker;
                    reportWorker.Add(reportWorker1);
                }
                return reportWorker;
            };
            return DBAccess.RunReader(func, "reportWorker", new List<string>() { idWorker.ToString() }, new List<string>() { "idWorker" });

        }

        /// <summary>
        /// Create report WorkerReport
        /// </summary>
        /// <param name="viewName">viewName </param>
        /// <returns>List<ReportWorker></returns>
        public static List<ReportProject> CreateReportsProject(string viewName)
        {

            Func<MySqlDataReader, List<ReportProject>> func = (reader) =>
            {
                List<ReportProject> reportProject = new List<ReportProject>();
                while (reader.Read())
                {
                    reportProject.Add(ConvertReport.ConvertDBtoReport(reader));
                }
                return reportProject;
            };
            List<ReportProject> reportProjects = DBAccess.RunReader(func, "report", new List<string>() { viewName }, new List<string>() { "viewName" });
            foreach (var item in reportProjects)
            {
                item.Items = GetDepartmentsWorkersProject(item.Id);
            }

            return reportProjects;
        }

        /// <summary>
        /// Gets department to reportProject
        /// </summary>
        /// <param name="id">idProject</param>
        /// <returns>List<ReportProject></returns>
        private static List<ReportProject> GetDepartmentsWorkersProject(int id)
        {
            Func<MySqlDataReader, List<ReportProject>> func = (reader) =>
            {
                List<ReportProject> reportProject = new List<ReportProject>();
                while (reader.Read())
                {
                    reportProject.Add(ConvertReport.ConvertDBtoDepartment(reader));
                }
                return reportProject;
            };
            List<ReportProject> departmentProjects = DBAccess.RunReader(func, "departmensProject", new List<string>() { id.ToString() }, new List<string>() { "Id" });
            foreach (var item in departmentProjects)
            {
                item.Items = GetWorkersByDepartmentAndProject(item.Id, id);
                item.SumHoursDo = item.Items.Sum(p => p.SumHoursDo);
            }
            return departmentProjects;
        }

        /// <summary>
        /// Gets workers to departments project
        /// </summary>
        /// <param name="idDepartment">idDepartment</param>
        /// <param name="idProject">idProject</param>
        /// <returns></returns>
        private static List<ReportProject> GetWorkersByDepartmentAndProject(int idDepartment, int idProject)
        {
            string query = $"SELECT * FROM managertasks.sumhoursforuserproject WHERE projectId={idProject} and departmentUserId={idDepartment}";
            Func<MySqlDataReader, List<ReportProject>> func = (reader) =>
            {
                List<ReportProject> workersReport = new List<ReportProject>();
                while (reader.Read())
                {
                    workersReport.Add(ConvertReport.ConvertDBtoWorkerInReport(reader));

                }
                return workersReport;
            };

            return DBAccess.RunReader(query, func);
        }

    }
}

using _00_DAL;
using BOL;
using BOL.Convertors;
using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class LogicProjectWorker
    {
        /// <summary>
        /// Update worker in project
        /// </summary>
        /// <param name="projectWorker">projectWorker contain -idUser, idProject, HoursForProject </param>
        /// <returns>bool true-succsess update, false-failed update</returns>
        public static bool UpdateProjectWorker(ProjectWorker projectWorker)
        {
            string query = $"UPDATE managertasks.projectworker SET `hoursForProject` = {projectWorker.HoursForProject}  WHERE id={projectWorker.UserId} and projectId ={projectWorker.ProjectId}  ";
            return DBAccess.RunNonQuery(query) == 1;
        }

        /// <summary>
        /// Gets workers not in this project
        /// </summary>
        /// <param name="projectId">idProject</param>
        /// <returns></returns>
        public static List<User> GetWorkerNotInProject(int projectId)
        {
            string query = $"SELECT * FROM managertasks.user WHERE departmentUserId>2 and id not in(SELECT id FROM projectworker WHERE projectId={projectId}) GROUP BY id";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> userNotInProject = new List<User>();
                while (reader.Read())
                {
                    userNotInProject.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return userNotInProject;
            };
            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets worker in this project
        /// </summary>
        /// <param name="projectId">idProject</param>
        /// <returns>List<User> - users in this project</returns>
        public static List<User> GetWorkerInProject(int projectId)
        {
            string query = $"SELECT u.*, d.* FROM managertasks.user u JOIN managertasks.department d  ON u.departmentUserId = d.id join projectworker p on u.id = p.id where p.projectId = {projectId }";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> userInProject = new List<User>();
                while (reader.Read())
                {
                    userInProject.Add(ConvertorUser.convertDBtoUserWithDepartment(reader));
                }
                return userInProject;
            };
            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Get sum hours stay to department
        /// </summary>
        /// <param name="departmentId">Department id</param>
        /// <param name="idProject">Project id</param>
        /// <returns></returns>
        public static List< decimal> GetSumStayByProjectAndDepartment(int idProject)
        {
            string query = $"SELECT h.sumHours-sum(pw.hoursForProject) from project p join hourfordepartment h on p.projectId = h.projectId join projectworker pw on pw.projectId = p.projectId where p.projectId = {idProject} group by h.departmentId";
            Func<MySqlDataReader, List<decimal>> func = (reader) =>
            {
                List<decimal> userInProject = new List<decimal>();
                while (reader.Read())
                {
                    userInProject.Add(reader.GetDecimal(0));
                }
                return userInProject;
            };
            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets the users under the team leader
        /// </summary>
        /// <param name="teamleaderId">teamleaderId</param>
        /// <returns>List<User></returns>
        public static List<User> GetUsersOfTeamLeader(int teamleaderId)
        {
            string query = $"SELECT u.*, d.* FROM managertasks.user u LEFT JOIN managertasks.department d  ON u.departmentUserId = d.id LEFT join USER uu on uu.id = u.managerId where u.managerId={teamleaderId}";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };
            return DBAccess.RunReader(query, func);
        }

    }
}


```
### API
  * Controllers
```csharp
using BLL;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webAPI_tasks.Controllers
{
    public class DepartmentController : ApiController
    {
        [HttpGet]
        [Route("api/Department/getAllDepartments")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllDepartments());
        }
    }
}

using BLL;
using BOL.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace webAPI_tasks.Controllers
{
    public class PresentDayController : ApiController
    {
      
        [HttpPost]
        [Route("api/AddPresent")]
        public HttpResponseMessage Post([FromBody]PresentDay value)
        {
            if (ModelState.IsValid)
            {
                return (LogicPresentDay.AddPresent(value)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            };
            return Request.CreateResponse(HttpStatusCode.BadRequest, BaseLogic.GetErorList(ModelState.Values));
        }

       
        [HttpPut]
        [Route("api/updatePresentDay")]
        public HttpResponseMessage Put([FromBody]PresentDay value)
        {

            if (ModelState.IsValid)
            {
                return (LogicPresentDay.UpdatePresent(value)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };
           return Request.CreateResponse(HttpStatusCode.BadRequest, BaseLogic.GetErorList(ModelState.Values));
        }

    }
}


using BLL;
using BOL;
using BOL.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace webAPI_tasks.Controllers
{
    public class ProjectsController : ApiController
    {
        [HttpGet]
        [Route("api/getAllProjects")]
        public HttpResponseMessage GetAllProjects()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicProjects.GetAllProjects());
        }

        [HttpPost]
        [Route("api/addProject")]
        public HttpResponseMessage AddProject([FromBody]Project value)
        {
            if (ModelState.IsValid)
            {
                return (LogicProjects.AddProject(value)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            };

            return Request.CreateResponse(HttpStatusCode.BadRequest, BaseLogic.GetErorList(ModelState.Values));
        }

        [HttpPut]
        [Route("api/updateProject")]
        public HttpResponseMessage UpdateProject([FromBody]Project value)
        {
            ModelState.Remove("value.DateBegin");
            if (ModelState.IsValid)
            {
                bool b = LogicProjects.UpdateProject(value);
                return (b) ?
                    Request.CreateResponse(HttpStatusCode.OK, b) : 
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not update");
                   
            };
            return Request.CreateResponse(HttpStatusCode.BadRequest, BaseLogic.GetErorList(ModelState.Values));
        }

        [HttpPut]
        [Route("api/addWorkersToProject/{projectId}")]
        public HttpResponseMessage AddWorkersToProject(int projectId, [FromBody]List<ProjectWorker> workers)
        {
           ModelState.Remove("projectId");

            for (int i = 0;i <workers.Count; i++)
            {
                ModelState.Remove($"workers[{i}].User.ConfirmPassword");
                ModelState.Remove($"workers[{i}].User.Password");
                ModelState.Remove($"workers[{i}].User.Email");
            }

            if (ModelState.IsValid)
            {
                return (LogicProjects.AddWorkerToProject(projectId, workers)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };

            return Request.CreateResponse(HttpStatusCode.BadRequest, BaseLogic.GetErorList(ModelState.Values));
        }


        [HttpDelete]
        [Route("api/deleteProject/{projectId}")]
        public HttpResponseMessage DeleteProject(int projectId)
        {
            return (LogicProjects.RemoveProject(projectId)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }


        [HttpGet]
        [Route("api/createReport/{idReport}")]
        public HttpResponseMessage CreateReports([FromUri]int idReport)
        {
            string viewName = "";
            switch (idReport)
            {
                case 1:
                    viewName = "reportProject";
                    return Request.CreateResponse(HttpStatusCode.OK, LogicProjects.CreateReportsProject(viewName));
                default:
                    viewName = "reportWorker";
                    return Request.CreateResponse(HttpStatusCode.OK, LogicProjects.CreateReportsWorker(viewName));
            }

            
        }
    }
}


using BLL;
using BOL.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace webAPI_tasks.Controllers
{
    public class ProjectWorkerController : ApiController
    {

        [HttpPut]
        [Route("api/updateProjectHours")]
        public HttpResponseMessage UpdateProjectHours([FromBody]ProjectWorker value)
        {
            ModelState.Remove("value.User.Password");
            ModelState.Remove("value.User.ConfirmPassword");
            ModelState.Remove("value.User.Email");
            if (ModelState.IsValid)
            { 
                return (LogicProjectWorker.UpdateProjectWorker(value)) ?
                   Request.CreateResponse(HttpStatusCode.OK,true) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };
            return Request.CreateResponse(HttpStatusCode.BadRequest, BaseLogic.GetErorList(ModelState.Values));
        }

        [HttpGet]
        [Route("api/getWorkerNotProject/{projectId}")]
        public HttpResponseMessage GetetWorkerNotProject(int projectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicProjectWorker.GetWorkerNotInProject(projectId));
        }

        [HttpGet]
        [Route("api/getWorkerInProject/{projectId}")]
        public HttpResponseMessage GetWorkerInProject(int projectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicProjectWorker.GetWorkerInProject(projectId));
        }

        [HttpGet]
        [Route("api/getUsersTeamLeaderProject/{teamleaderId}/{idProject}")]
        public HttpResponseMessage GetUsersTeamLeaderProject(int teamleaderId,int idProject)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetWorkerHourDoProjects(teamleaderId, idProject));
        }

        [HttpGet]
        [Route("api/getSumStayByProjectAndDepartment/{idProject}")]
        public HttpResponseMessage GetSumStayByProjectAndDepartment(int idProject)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicProjectWorker.GetSumStayByProjectAndDepartment(idProject));
        }

    }
}


using BOL;
using BLL;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using BOL.HelpModel;
using System.Web;

namespace webAPI_tasks.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/Users/getAllUsers")]   
        public HttpResponseMessage GetAllUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllUsers());
        
        }

        //managers or teamleaders
        [HttpGet]
        [Route("api/Users/getUsersByDepartment/{departmentName}")]
        public HttpResponseMessage GetUserByDepartment(string departmentName)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetUserByDepartment(departmentName));
          
        }

        //get all the workers that belong to a specific project
        [HttpGet]
        [Route("api/Users/getUserBelongProject/{projectId}")]
        public HttpResponseMessage GetUserBelongProject(int projectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetUsersBelongProjects(projectId));

        }
 
        //get all the workers that belong to a specfic teamleader
        [HttpGet]
        [Route("api/getUsersOfTeamLeader/{teamleaderId}")]
        public HttpResponseMessage GetUsersOfTeamLeader(int teamleaderId)
        {
            var x = LogicProjectWorker.GetUsersOfTeamLeader(teamleaderId);
            return Request.CreateResponse(HttpStatusCode.OK, x);
        }

        [HttpGet]
        [Route("api/getSumHoursDoneForUsers/{teamleaderId}/{projctId}")]
        public HttpResponseMessage GetSumHoursDoneForUsers( int teamleaderId, int projctId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetSumHoursDoneForUsers(teamleaderId, projctId));
        }

        [HttpGet]
        [Route("api/Users/getHoursForUserProjects/{userId}")]
        public HttpResponseMessage GetHoursForUserProjects(int userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetHoursForUserProjects(userId));
        }

        [HttpGet]
        [Route("api/Users/getHoursAndProjectForUser/{userId}")]
        public HttpResponseMessage GetHoursAndProjectForUser(int userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetHoursAndProjectForUser(userId));
        }

        //GET simple workers
        [HttpGet]
        [Route("api/Users/getWorkers")]
        public HttpResponseMessage GetWorkers()
        {
          return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetWorkers());
        }
     
        //get user Project
        [HttpGet]
        [Route("api/getProjectsById/{id}")]
        public HttpResponseMessage GetProjectsById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetProjectsUser(id));
        }

        //get projects of teamleader
        [HttpGet]
        [Route("api/getProjectsManager/{id}")]
        public HttpResponseMessage GetProjectsManager(int id)
        {
          return  Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetProjectsManager(id)); 
        }

        //add new user
        [HttpPost]
        [Route("api/addUser")]
        public HttpResponseMessage AddUser([FromBody]User value)
        {
           
            if (ModelState.IsValid)
            {
                return (LogicManager.AddUser(value)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            };
            return Request.CreateResponse(HttpStatusCode.BadRequest, BaseLogic.GetErorList(ModelState.Values));
        }

        [HttpPost]
        [Route("api/loginByPassword")]
        public HttpResponseMessage LoginByPassword([FromBody]LoginUser value)
        {
            if (ModelState.IsValid)
            {
                User user = LogicManager.GetUserDetailsByPassword(value);
                return (user != null ?Request.CreateResponse(HttpStatusCode.OK,user):

                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Erorr during login", new JsonMediaTypeFormatter())
                   });
            };
            return Request.CreateResponse(HttpStatusCode.BadRequest, BaseLogic.GetErorList(ModelState.Values));
        }

        [HttpPost]
        [Route("api/LoginByComputerUser")]
        public HttpResponseMessage LoginByComputerUser()
        {
            string ip = HttpContext.Current.Request.Form["ip"];
            User user = LogicManager.GetUserDetailsComputerUser(ip);
            if(user!=null)
               return Request.CreateResponse(HttpStatusCode.OK, user);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("api/ForgetPassword")]
        public HttpResponseMessage ForgetPassword()
        {
            string userName = HttpContext.Current.Request.Form["userName"];
            bool isConfirmPassword = LogicManager.ForgetPassword(userName);
            if (isConfirmPassword == true)
                return Request.CreateResponse(HttpStatusCode.OK, "send email with link to change password");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "User does not exist");
        }

        // updateUser
        [HttpPut]
        [Route("api/updateUser")]
        public HttpResponseMessage UpdateUser([FromBody]User value)
        {
            ModelState.Remove("value.ConfirmPassword");
            ModelState.Remove("value.Password");
            ModelState.Remove("value.Manager.ConfirmPassword");
            ModelState.Remove("value.Manager.Password");
            if (ModelState.IsValid)
            {
                return (LogicManager.UpdateUser(value)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };
            return Request.CreateResponse(HttpStatusCode.BadRequest, BaseLogic.GetErorList(ModelState.Values));
        }

        [HttpDelete]
        [Route("api/deleteUser/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            return (LogicManager.RemoveUser(id)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }

        [HttpPut]
        [Route("api/sendMessageToManagers/{idUser}")]
        public HttpResponseMessage SendMessageToManagers(int idUser, [FromBody] SendEmail message)
        {
            return (LogicManager.SendMessageToManagers(idUser, message)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not send Email", new JsonMediaTypeFormatter())
                    };
        }

        //update new password
        [HttpPut]
        [Route("api/ChangePassword/{requestId}")]
        public HttpResponseMessage ChangePassword(int requestId, [FromBody] LoginUser user)
        {
            bool isChange = LogicManager.ChangePassword(requestId, user);
            if (isChange == true)
                return Request.CreateResponse(HttpStatusCode.OK, isChange);
            else return Request.CreateResponse(HttpStatusCode.BadRequest, isChange);  
        }

    }
}

```
     
     
# Test api with `curl`

### Get Request
```
curl -X GET -v http://localhost:59628/api/getAllWorkers
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getAllWorkers HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldEFsbFdvcmtlcnM=?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:07:20 GMT
< Content-Length: 769
<
[{"Id":1,"Name":"manager","UserName":"mm","Password":"","JobId":1,"EMail":"manag
@gmail.com","ManagerId":null},{"Id":21,"Name":"TeamLeader","UserName":"tt","Pass
word":"","JobId":2,"EMail":"team@gmail.com","ManagerId":1},{"Id":22,"Name":"Work
er1","UserName":"ww1","Password":"","JobId":3,"EMail":"worker1@gmail.com","Manag
erId":21},{"Id":23,"Name":"Worker2","UserName":"ww2","Password":"","JobId":4,"EM
ail":"worker2@gmail.com","ManagerId":21},{"Id":24,"Name":"Worker3","UserName":"w
w3","Password":"","JobId":5,"EMail":"worker3@gmail.com","ManagerId":21},{"Id":25
,"Name":"Worker4","UserName":"ww4","Password":"","JobId":3,"EMail":"worker4@gmai
l.com","ManagerId":21},{"Id":27,"Name":"Gila","UserName":"gggg","Password":"","J
obId":4,"EMail":"safdsa@fdsa.fc","ManagerId":21}]* Connection #0 to host localho
st left intact
```
```
curl -X GET -v http://localhost:59628/api/GetPresence
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/GetPresence HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXEdldFByZXNlbmNl?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:08:57 GMT
< Content-Length: 5501
<
[{"WorkerName":"Worker1","ProjectName":"pr1","Date":"2018-11-27T00:00:00","Start
":"08:30:48","End":"15:28:56"},{"WorkerName":"Worker1","ProjectName":"pr1","Date
":"2018-11-28T00:00:00","Start":"11:23:50","End":"11:24:01"},{"WorkerName":"Work
er1","ProjectName":"pr2","Date":"2018-11-28T00:00:00","Start":"08:02:57","End":"
14:15:59"},{"WorkerName":"Worker1","ProjectName":"pr3","Date":"2018-11-29T00:00:
00","Start":"09:33:00","End":"17:45:01"},{"WorkerName":"Worker2","ProjectName":"
pr1","Date":"2018-11-28T00:00:00","Start":"10:29:11","End":"16:28:11"},{"WorkerN
ame":"Worker2","ProjectName":"pr2","Date":"2018-11-27T00:00:00","Start":"07:29:1
3","End":"16:46:15"},{"WorkerName":"Worker2","ProjectName":"pr3","Date":"2018-11
-29T00:00:00","Start":"08:09:16","End":"15:27:17"},{"WorkerName":"Worker3","Proj
ectName":"pr1","Date":"2018-11-29T00:00:00","Start":"08:15:29","End":"17:45:29"}
,{"WorkerName":"Worker3","ProjectName":"pr2","Date":"2018-11-28T00:00:00","Start
":"09:48:30","End":"13:06:31"},{"WorkerName":"Worker3","ProjectName":"pr3","Date
":"2018-11-27T00:00:00","Start":"10:29:32","End":"17:39:32"},{"WorkerName":"Work
er4","ProjectName":"pr1","Date":"2018-11-27T00:00:00","Start":"08:50:44","End":"
15:29:44"},{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11-27T00:00:
00","Start":"12:18:12","End":"12:18:19"},{"WorkerName":"Worker4","ProjectName":"
pr1","Date":"2018-11-27T00:00:00","Start":"14:23:45","End":"14:26:33"},{"WorkerN
ame":"Worker4","ProjectName":"pr1","Date":"2018-11-27T00:00:00","Start":"14:26:2
8","End":"14:26:33"},{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11
-27T00:00:00","Start":"14:26:43","End":"14:28:01"},{"WorkerName":"Worker4","Proj
ectName":"pr1","Date":"2018-11-27T00:00:00","Start":"14:27:36","End":"14:28:01"}
,{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11-27T00:00:00","Start
":"14:33:38","End":"14:33:50"},{"WorkerName":"Worker4","ProjectName":"pr1","Date
":"2018-11-27T00:00:00","Start":"14:34:21","End":"14:34:35"},{"WorkerName":"Work
er4","ProjectName":"pr1","Date":"2018-11-27T00:00:00","Start":"14:35:26","End":"
14:35:46"},{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11-27T00:00:
00","Start":"14:37:23","End":"14:37:27"},{"WorkerName":"Worker4","ProjectName":"
pr1","Date":"2018-11-27T00:00:00","Start":"14:37:42","End":"14:37:48"},{"WorkerN
ame":"Worker4","ProjectName":"pr1","Date":"2018-11-27T00:00:00","Start":"14:37:5
2","End":"14:38:01"},{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11
-28T00:00:00","Start":"08:37:41","End":"08:38:46"},{"WorkerName":"Worker4","Proj
ectName":"pr1","Date":"2018-11-28T00:00:00","Start":"08:39:03","End":"08:57:38"}
,{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11-28T00:00:00","Start
":"08:39:56","End":"08:57:38"},{"WorkerName":"Worker4","ProjectName":"pr1","Date
":"2018-11-28T00:00:00","Start":"08:41:00","End":"08:57:38"},{"WorkerName":"Work
er4","ProjectName":"pr1","Date":"2018-11-28T00:00:00","Start":"08:43:27","End":"
08:57:38"},{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11-28T00:00:
00","Start":"08:44:23","End":"08:57:38"},{"WorkerName":"Worker4","ProjectName":"
pr1","Date":"2018-11-28T00:00:00","Start":"08:57:32","End":"08:57:38"},{"WorkerN
ame":"Worker4","ProjectName":"pr1","Date":"2018-11-28T00:00:00","Start":"08:57:4
2","End":"08:57:48"},{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11
-28T00:00:00","Start":"08:57:49","End":"09:05:02"},{"WorkerName":"Worker4","Proj
ectName":"pr1","Date":"2018-11-28T00:00:00","Start":"08:58:14","End":"09:05:02"}
,{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11-28T00:00:00","Start
":"09:04:57","End":"09:05:02"},{"WorkerName":"Worker4","ProjectName":"pr1","Date
":"2018-11-28T00:00:00","Start":"09:05:14","End":"09:16:08"},{"WorkerName":"Work
er4","ProjectName":"pr1","Date":"2018-11-28T00:00:00","Start":"09:05:36","End":"
09:16:08"},{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11-28T00:00:
00","Start":"09:15:47","End":"09:16:08"},{"WorkerName":"Worker4","ProjectName":"
pr1","Date":"2018-11-28T00:00:00","Start":"09:16:53","End":"09:17:05"},{"WorkerN
ame":"Worker4","ProjectName":"pr1","Date":"2018-11-28T00:00:00","Start":"09:19:2
0","End":"09:19:26"},{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11
-28T00:00:00","Start":"09:19:41","End":"09:19:52"},{"WorkerName":"Worker4","Proj
ectName":"pr1","Date":"2018-11-28T00:00:00","Start":"09:20:04","End":"09:20:09"}
,{"WorkerName":"Worker4","ProjectName":"pr1","Date":"2018-11-28T00:00:00","Start
":"09:25:11","End":"09:25:20"},{"WorkerName":"Worker4","ProjectName":"pr1","Date
":"2018-11-28T00:00:00","Start":"09:25:25","End":"09:25:26"},{"WorkerName":"Work
er4","ProjectName":"pr2","Date":"2018-11-28T00:00:00","Start":"09:12:45","End":"
14:59:48"},{"WorkerName":"Worker4","ProjectName":"pr2","Date":"2018-11-28T00:00:
00","Start":"09:20:37","End":"09:20:47"},{"WorkerName":"Worker4","ProjectName":"
pr2","Date":"2018-11-28T00:00:00","Start":"09:22:03","End":"09:22:12"},{"WorkerN
ame":"Worker4","ProjectName":"pr2","Date":"2018-11-28T00:00:00","Start":"09:22:2
3","End":"09:22:29"},{"WorkerName":"Worker4","ProjectName":"pr2","Date":"2018-11
-28T00:00:00","Start":"09:23:48","End":"09:23:53"},{"WorkerName":"Worker4","Proj
ectName":"pr2","Date":"2018-11-28T00:00:00","Start":"09:24:00","End":"09:24:03"}
,{"WorkerName":"Worker4","ProjectName":"pr3","Date":"2018-11-29T00:00:00","Start
":"10:03:50","End":"15:49:53"},{"WorkerName":"Worker4","ProjectName":"pr3","Date
":"2018-11-30T00:00:00","Start":"07:29:54","End":"15:29:57"}]* Connection #0 to
host localhost left intact
```
```
curl -X GET -v http://localhost:59628/api/getAllManagers
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getAllManagers HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldEFsbE1hbmFnZXJz?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:11:39 GMT
< Content-Length: 219
<
[{"Id":1,"Name":"manager","UserName":"mm","Password":"","JobId":1,"EMail":"manag
@gmail.com","ManagerId":null},{"Id":21,"Name":"TeamLeader","UserName":"tt","Pass
word":"","JobId":2,"EMail":"team@gmail.com","ManagerId":1}]* Connection #0 to ho
st localhost left intact
```
```
curl -X GET -v http://localhost:59628/api/getProjectDeatails/21
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getProjectDeatails/21 HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldFByb2plY3REZWF0YWlsc1wyMQ==?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:13:21 GMT
< Content-Length: 686
<
[{"Id":7,"Name":"pr1","TeamLeaderId":21,"Customer":"aaa","DevelopHours":280,"QAH
ours":130,"UiUxHours":45,"StartDate":"2018-11-27T00:00:00","EndDate":"2019-01-26
T00:00:00"},{"Id":8,"Name":"pr2","TeamLeaderId":21,"Customer":"aaa","DevelopHour
s":480,"QAHours":56,"UiUxHours":210,"StartDate":"2018-12-12T00:00:00","EndDate":
"2019-03-30T00:00:00"},{"Id":9,"Name":"pr3","TeamLeaderId":21,"Customer":"ddd","
DevelopHours":250,"QAHours":45,"UiUxHours":67,"StartDate":"2018-11-30T00:00:00",
"EndDate":"2019-10-26T00:00:00"},{"Id":10,"Name":"tr1","TeamLeaderId":21,"Custom
er":"nnn","DevelopHours":300,"QAHours":250,"UiUxHours":100,"StartDate":"2018-02-
02T00:00:00","EndDate":"2018-07-07T00:00:00"}]* Connection #0 to host localhost
left intact
```
```
curl -X GET -v http://localhost:59628/api/getWorkersDeatails/21
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getWorkersDeatails/21 HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldFdvcmtlcnNEZWF0YWlsc1wyMQ==?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:14:36 GMT
< Content-Length: 551
<
[{"Id":22,"Name":"Worker1","UserName":"ww1","Password":"","JobId":3,"EMail":"wor
ker1@gmail.com","ManagerId":21},{"Id":23,"Name":"Worker2","UserName":"ww2","Pass
word":"","JobId":4,"EMail":"worker2@gmail.com","ManagerId":21},{"Id":24,"Name":"
Worker3","UserName":"ww3","Password":"","JobId":5,"EMail":"worker3@gmail.com","M
anagerId":21},{"Id":25,"Name":"Worker4","UserName":"ww4","Password":"","JobId":3
,"EMail":"worker4@gmail.com","ManagerId":21},{"Id":27,"Name":"Gila","UserName":"
gggg","Password":"","JobId":4,"EMail":"safdsa@fdsa.fc","ManagerId":21}]* Connect
ion #0 to host localhost left intact
```
```
curl -X GET -v http://localhost:59628/api/getWorkersHours/7
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getWorkersHours/7 HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldFdvcmtlcnNIb3Vyc1w3?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:16:51 GMT
< Content-Length: 275
<
[{"Name":"Gila","Hours":"0:0","AllocatedHours":0.0},{"Name":"Worker1","Hours":"6
:58","AllocatedHours":25.0},{"Name":"Worker2","Hours":"5:59","AllocatedHours":46
.0},{"Name":"Worker3","Hours":"9:30","AllocatedHours":70.0},{"Name":"Worker4","H
ours":"8:43","AllocatedHours":6.4}]* Connection #0 to host localhost left intact
```
```
curl -X GET -v http://localhost:59628/api/getWorkerHours/21/22
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getWorkerHours/21/22 HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldFdvcmtlckhvdXJzXDIxXDIy?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:18:19 GMT
< Content-Length: 248
<
[{"Id":48,"Name":"pr1","AllocatedHours":25.0,"Hours":"06:58:19"},{"Id":52,"Name"
:"pr2","AllocatedHours":30.0,"Hours":"06:13:02"},{"Id":56,"Name":"pr3","Allocate
dHours":18.0,"Hours":"08:12:01"},{"Id":60,"Name":"tr1","AllocatedHours":0.0,"Hou
rs":""}]* Connection #0 to host localhost left intact
```
```
curl -X GET -v http://localhost:59628/api/getWorkerDetails/22
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getWorkerDetails/22 HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldFdvcmtlckRldGFpbHNcMjI=?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:20:40 GMT
< Content-Length: 110
<
{"Id":22,"Name":"Worker1","UserName":"ww1","Password":"","JobId":3,"EMail":"work
er1@gmail.com","ManagerId":21}* Connection #0 to host localhost left intact
```
```
curl -X GET -v http://localhost:59628/api/getProject/7
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getProject/7 HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldFByb2plY3RcNw==?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:21:56 GMT
< Content-Length: 2
<
[]* Connection #0 to host localhost left intact
```
### Put Request (not valid data)
```
curl -v -X PUT -H "Content-type: application/json" -d "{\"Id\":\"7\",\"Name\":\"Malki\", \"UserName\":\"ggggg\",\"Password\":\"mmmggg\" , \"JobId\":\"3\",\"EMail\":\"sjafjkl@df.vaf\", \"ManagerId\":\"21\"}"  http://localhost:59628/api/UpdateWorker
```
```
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> PUT /api/UpdateWorker HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 122
>
* upload completely sent off: 122 out of 122 bytes
< HTTP/1.1 400 Bad Request
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXFVwZGF0ZVdvcmtlcg==?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:31:54 GMT
< Content-Length: 22
<
"Can not update in DB"* Connection #0 to host localhost left intact
```
```
curl -v -X PUT -H "Content-type: application/json" -d "{\"projectWorkerId\":\"1\",\"numHours\":\"30\"}"  http://localhost:59628/api/updateWorkerHours
```
```
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> PUT /api/updateWorkerHours HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 39
>
* upload completely sent off: 39 out of 39 bytes
< HTTP/1.1 400 Bad Request
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXHVwZGF0ZVdvcmtlckhvdXJz?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:38:47 GMT
< Content-Length: 29
<
"Can not update in Data Base"* Connection #0 to host localhost left intact
```
### Put Request (valid data)
```
curl -v -X PUT -H "Content-type: application/json" -d "{\"Id\":\"27\",\"Name\":\"Malki\", \"UserName\":\"1ggg\",\"Password\":\"mmmggg\" , \"JobId\":\"3\",\"EMail\":\"sjafjkl@df.vaf\", \"ManagerId\":\"21\"}"  http://localhost:59628/api/UpdateWorker
```
```
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> PUT /api/UpdateWorker HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 122
>
* upload completely sent off: 122 out of 122 bytes
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXFVwZGF0ZVdvcmtlcg==?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:36:40 GMT
< Content-Length: 0
<
* Connection #0 to host localhost left intact
```
```
curl -v -X PUT -H "Content-type: application/json" -d "{\"projectWorkerId\":\"48\",\"numHours\":\"30\"}"  http://localhost:59628/api/updateWorkerHours
```
```
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> PUT /api/updateWorkerHours HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 40
>
* upload completely sent off: 40 out of 40 bytes
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXHVwZGF0ZVdvcmtlckhvdXJz?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:40:00 GMT
< Content-Length: 0
<
* Connection #0 to host localhost left intact
```

### Post Request (not valid data)
```
curl -v -X POST -H "Content-type: application/json" -d "{\"UserName\":\"DDD\", \"Password\":\"444444\"}"  http://localhost:59628/api/login
```
```
Note: Unnecessary use of -X or --request, POST is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> POST /api/login HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 39
>
* upload completely sent off: 39 out of 39 bytes
< HTTP/1.1 400 Bad Request
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGxvZ2lu?=
< X-Powered-By: ASP.NET
< Date: Wed, 28 Nov 2018 09:50:14 GMT
< Content-Length: 16
<
"Can not log in"* Connection #0 to host localhost left intact
```
```
curl -v -X POST -H "Content-type: application/json" -d "{\"Name\":\"tryProject\", \"Customer\":\"nnn\",\"TeamLeaderId\":\"11\" , \"DevelopHours\":\"300\",\"QAHours\":\"250\", \"UiUxHours\":\"100\",\"StartDate\":\"2018-02-02\",\"EndDate\":\"2018-07-07\"}"  http://localhost:59628/api/addProject
```
```
Note: Unnecessary use of -X or --request, POST is already inferred.
*   Trying ::1...
* TCP_NODELAY set
*   Trying 127.0.0.1...
* TCP_NODELAY set
* connect to ::1 port 59628 failed: Connection refused
* connect to 127.0.0.1 port 59628 failed: Connection refused
* Failed to connect to localhost port 59628: Connection refused
* Closing connection 0
curl: (7) Failed to connect to localhost port 59628: Connection refused
```
```
curl -v -X POST -H "Content-type: application/json" -d "{\"Name\":\"Gila\",\"UserName\":\"gggg\",\
"Password\":\"gggggg\",\"JobId\":\"4\",\"EMail\":\"safdsa@fdsaf\",\"ManagerId\":\"11\"}"  http://localhost:59628/api/addWorker
```
```
Note: Unnecessary use of -X or --request, POST is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> POST /api/addWorker HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 105
>
* upload completely sent off: 105 out of 105 bytes
< HTTP/1.1 400 Bad Request
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGFkZFdvcmtlcg==?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 06:42:53 GMT
< Content-Length: 19
<
"Can not add to DB"* Connection #0 to host localhost left intact
```
```
curl -v -X POST -H "Content-type: application/json" -d "{\"idProjectWorker\":\"7\",\"hour\":\"8\","isFirst\":\"true\"}"  http://localhost:59628/api/updateStartHour
```
```
Note: Unnecessary use of -X or --request, POST is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> POST /api/updateHours HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 21
>
* upload completely sent off: 21 out of 21 bytes
< HTTP/1.1 404 Not Found
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXHVwZGF0ZUhvdXJz?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 06:48:36 GMT
< Content-Length: 196
<
{"Message":"No HTTP resource was found that matches the request URI 'http://loca
lhost:59628/api/updateHours'.","MessageDetail":"No type was found that matches t
he controller named 'updateHours'."}* Connection #0 to host localhost left intact
```
```
curl -v -X POST -H "Content-type: application/json" -d "{\"sub\":\"malky8895\",\"body\":\"ddd\",\"id\":\"9\"}"  http://localhost:59628/api/SendMsg
```
```
Note: Unnecessary use of -X or --request, POST is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> POST /api/SendMsg HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 41
>
* upload completely sent off: 41 out of 41 bytes
< HTTP/1.1 500 Internal Server Error
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXFNlbmRNc2c=?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:04:54 GMT
< Content-Length: 2634
```

### Post Request (valid data)
```
curl-7.61.0-win64-mingw\bin>curl -v -X POST -H "Content-type: application/json" -d "{\"UserName\":\"mm\", \"Password\":\"6773ea887f0e3f1c34b01936aaf9687b16a04c6f9e65e4afbfce7bb7f76b0857\"}"  http://localhost:59628/api/login
```
```
Note: Unnecessary use of -X or --request, POST is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> POST /api/login HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 96
>
* upload completely sent off: 96 out of 96 bytes
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGxvZ2lu?=
< X-Powered-By: ASP.NET
< Date: Wed, 28 Nov 2018 09:55:38 GMT
< Content-Length: 108
<
{"Id":1,"Name":"manager","UserName":"mm","Password":"","JobId":1,"EMail":"manag@
gmail.com","ManagerId":null}* Connection #0 to host localhost left intact
```
```
C:\Users\administrator.NB\Desktop\curl-7.61.0-win64-mingw\bin>curl -v -X POST -H
 "Content-type: application/json" -d "{\"Name\":\"tr1\", \"Customer\":\"nnn\",\"TeamLeaderId\":\"21\" 
 , \"DevelopHours\":\"300\",\"QAHours\":\"250\", \"UiUxHours\":\"100\",\"StartDate\":\"2018-02-02\",\"EndDate\":\"2018-07-07\"}"  http://localhost:59628/api/addProject
```
```
Note: Unnecessary use of -X or --request, POST is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> POST /api/addProject HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 158
>
* upload completely sent off: 158 out of 158 bytes
< HTTP/1.1 201 Created
< Cache-Control: no-cache
< Pragma: no-cache
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGFkZFByb2plY3Q=?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 06:40:12 GMT
< Content-Length: 0
<
* Connection #0 to host localhost left intact
```
```
C:\Users\administrator.NB\Desktop\curl-7.61.0-win64-mingw\bin>curl -v -X POST -H "Content-type: application/json" -d "{\"Name\":\"Gila\",\"UserName\":\"gggg\",\
"Password\":\"gggggg\",\"JobId\":\"4\",\"EMail\":\"safdsa@fdsa.fc\",\"ManagerId\":\"21\"}"  http://localhost:59628/api/addWorker
```
```
Note: Unnecessary use of -X or --request, POST is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> POST /api/addWorker HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 107
>
* upload completely sent off: 107 out of 107 bytes
< HTTP/1.1 201 Created
< Cache-Control: no-cache
< Pragma: no-cache
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGFkZFdvcmtlcg==?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 06:46:11 GMT
< Content-Length: 0
<
* Connection #0 to host localhost left intact
```
```
curl -v -X POST -H "Content-type: application/json" -d "{\"idProjectWorker\":\"22\",\"hour\":\"8\","isFirst\":\"true\"}"  http://localhost:59628/api/updateStartHour
```
```
```
```
curl -v -X POST -H "Content-type: application/json" -d "{\"sub\":\"malky8895\",\"body\":\"ddd\",\"id\":\"22\"}"  http://localhost:59628/api/SendMsg
```
```
Note: Unnecessary use of -X or --request, POST is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> POST /api/SendMsg HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 42
>
* upload completely sent off: 42 out of 42 bytes
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXFNlbmRNc2c=?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:03:36 GMT
< Content-Length: 0
<
* Connection #0 to host localhost left intact
```
### Delete Request (not valid data)
```
curl -X DELETE -v http://localhost:59628/api/deleteWorker/8
```
```
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> DELETE /api/deleteWorker/8 HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 400 Bad Request
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGRlbGV0ZVdvcmtlclw4?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:43:18 GMT
< Content-Length: 24
<
"Can not remove from DB"* Connection #0 to host localhost left intact
```
### Delete Request (valid data)
```
curl -X GET -v http://localhost:59628/api/getAllWorkers
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getAllWorkers HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldEFsbFdvcmtlcnM=?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:44:47 GMT
< Content-Length: 770
<
[{"Id":1,"Name":"manager","UserName":"mm","Password":"","JobId":1,"EMail":"manag
@gmail.com","ManagerId":null},{"Id":21,"Name":"TeamLeader","UserName":"tt","Pass
word":"","JobId":2,"EMail":"team@gmail.com","ManagerId":1},{"Id":22,"Name":"Work
er1","UserName":"ww1","Password":"","JobId":3,"EMail":"worker1@gmail.com","Manag
erId":21},{"Id":23,"Name":"Worker2","UserName":"ww2","Password":"","JobId":4,"EM
ail":"worker2@gmail.com","ManagerId":21},{"Id":24,"Name":"Worker3","UserName":"w
w3","Password":"","JobId":5,"EMail":"worker3@gmail.com","ManagerId":21},{"Id":25
,"Name":"Worker4","UserName":"ww4","Password":"","JobId":3,"EMail":"worker4@gmai
l.com","ManagerId":21},{"Id":27,"Name":"Malki","UserName":"1ggg","Password":"","
JobId":3,"EMail":"sjafjkl@df.vaf","ManagerId":21}]* Connection #0 to host localh
ost left intact
```
```
curl -X DELETE -v http://localhost:59628/api/deleteWorker/27
```
```
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> DELETE /api/deleteWorker/27 HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGRlbGV0ZVdvcmtlclwyNw==?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:45:46 GMT
< Content-Length: 0
<
* Connection #0 to host localhost left intact
```
```
curl -X GET -v http://localhost:59628/api/getAllWorkers
```
```
Note: Unnecessary use of -X or --request, GET is already inferred.
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 59628 (#0)
> GET /api/getAllWorkers HTTP/1.1
> Host: localhost:59628
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERvY3VtZW50c1xHaXRIdWJcVGFza01hb
mFnbWVudDJcVGFza01hbmFnbWVudFxVSUxcYXBpXGdldEFsbFdvcmtlcnM=?=
< X-Powered-By: ASP.NET
< Date: Thu, 29 Nov 2018 07:46:33 GMT
< Content-Length: 663
<
[{"Id":1,"Name":"manager","UserName":"mm","Password":"","JobId":1,"EMail":"manag
@gmail.com","ManagerId":null},{"Id":21,"Name":"TeamLeader","UserName":"tt","Pass
word":"","JobId":2,"EMail":"team@gmail.com","ManagerId":1},{"Id":22,"Name":"Work
er1","UserName":"ww1","Password":"","JobId":3,"EMail":"worker1@gmail.com","Manag
erId":21},{"Id":23,"Name":"Worker2","UserName":"ww2","Password":"","JobId":4,"EM
ail":"worker2@gmail.com","ManagerId":21},{"Id":24,"Name":"Worker3","UserName":"w
w3","Password":"","JobId":5,"EMail":"worker3@gmail.com","ManagerId":21},{"Id":25
,"Name":"Worker4","UserName":"ww4","Password":"","JobId":3,"EMail":"worker4@gmai
l.com","ManagerId":21}]* Connection #0 to host localhost left intact
```


 

***
## WinForms +  Angular
### login 
### Manager page
![picture](add_project.png)  
![picture](team_management.png) 
![picture](add_worker.png)  
![picture](edit_worker.png)
### Team leader page
![picture](worker_list.png) 
![picture](graph_hours_status.png) 
### Worker page 
![picture](home_page.png)  

 
