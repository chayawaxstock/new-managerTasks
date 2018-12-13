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
