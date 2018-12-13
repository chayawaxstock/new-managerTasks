

using manageTask.HelpModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace manageTask.Logic
{
    public class ReportRequests
    {
        /// <summary>
        /// CreateReportProjects
        /// </summary>
        /// <returns>List<ReportProject></returns>
        public static List<ReportProject> CreateReportProjects()
        {
            try
            {
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri(GlobalProp.URI);
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = client1.GetAsync($"api/createReport/1").Result;
                if (response1.IsSuccessStatusCode)
                {
                    List<ReportProject> report = JsonConvert.DeserializeObject<List<ReportProject>>(response1.Content.ReadAsStringAsync().Result);
                    if (report != null)
                        return report;
                    return new List<ReportProject>();

                }

                BaseService.GetMessage("error to get data","error");
                return new List<ReportProject>();
            }
            catch 
            {
               
                return new List<ReportProject>();
            }
        }

        /// <summary>
        /// CreateReportWorker
        /// </summary>
        /// <returns>List<ReportWorker></returns>
        public static List<ReportWorker> CreateReportWorker()
        {
            try
            {
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri(GlobalProp.URI);
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = client1.GetAsync($"api/createReport/2").Result;
                if (response1.IsSuccessStatusCode)
                {
                    List<ReportWorker> report = JsonConvert.DeserializeObject<List<ReportWorker>>(response1.Content.ReadAsStringAsync().Result);
                    if (report != null)
                        return report;
                    return new List<ReportWorker>();

                }
                BaseService.GetMessage("error to get error","error");
                return new List<ReportWorker>();
            }
            catch 
            {
                return new List<ReportWorker>();
            }
        }
    }
}
