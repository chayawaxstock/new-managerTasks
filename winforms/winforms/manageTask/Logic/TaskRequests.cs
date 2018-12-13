using manageTask.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace manageTask.Logic
{
    public class TaskRequests
    {
        /// <summary>
        /// GetAllTasksByUserId
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>List<ProjectWorker> return projects that user work</returns>
        public static List<ProjectWorker> GetAllTasksByUserId(int userId)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"{GlobalProp.URI}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api/Users/getHoursAndProjectForUser/{userId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var CardsJson = response.Content.ReadAsStringAsync().Result;
                    List<ProjectWorker> workers = JsonConvert.DeserializeObject<List<ProjectWorker>>(response.Content.ReadAsStringAsync().Result);
                    return workers;
                }
                BaseService.GetMessage("can not get data", "error");
                return new List<ProjectWorker>();
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new List<ProjectWorker>();
            }
        }

        /// <summary>
        /// GetProjectsById
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>project</returns>
        public static List<ProjectWorker> GetProjectsById(int userId)
        {
            try
            {
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri($@"{GlobalProp.URI}");
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response2 = client2.GetAsync($"api/getProjectsById/{userId}").Result;
                if (response2.IsSuccessStatusCode)
                {
                    var CardsJson = response2.Content.ReadAsStringAsync().Result;
                    List<ProjectWorker> projects = JsonConvert.DeserializeObject<List<ProjectWorker>>(response2.Content.ReadAsStringAsync().Result);
                    if (projects != null)
                        return projects;
                    else new List<ProjectWorker>();
                }
                BaseService.GetMessage("can not get data", "error");
                return new List<ProjectWorker>();
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new List<ProjectWorker>();
            }
        }

        /// <summary>
        /// GetProjectsManager
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>List<Project></returns>
        public static List<Project> GetProjectsManager(int userId)
        {
            try
            {
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri($@"{GlobalProp.URI}");
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response2 = client2.GetAsync($"api/getProjectsManager/{GlobalProp.CurrentUser.UserId}").Result;
                if (response2.IsSuccessStatusCode)
                {
                    var CardsJson = response2.Content.ReadAsStringAsync().Result;
                    List<Project> projects = JsonConvert.DeserializeObject<List<Project>>(response2.Content.ReadAsStringAsync().Result);
                    return projects;
                }
                BaseService.GetMessage("can not get data", "error");
                return new List<Project>();
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new List<Project>();
            }
        }

        /// <summary>
        /// GetAllProjects
        /// </summary>
        /// <returns>List<Project></returns>
        public static List<Project> GetAllProjects()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($@"{GlobalProp.URI}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api/getAllProjects").Result;
                if (response.IsSuccessStatusCode)
                {
                    var CardsJson = response.Content.ReadAsStringAsync().Result;
                    List<Project> projects = JsonConvert.DeserializeObject<List<Project>>(response.Content.ReadAsStringAsync().Result);
                    if (projects != null)
                        return projects;
                    return new List<Project>();
                }
                BaseService.GetMessage("can not get data", "error");
                return new List<Project>();
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new List<Project>();
            }


        }

        /// <summary>
        /// Get Hours that Users worker in their projects
        /// </summary>
        /// <returns>Dictionary<string, decimal> project name- sum hours work</returns>
        public static Dictionary<string, decimal> GetHoursUsersProject()
        {
            try
            {
                HttpClient client3 = new HttpClient();
                client3.BaseAddress = new Uri($@"{GlobalProp.URI}");
                client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response3 = client3.GetAsync($"api/Users/getHoursForUserProjects/{GlobalProp.CurrentUser.UserId}").Result;
                if (response3.IsSuccessStatusCode)
                {
                    Dictionary<string, decimal> projectsDictionary = new Dictionary<string, decimal>();
                    var CardsJson = response3.Content.ReadAsStringAsync().Result;
                    List<SumHoursDoneUser> sumHoursDoneUserProjects = JsonConvert.DeserializeObject<List<SumHoursDoneUser>>(response3.Content.ReadAsStringAsync().Result);
                    if (sumHoursDoneUserProjects != null)
                    {
                        foreach (SumHoursDoneUser sumHoursDoneUserProject in sumHoursDoneUserProjects)
                        {
                            projectsDictionary.Add(sumHoursDoneUserProject.Label, sumHoursDoneUserProject.Data);
                        }
                        return projectsDictionary;
                    }
                    else return new Dictionary<string, decimal>();
                }
                BaseService.GetMessage("can not get data", "error");
                return new Dictionary<string, decimal>();
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new Dictionary<string, decimal>();
            }
        }

        /// <summary>
        /// AddProject
        /// </summary>
        /// <param name="project">project</param>
        /// <returns>bool -true or false</returns>
        public static bool AddProject(Project project)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/addProject");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string NewUserString = Newtonsoft.Json.JsonConvert.SerializeObject(project, Formatting.None);
                    streamWriter.Write(NewUserString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Reading response
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If add project succeeded
                    if (result != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return false;
            }
        }

        /// <summary>
        /// UpdateProject
        /// </summary>
        /// <param name="project">project</param>
        /// <returns>bool</returns>
        public static bool UpdateProject(Project project)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/updateProject");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string NewProjectString = JsonConvert.SerializeObject(project, Formatting.None);
                    streamWriter.Write(NewProjectString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Reading response
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If add project succeeded
                    if (result != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return false;
            }
        }

        /// <summary>
        /// getUserBelongProject
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>List<User></returns>
        public static List<User> GetUserBelongProject(int projectId)
        {
            try
            {
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri($"{GlobalProp.URI}");
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response2 = client2.GetAsync($"api/getWorkerInProject/{projectId}").Result;
                if (response2.IsSuccessStatusCode)
                {
                    var CardsJson = response2.Content.ReadAsStringAsync().Result;
                    List<User> projectWorkers = JsonConvert.DeserializeObject<List<User>>(response2.Content.ReadAsStringAsync().Result);
                    if (projectWorkers != null)
                    {
                        return projectWorkers;
                    }
                    return new List<User>();
                }
                else
                {
                    BaseService.GetMessage("can not get data", "error");
                    return new List<User>();
                }
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new List<User>();
            }
        }

        /// <summary>
        /// Updatehours to user in project
        /// </summary>
        /// <param name="projectWorker">user in project</param>
        /// <returns>bool</returns>
        public static bool UpdateProjectHours(ProjectWorker projectWorker)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/updateProjectHours");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string cardsString = Newtonsoft.Json.JsonConvert.SerializeObject(projectWorker, Formatting.None);
                    streamWriter.Write(cardsString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusDescription == "OK")
                    return true;
                else return false;

            }
            catch
            {
                return false;
            }

        }
    }
}

