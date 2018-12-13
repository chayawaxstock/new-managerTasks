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