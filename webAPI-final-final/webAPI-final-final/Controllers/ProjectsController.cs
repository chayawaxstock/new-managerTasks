
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
