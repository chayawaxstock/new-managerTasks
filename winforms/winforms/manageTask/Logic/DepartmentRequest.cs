using manageTask.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace manageTask.Logic
{
    public class DepartmentRequest
    {
        /// <summary>
        /// GetAllDepartments
        /// </summary>
        /// <returns>List<DepartmentUser></returns>
        public static List<DepartmentUser> GetAllDepartments()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($@"{GlobalProp.URI}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api/Department/getAllDepartments").Result;
                var CardsJson = response.Content.ReadAsStringAsync().Result;
                List<DepartmentUser> departments = JsonConvert.DeserializeObject<List<DepartmentUser>>(response.Content.ReadAsStringAsync().Result);
                if (departments != null)
                    return departments;
                else return new List<DepartmentUser>();
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return new List<DepartmentUser>();
            }
        }

        /// <summary>
        /// GetUserByDepartment
        /// </summary>
        /// <param name="department">department name</param>
        /// <returns>List<User></returns>
        public static List<User> GetUserByDepartment(string department)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($@"{GlobalProp.URI}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api/Users/getUsersByDepartment/{department}").Result;
                var CardsJson = response.Content.ReadAsStringAsync().Result;
                List<User> teamLeaders = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
                return teamLeaders;
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return new List<User>();
            }
        }
    }
}
