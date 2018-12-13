
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
