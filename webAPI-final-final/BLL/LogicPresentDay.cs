using _00_DAL;
using BOL.Models;

namespace BLL
{
    public class LogicPresentDay
    {

        /// <summary>
        /// Update pressent- date time
        /// </summary>
        /// <param name="present">PresentDay contain- idUser, idProject, dateEnd</param>
        /// <returns>bool true- succsess to update, false- failed to update</returns>
        public static bool UpdatePresent(PresentDay present)
        {
            string dateEnd = present.TimeEnd.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ssss");
            string query = $"set @id=0;select max(presentDayId) into @id from presentday where id = {present.UserId} and projectId ={present.ProjectId}; UPDATE `managertasks`.`presentday`SET`timeEnd` = '{dateEnd}' WHERE presentDayId = @id and id ={present.UserId} and projectId = {present.ProjectId}";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Add pressent
        /// </summary>
        /// <param name="presentDay">presentDay- contain idUser, idProject, dateBegin </param>
        /// <returns></returns>
        public static bool AddPresent(PresentDay presentDay)
        {
            string dateBegin = presentDay.TimeBegin.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ssss");
            string dateEnd = presentDay.TimeEnd.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ssss");
            string query = $"INSERT INTO `managertasks`.`PresentDay`(`timeBegin`,`timeEnd`,`projectId`,`id`) VALUES('{dateBegin}','{dateEnd}',{presentDay.ProjectId},{presentDay.UserId}); ";
            return DBAccess.RunNonQuery(query) == 1;
        }
    }
}
