
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
