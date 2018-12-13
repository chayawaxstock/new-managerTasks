using _00_DAL;
using BOL;
using BOL.Convertors;
using BOL.HelpModel;
using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BLL
{
    public class LogicProjects
    {
        public static int index = 100;

        /// <summary>
        /// Gets all projects
        /// </summary>
        /// <returns>List<Project> all projects</returns>
        public static List<Project> GetAllProjects()
        {
            string query = $"SELECT p.*,u.* FROM managertasks.project p join user u on u.id=p.managerId";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(ConvertProject.convertDBtoProjectsWithManager(reader));
                }
                return projects;
            };
            List<Project> allProjects = DBAccess.RunReader(query, func);
            allProjects.ForEach(p =>
            {
                p.HoursForDepartment = GetHoursDepartmentsProject(p.ProjectId);
            });
            return allProjects;
        }

        /// <summary>
        /// Gets hours and worker for departments project
        /// </summary>
        /// <param name="projectId">idProject</param>
        /// <returns>List<HourForDepartment>-HourForDepartment </returns>
        public static List<HourForDepartment> GetHoursDepartmentsProject(int projectId)
        {
            string query = $"SELECT * FROM managertasks.hourfordepartment h join department d on d.id=h.departmentId where projectId={projectId};";
            Func<MySqlDataReader, List<HourForDepartment>> func = (reader) =>
            {
                List<HourForDepartment> hoursDepartments = new List<HourForDepartment>();
                while (reader.Read())
                {
                    hoursDepartments.Add(ConvertDepartment.ConvertToHoursDepartmentProject(reader));
                }
                return hoursDepartments;
            };
            List<HourForDepartment> departmentsProject = DBAccess.RunReader(query, func);
            departmentsProject.ForEach(h =>
            {
                h.WorkersInDepartment = GetWorkersByDepartmentAndProject(h.DepartmentId, projectId);
            });
            return (departmentsProject.Count() != 0 ? departmentsProject : new List<HourForDepartment>());
        }

        /// <summary>
        /// Gets project details
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project</returns>
        public static Project GetProjectDetails(int projectId)
        {
            string query = $"SELECT * FROM managetasks.project WHERE projectId={projectId}";
            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(ConvertProject.convertDBtoProjects(reader));
                    projects.Last().HoursForDepartment = GetHoursDepartmentsProject(reader.GetInt32(0));
                }
                return projects;
            };

            return (DBAccess.RunReader(query, func).Count() != 0 ? DBAccess.RunReader(query, func)[0] : null);

        }

        /// <summary>
        /// Remove project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>bool true-succsess remove, false-failed remove</returns>
        public static bool RemoveProject(int projectId)
        {
            string query = $"DELETE FROM `managertasks`.`project`WHERE projectId ={projectId}";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="project">project</param>
        /// <returns>bool true-succsess update, false-failed update</returns>
        public static bool UpdateProject(Project project)
        {
            int finish = project.IsFinish ? 1 : 0;
            string query = $"UPDATE managertasks.project SET numHour='{project.NumHourForProject}',name='{project.ProjectName}',dateBegin='{project.DateBegin.ToString("yyyy-MM-dd")}' ,dateEnd='{project.DateEnd.ToString("yyyy-MM-dd")}' ,isFinish=b'{finish}',customerName='{project.CustomerName}'  WHERE projectId={project.ProjectId} ";
            if (DBAccess.RunNonQuery(query) != null)
            {
                foreach (var hoursDepartment in project.HoursForDepartment)
                {
                    if (UpdateHoursDepartmentForProject(hoursDepartment, project.ProjectId) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Update hours for departments project
        /// </summary>
        /// <param name="hourForDepartment">hourForDepartment- contain idDepartment, idProject, numHours</param>
        /// <param name="projectId">bool true-succsess update, false-failed update</param>
        /// <returns></returns>
        public static bool UpdateHoursDepartmentForProject(HourForDepartment hourForDepartment, int projectId)
        {
            string query = $"UPDATE  `managertasks`.`hourfordepartment` set sumHours={hourForDepartment.SumHours}  where departmentId={hourForDepartment.DepartmentId}  and projectId={projectId}";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Update status Project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>bool true-succsess update, false-failed update</returns>
        public static bool UpdateStatusProject(int projectId)
        {
            string query = $"UPDATE managetasks.project SET  isFinish='{true}'  WHERE id={projectId} ";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Add worker to project
        /// </summary>
        /// <param name="projectId">idProject</param>
        /// <param name="workers">List<ProjectWorker> contain list of userId, HoursForProject</param>
        /// <returns>bool true-succsess added, false-failed added</returns>
        public static bool AddWorkerToProject(int projectId, List<ProjectWorker> workers)
        {
            foreach (var item in workers)
            {
                string query = $"INSERT INTO `managertasks`.`projectworker`(`projectId`,`hoursForProject`,`id`)VALUES({ projectId},{item.HoursForProject},{ item.UserId }); ";
                if (DBAccess.RunNonQuery(query) == null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Add project
        /// </summary>
        /// <param name="project">project</param>
        /// <returns>bool true-succsess added, false-failed added</returns>
        public static bool AddProject(Project project)
        {
            string dateBegin = project.DateBegin.ToString("yyyy-MM-dd");
            string dateEnd = project.DateEnd.ToString("yyyy-MM-dd");
            int IsFinish = project.IsFinish ? 1 : 0;

            string query = $"start transaction; INSERT INTO `managertasks`.`project`(`numHour`,`name`,`dateBegin`,`dateEnd`,`isFinish`,`customerName`,`managerId`) VALUES({project.NumHourForProject},'{project.ProjectName}','{dateBegin}','{dateEnd}',{IsFinish},'{project.CustomerName}',{project.IdManager}); ";
            foreach (var item in project.HoursForDepartment)
            {
                query += $" SET @EE=0;SELECT MAX(projectId) FROM project INTO @EE; INSERT INTO `managertasks`.`hourfordepartment`(`projectId`,`departmentId`,`sumHours`)VALUES(@EE,{item.DepartmentId},{item.SumHours});";
            }
            query += " commit;";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        ///Send email day before dead line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static List<SendEmailEndProject> SendEmailDateProjectEnd()
        {
            Func<MySqlDataReader, List<SendEmailEndProject>> func = (reader) =>
            {
                List<SendEmailEndProject> workerSendEmail = new List<SendEmailEndProject>();
                while (reader.Read())
                {
                    workerSendEmail.Add(ConvertSendEmail.convertDBtoProjects(reader));
                }
                return workerSendEmail;
            };
           return  DBAccess.RunReader(func, "SendEmailEndProject", new List<string>(), new List<string>());
           
        }
       
        /// <summary>
        /// Create report WorkerReport
        /// </summary>
        /// <param name="viewName">viewName </param>
        /// <returns>List<ReportWorker></returns>
        public static List<ReportWorker> CreateReportsWorker(string viewName)
        {
            Func<MySqlDataReader, List<ReportWorker>> func = (reader) =>
            {
                List<ReportWorker> reportWorker = new List<ReportWorker>();
                while (reader.Read())
                {
                    reportWorker.Add(ConvertReport.ConvertDBtoReportWorker(reader));
                }
                return reportWorker;
            };

            List<ReportWorker> reportWorkers = DBAccess.RunReader(func, "report", new List<string>() { viewName }, new List<string>() { "viewName" });
            reportWorkers.ForEach(r =>
            {
                r.ParentId = 0;
                r.Items = GetReportWorkerDetailsById(r.Id);
            });

            return reportWorkers;
        }

        /// <summary>
        /// Gets report worker details- create report with self reference
        /// </summary>
        /// <param name="idWorker">idUser</param>
        /// <returns>List<ReportWorker>-</returns>
        public static List<ReportWorker> GetReportWorkerDetailsById(int idWorker)
        {
            Func<MySqlDataReader, List<ReportWorker>> func = (reader) =>
            {
                List<ReportWorker> reportWorker = new List<ReportWorker>();
                while (reader.Read())
                {
                    ReportWorker reportWorker1 = ConvertReport.ConvertDBtoWorkersReport(reader);
                    reportWorker1.Id = index++;
                    reportWorker1.ParentId = idWorker;
                    reportWorker.Add(reportWorker1);
                }
                return reportWorker;
            };
            return DBAccess.RunReader(func, "reportWorker", new List<string>() { idWorker.ToString() }, new List<string>() { "idWorker" });

        }

        /// <summary>
        /// Create report WorkerReport
        /// </summary>
        /// <param name="viewName">viewName </param>
        /// <returns>List<ReportWorker></returns>
        public static List<ReportProject> CreateReportsProject(string viewName)
        {

            Func<MySqlDataReader, List<ReportProject>> func = (reader) =>
            {
                List<ReportProject> reportProject = new List<ReportProject>();
                while (reader.Read())
                {
                    reportProject.Add(ConvertReport.ConvertDBtoReport(reader));
                }
                return reportProject;
            };
            List<ReportProject> reportProjects = DBAccess.RunReader(func, "report", new List<string>() { viewName }, new List<string>() { "viewName" });
            foreach (var item in reportProjects)
            {
                item.Items = GetDepartmentsWorkersProject(item.Id);
            }

            return reportProjects;
        }

        /// <summary>
        /// Gets department to reportProject
        /// </summary>
        /// <param name="id">idProject</param>
        /// <returns>List<ReportProject></returns>
        private static List<ReportProject> GetDepartmentsWorkersProject(int id)
        {
            Func<MySqlDataReader, List<ReportProject>> func = (reader) =>
            {
                List<ReportProject> reportProject = new List<ReportProject>();
                while (reader.Read())
                {
                    reportProject.Add(ConvertReport.ConvertDBtoDepartment(reader));
                }
                return reportProject;
            };
            List<ReportProject> departmentProjects = DBAccess.RunReader(func, "departmensProject", new List<string>() { id.ToString() }, new List<string>() { "Id" });
            foreach (var item in departmentProjects)
            {
                item.Items = GetWorkersByDepartmentAndProject(item.Id, id);
                item.SumHoursDo = item.Items.Sum(p => p.SumHoursDo);
            }
            return departmentProjects;
        }

        /// <summary>
        /// Gets workers to departments project
        /// </summary>
        /// <param name="idDepartment">idDepartment</param>
        /// <param name="idProject">idProject</param>
        /// <returns></returns>
        private static List<ReportProject> GetWorkersByDepartmentAndProject(int idDepartment, int idProject)
        {
            string query = $"SELECT * FROM managertasks.sumhoursforuserproject WHERE projectId={idProject} and departmentUserId={idDepartment}";
            Func<MySqlDataReader, List<ReportProject>> func = (reader) =>
            {
                List<ReportProject> workersReport = new List<ReportProject>();
                while (reader.Read())
                {
                    workersReport.Add(ConvertReport.ConvertDBtoWorkerInReport(reader));

                }
                return workersReport;
            };

            return DBAccess.RunReader(query, func);
        }

    }
}
