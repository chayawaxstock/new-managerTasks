using manageTask.HelpModel;
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
    public class UserRequests
    {
        /// <summary>
        /// GetSimpleWorkers
        /// </summary>
        /// <returns>List<User></returns>
        public static List<User> GetSimpleWorkers()
        {
            try
            {
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri($@"{GlobalProp.URI}");
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = client1.GetAsync($"api/Users/getWorkers").Result;
                if (response1.IsSuccessStatusCode)
                {
                    var CardsJson = response1.Content.ReadAsStringAsync().Result;
                    List<User> workers = JsonConvert.DeserializeObject<List<User>>(response1.Content.ReadAsStringAsync().Result);
                    if (workers != null)
                        return workers;
                    return new List<User>();
                }
                BaseService.GetMessage("can not get data", "error");
                return new List<User>();
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return new List<User>();
            }

        }

        /// <summary>
        /// AddWorkerToProject
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="users">List<ProjectWorker>- users to add project</param>
        /// <returns>bool</returns>
        public static bool AddWorkerToProject(int projectId, List<ProjectWorker> users)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/addWorkersToProject/{projectId}");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string cardsString = Newtonsoft.Json.JsonConvert.SerializeObject(users, Formatting.None);
                    streamWriter.Write(cardsString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusDescription == "OK")
                    return true;
                else return false;
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return false;
            }
        }

        /// <summary>
        /// SendMessage to manager
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="message">message to send</param>
        public static void SendMessage(int userId, Object message)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/sendMessageToManagers/{userId}");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string cardsString = Newtonsoft.Json.JsonConvert.SerializeObject(message, Formatting.None);
                    streamWriter.Write(cardsString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                    BaseService.GetMessage("secsses to send email", "secsses");
                else BaseService.GetMessage("failed to send email", "failed");
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
            }
        }

        /// <summary>
        /// GetWorkerNotInProject
        /// </summary>
        /// <param name="idProject">idProject</param>
        /// <returns>List<User> worker that not work in this project</returns>
        public static List<User> GetWorkerNotInProject(int idProject)
        {
            try
            {
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri($@"{GlobalProp.URI}");
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = client1.GetAsync($"api/getWorkerNotProject/{idProject}").Result;
                if (response1.IsSuccessStatusCode)
                {
                    var CardsJson = response1.Content.ReadAsStringAsync().Result;
                    List<User> workers = JsonConvert.DeserializeObject<List<User>>(response1.Content.ReadAsStringAsync().Result);
                    if (workers != null)
                        return workers;
                    return new List<User>();
                }
                BaseService.GetMessage("can not get data", "error");
                return new List<User>();
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new List<User>();
            }

        }

        /// <summary>
        /// LoginUser
        /// </summary>
        /// <param name="userLogin">userLogin- user name, password</param>
        /// <returns></returns>
        public static User LoginUser(UserLogin userLogin)
        {
            //Post Request for Login
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/loginByPassword");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string UserLoginString = Newtonsoft.Json.JsonConvert.SerializeObject(userLogin, Formatting.None);
                    streamWriter.Write(UserLoginString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Reading response
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If Login succeeded
                    if (result != null)
                    {
                        User user = JsonConvert.DeserializeObject<User>(result);
                        GlobalProp.CurrentUser = user;
                        return user;
                    }
                    else return null;
                }
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return null;
            }
        }

        /// <summary>
        /// AddUser
        /// </summary>
        /// <param name="worker">user</param>
        /// <returns>string</returns>
        public static string AddUser(User worker)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/addUser");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string NewUserString = Newtonsoft.Json.JsonConvert.SerializeObject(worker, Formatting.None);
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
                    return result;
                }
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return null;
            }
        }

        /// <summary>
        /// UpdateUser
        /// </summary>
        /// <param name="editUser">editUser</param>
        /// <returns>bool</returns>
        public static bool UpdateUser(User editUser)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/updateUser");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string cardsString = Newtonsoft.Json.JsonConvert.SerializeObject(editUser, Formatting.None);
                    streamWriter.Write(cardsString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                BaseService.GetMessage("sucsess to update worker", "sucsess");
                return true;

            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return false;

            }
        }

        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <returns>List<User></returns>
        public static List<User> GetAllUsers()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($@"{GlobalProp.URI}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api/Users/getAllUsers").Result;
                if (response.IsSuccessStatusCode)
                {
                    var CardsJson = response.Content.ReadAsStringAsync().Result;
                    List<User> workers = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
                    return workers;
                }
                BaseService.GetMessage("can not get data", "error");
                return new List<User>();
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new List<User>();
            }
        }

        /// <summary>
        /// DeleteUser
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>bool</returns>
        public static bool DeleteUser(int userId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"{GlobalProp.URI}");
                    var response = client.DeleteAsync($"api/deleteUser/{userId}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        BaseService.GetMessage("succsess delete", "succsess");
                        return true;
                    }

                    BaseService.GetMessage("can not get data", "error");
                    return false;
                }
            }
            catch (Exception)
            {
                BaseService.GetMessage("can not get data", "error");
                return false;
            }
        }

        /// <summary>
        /// GetSumHoursDoneForUsers
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>List<SumHoursDoneUser></returns>
        public static List<SumHoursDoneUser> GetSumHoursDoneForUsers(int projectId)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"{GlobalProp.URI}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api/getSumHoursDoneForUsers/{GlobalProp.CurrentUser.UserId}/{projectId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var CardsJson = response.Content.ReadAsStringAsync().Result;
                    List<SumHoursDoneUser> sumHoursDoneUsers = JsonConvert.DeserializeObject<List<SumHoursDoneUser>>(response.Content.ReadAsStringAsync().Result);
                    if (sumHoursDoneUsers != null)
                    {
                        return sumHoursDoneUsers;
                    }
                    return new List<SumHoursDoneUser>();
                }
                BaseService.GetMessage("can not get data", "error");
                return new List<SumHoursDoneUser>();
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new List<SumHoursDoneUser>();
            }

        }

        /// <summary>
        /// GetUsersOfTeamLeader
        /// </summary>
        /// <param name="teamLeaderId">teamLeaderId</param>
        /// <returns></returns>
        public static List<User> GetUsersOfTeamLeader(int teamLeaderId)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"{GlobalProp.URI}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api/getUsersOfTeamLeader/{teamLeaderId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var CardsJson = response.Content.ReadAsStringAsync().Result;
                    List<User> workers = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
                    if (workers != null)
                    {
                        return workers;
                    }
                    return new List<User>();

                }
                BaseService.GetMessage("can not get data", "error");
                return new List<User>();
            }
            catch
            {
                BaseService.GetMessage("can not get data", "error");
                return new List<User>();
            }

        }

        /// <summary>
        /// LoginByIP
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns>User if success null if failed</returns>
        public static User LoginByIP(string ip)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/LoginByComputerUser");
                var postData = $"ip={ip}";
                var data = Encoding.ASCII.GetBytes(postData);
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.ContentLength = data.Length;
                using (var stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                //Reading response
                using (var streamReader = new System.IO.StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    User user = JsonConvert.DeserializeObject<User>(result);
                    GlobalProp.CurrentUser = user;
                    return user;
                }
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// ForgetPassword
        /// </summary>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        public static bool ForgetPassword(string userName)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(($@"{GlobalProp.URI}api/ForgetPassword"));

                var postData = $"userName={userName}";
                var data = Encoding.ASCII.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                BaseService.GetMessage(responseString, "succses");
                return true;
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return false;
            }

        }

    }
}

