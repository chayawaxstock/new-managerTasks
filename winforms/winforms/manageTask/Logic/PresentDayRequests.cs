using manageTask.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;


namespace manageTask.Logic
{
    public class PresentDayRequests
    {
        /// <summary>
        /// AddPresentDay
        /// </summary>
        /// <param name="presentDay">presentDay contain -idUser, idProject and dateStart</param>
        /// <returns>bool true- succses add, false- failed add</returns>
        public static bool AddPresentDay(PresentDay presentDay)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{GlobalProp.URI}api/AddPresent");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    string NewPressentString = Newtonsoft.Json.JsonConvert.SerializeObject(presentDay, Formatting.None);
                    streamWriter.Write(NewPressentString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                var responseString = new StreamReader(httpResponse.GetResponseStream()).ReadToEnd();
                BaseService.GetMessage(responseString, "succses");
                return true;
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return false;
            }
            catch 
            {
                BaseService.GetMessage("failed to set pressent", "failed");
                return false;
            }
        }

        /// <summary>
        /// AddPresentDay
        /// </summary>
        /// <param name="presentDay">presentDay contain -idUser, idProject and dateStart</param>
        /// <returns>bool true- succses update, false- failed update</returns>
        public static bool UpdatePresentDay(PresentDay presentDay)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"{GlobalProp.URI}api/updatePresentDay");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string cardsString = Newtonsoft.Json.JsonConvert.SerializeObject(presentDay, Formatting.None);
                    streamWriter.Write(cardsString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var responseString = new StreamReader(httpResponse.GetResponseStream()).ReadToEnd();
                BaseService.GetMessage(responseString, "succses");
                return true;
            }
            catch (WebException ex)
            {
                BaseService.GetErrorsFromServer(ex);
                return false;
            }
            catch 
            {
                BaseService.GetMessage("failed to set pressent", "failed");
                return false;
            }
        }
    }
}
