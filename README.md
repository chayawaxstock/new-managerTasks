# Task Managmant

## Using this technologies:

* MySql
* Web api
* PHP
* WinForm
* Angular

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
      
        *important note: in order to `send email` feature  from the php server(just if you have xampp) in your computer follow this instruction:* 
        
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
    * Password - string - minLength: 8, maxLength:20, reqiered, unique
    * Ip- string
    * NumHoursWork- int between 1-12
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
    * Login - sign in to the system    
    requierd data: a `Login` object
    If the user is valid - we will check his status and navigate him to the currect main page, else a suitable message will be send to him.

* Manager screens:

   * Users managmant:

     * GetAllUsers- get all the workers in this company.

     * The manager can manage his workers:
         * Add user - add a new user    
              requierd data: a `User` object
              If the user details is valid - we will add the user to the UsersList, and return true, Else - we will return a matching                 error
         * Edit user- edit worker's details 
           requierd data: a `User` object
           If the update was successful - we will return true, else a suitable message will be send to him.
         * Delete user- the manager can delete worker
           requierd data:`user id` 
           If the delete prompt was successful - we will return true, else a suitable message will be send to him.
         * Edit pemission - allow the worker to work in other projects, not in his team leader's group. 
                             requierd data:`projectWorker` 
                             If the projectWorker details is valid - we will add the projectWorker to the projectWorkersList, and return                              true, Else - we will return a matching error

  * Projects managmant:

    * GetAllProjects- get all the projects in this company.
    * Add project - add a new project   
             requierd data: a `Project` object
             If the project details is valid - we will add the project to the ProjectsList, and return true, Else - we will return a matching error
             
     * Edit project- edit project's details 
           requierd data: a `Project` object
           If the update was successful - we will return true, else a suitable message will be send to him.
     * GetProjectsReports-  get all the details that the manager needs to the report. The manager can also filter the report assign to his needs
      and to exporet it into an Excel file,Pdf file.
    * GetWorkersReports-  get all the details that the manager needs to the report. The manager can also filter the report assign to his needs
      and to exporet it into an Excel file,Pdf file.
 

* TeamLeader screens:

   * Team managmant:
     * GetAllWorkers- get all the workers in this company,that belongs to this team leader.

     * Update hours- the team leader can update (edit add or delete) the workers' hours details.
        every data saved in a suitable list and when `save` button clicked- the server check the lists in 
        the crud function- add user, edit user or delete hours. see details above.

    * Project managmant: 

        * GetAllProjects- get all the projects in this company,that belongs to this team leader.
        The team leader can see the status of each project. 

        * GetPresenceStatusPerWorkers- by this function the team leader can see a graph of his workers.   
           requierd data: `teamLeaderId`
              
   
    * Worker screens:

       * Send Email- send email from the worker to his manager.
         requierd data: `Email` objeat 
       
      * GetAllProjects- get all the projects in this company,that belongs to this worker.
        The worker can see the status of each project. 

      * The worker can see also a graph of his hours done for his projects.
 

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

 
