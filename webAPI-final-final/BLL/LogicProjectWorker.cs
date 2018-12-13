using _00_DAL;
using BOL;
using BOL.Convertors;
using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class LogicProjectWorker
    {
        /// <summary>
        /// Update worker in project
        /// </summary>
        /// <param name="projectWorker">projectWorker contain -idUser, idProject, HoursForProject </param>
        /// <returns>bool true-succsess update, false-failed update</returns>
        public static bool UpdateProjectWorker(ProjectWorker projectWorker)
        {
            string query = $"UPDATE managertasks.projectworker SET `hoursForProject` = {projectWorker.HoursForProject}  WHERE id={projectWorker.UserId} and projectId ={projectWorker.ProjectId}  ";
            return DBAccess.RunNonQuery(query) == 1;
        }

        /// <summary>
        /// Gets workers not in this project
        /// </summary>
        /// <param name="projectId">idProject</param>
        /// <returns></returns>
        public static List<User> GetWorkerNotInProject(int projectId)
        {
            string query = $"SELECT * FROM managertasks.user WHERE departmentUserId>2 and id not in(SELECT id FROM projectworker WHERE projectId={projectId}) GROUP BY id";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> userNotInProject = new List<User>();
                while (reader.Read())
                {
                    userNotInProject.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return userNotInProject;
            };
            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets worker in this project
        /// </summary>
        /// <param name="projectId">idProject</param>
        /// <returns>List<User> - users in this project</returns>
        public static List<User> GetWorkerInProject(int projectId)
        {
            string query = $"SELECT u.*, d.* FROM managertasks.user u JOIN managertasks.department d  ON u.departmentUserId = d.id join projectworker p on u.id = p.id where p.projectId = {projectId }";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> userInProject = new List<User>();
                while (reader.Read())
                {
                    userInProject.Add(ConvertorUser.convertDBtoUserWithDepartment(reader));
                }
                return userInProject;
            };
            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Get sum hours stay to department
        /// </summary>
        /// <param name="departmentId">Department id</param>
        /// <param name="idProject">Project id</param>
        /// <returns></returns>
        public static List< decimal> GetSumStayByProjectAndDepartment(int idProject)
        {
            string query = $"SELECT h.sumHours-sum(pw.hoursForProject) from project p join hourfordepartment h on p.projectId = h.projectId join projectworker pw on pw.projectId = p.projectId where p.projectId = {idProject} group by h.departmentId";
            Func<MySqlDataReader, List<decimal>> func = (reader) =>
            {
                List<decimal> userInProject = new List<decimal>();
                while (reader.Read())
                {
                    userInProject.Add(reader.GetDecimal(0));
                }
                return userInProject;
            };
            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets the users under the team leader
        /// </summary>
        /// <param name="teamleaderId">teamleaderId</param>
        /// <returns>List<User></returns>
        public static List<User> GetUsersOfTeamLeader(int teamleaderId)
        {
            string query = $"SELECT u.*, d.* FROM managertasks.user u LEFT JOIN managertasks.department d  ON u.departmentUserId = d.id LEFT join USER uu on uu.id = u.managerId where u.managerId={teamleaderId}";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };
            return DBAccess.RunReader(query, func);
        }

    }
}
