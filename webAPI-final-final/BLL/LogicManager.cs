
using _00_DAL;
using BOL;
using BOL.Convertors;
using BOL.HelpModel;
using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;

namespace BLL
{
    public class LogicManager
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List<User> </returns>
        public static List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM user u JOIN department d ON u.departmentUserId=d.id LEFT JOIN user uu ON u.managerId=uu.id ;";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUserWithManager(reader));
                }
                return users;
            };
            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Check if exist user with same password
        /// </summary>
        /// <returns>bool true- exists user , false- no exists</returns>
        public static bool PasswordUnique(string password)
        {
            string query = $"select count(password) from user where user.password='{password}';";
            return Convert.ToInt32(DBAccess.RunScalar(query)) == 0 ? true : false;
        }

        /// <summary>
        /// Get all departments
        /// </summary>
        /// <returns> List<DepartmentUser>- all departments</returns>
        public static List<DepartmentUser> GetAllDepartments()
        {
            string query = $"SELECT * FROM managertasks.department  ";

            Func<MySqlDataReader, List<DepartmentUser>> func = (reader) =>
            {
                List<DepartmentUser> departments = new List<DepartmentUser>();
                while (reader.Read())
                {
                    departments.Add(ConvertDepartment.convertDBtoDepartment(reader));
                }
                return departments;
            };

            return DBAccess.RunReader(query, func);
        }


        /// <summary>
        /// Forgot password-check if userName exists if exists send Email with link to change password
        /// </summary>
        /// <param name="userName">userName</param>
        /// <returns>bool- true if exists false if not found</returns>
        public static bool ForgetPassword(string userName)
        {
            string query = $"SELECT * FROM managertasks.user WHERE userName='{userName}'";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }

                return users;
            };
            List<User> user = DBAccess.RunReader(query, func);
            //Inserts into table requestpassword- userName and idRequest
            if (user.Count > 0)
            {
                query = $" START TRANSACTION;INSERT INTO requestpassword(userName,startDate,endDate) value('{userName}','{DateTime.Now}' '{DateTime.Today.AddDays(1)}');  SELECT max(idRequest) from requestpassword;  commit";
                int result = Convert.ToInt32(DBAccess.RunScalar(query));
                return SendEmail("chany55488@gmail.com", user[0].Email, "change password", $@"<a href='http://localhost:4200/changePassword/{result}'>change password</a>");
            }
            return false;
        }


        /// <summary>
        /// Get users by department
        /// </summary>
        /// <param name="departmentName"> department name</param>
        /// <returns>List<User>-users in this department</returns>
        public static List<User> GetUserByDepartment(string departmentName)
        {
            string query = $"SELECT * FROM managertasks.user JOIN managertasks.department ON user.departmentUserId=department.id WHERE Department='{departmentName}'";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUserWithDepartment(reader));
                }
                return users;
            };
            return DBAccess.RunReader(query, func);
        }


        /// <summary>
        /// Gets the amount of hours they did the worker to a specific team project and project. 
        /// </summary>
        /// <param name="teamleaderId">teamLeaderId</param>
        /// <param name="projectId">projectId</param>
        /// <returns>List<SumHoursDoneUser>sum hours done worker</returns>
        public static List<SumHoursDoneUser> GetSumHoursDoneForUsers(int teamleaderId, int projectId)
        {
            string query = $"SELECT sum(sumHours),u.userName FROM presentday p JOIN user u on u.id= p.id WHERE u.managerId ={teamleaderId} AND projectId={projectId} GROUP BY u.id";

            Func<MySqlDataReader, List<SumHoursDoneUser>> func = (reader) =>
            {
                List<SumHoursDoneUser> users = new List<SumHoursDoneUser>();
                while (reader.Read())
                {
                    users.Add(ConvertSumHoursUser.convertDBtoSumHoursUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets sum of hours a worker has worked on according to his projects
        /// </summary>
        /// <param name="userId">workerId</param>
        /// <returns>List<SumHoursDoneUser>- sum hours worked according project</returns>
        public static List<SumHoursDoneUser> GetHoursForUserProjects(int userId)
        {
            string query = $"SELECT * FROM sumHoursForUserProject WHERE id={userId}";

            Func<MySqlDataReader, List<SumHoursDoneUser>> func = (reader) =>
            {
                List<SumHoursDoneUser> users = new List<SumHoursDoneUser>();
                while (reader.Read())
                {
                    users.Add(ConvertSumHoursUser.convertDBtoSumHoursUser1(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets hour for projects and all projects of worker
        /// </summary>
        /// <param name="userId">workerId</param>
        /// <returns>List<ProjectWorker></returns>
        public static List<ProjectWorker> GetHoursAndProjectForUser(int userId)
        {
            string query = $"SELECT pw.projectId,pw.id,pw.hoursForProject,p.name,u.userName FROM   project p JOIN projectworker pw ON  p.projectId =pw.projectId JOIN user u ON pw.id =u.id WHERE pw.id={userId}";

            Func<MySqlDataReader, List<ProjectWorker>> func = (reader) =>
            {
                List<ProjectWorker> users = new List<ProjectWorker>();
                while (reader.Read())
                {
                    users.Add(ConvertProjectWorker.convertDBtoProjectWorkersWithProjectAndUserShort(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets the amount of hours they did the worker to a specific team project and project. 
        /// </summary>
        /// <param name="teamleaderId">teamLeaderId</param>
        /// <param name="projectId">projectId</param>
        /// <returns>List<SumHoursDoneUser>sum hours done worker</returns>
        public static List<SumHoursDoneUser> GetWorkerHourDoProjects(int teamleaderId, int idProject)
        {
            string query = $"SELECT sum(pd.sumHours),u.userName  FROM user u JOIN projectworker pw ON pw.id = u.id LEFT JOIN presentday pd ON pd.id = u.id WHERE u.managerId = {teamleaderId} AND pw.projectId = {idProject} AND pd.projectId = {idProject} GROUP BY pw.projectId ,pw.id ";

            Func<MySqlDataReader, List<SumHoursDoneUser>> func = (reader) =>
            {
                List<SumHoursDoneUser> sumHoursDoneUser = new List<SumHoursDoneUser>();
                while (reader.Read())
                {
                    sumHoursDoneUser.Add(ConvertSumHoursUser.convertDBtoSumHoursUser(reader));
                }
                return sumHoursDoneUser;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets workers that work in this project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns> List<ProjectWorker>-worker in this project</returns>
        public static List<ProjectWorker> GetUsersBelongProjects(int projectId)
        {
            string query = $"SELECT * FROM project p JOIN projectworker pw ON  p.projectId =pw.projectId JOIN user u ON pw.id =u.id WHERE pw.projectId={projectId} AND pw.isActive=true";
            List<ProjectWorker> projectWorker = new List<ProjectWorker>();
            Func<MySqlDataReader, List<ProjectWorker>> func = (reader) =>
            {
                List<ProjectWorker> projectWorkers = new List<ProjectWorker>();
                while (reader.Read())
                {
                    projectWorkers.Add(ConvertProjectWorker.convertDBtoProjectWorkersWithProjectAndUser(reader));
                }
                return projectWorkers;
            };

            projectWorker = DBAccess.RunReader(query, func);
            if (projectWorker != null)
                foreach (var item in projectWorker)
                {
                    query = $" SELECT sum(sumHours) FROM managertasks.presentday where id ={item.UserId} and projectId ={item.ProjectId}";
                    string result = DBAccess.RunScalar(query).ToString();
                    item.SumHoursDone = result != string.Empty ? decimal.Parse(result.ToString()) : 0;
                }
            return projectWorker;
        }

        /// <summary>
        /// Gets simple workers not- manager, teamLeader
        /// </summary>
        /// <returns>List<User> users -simple workers</returns>
        public static List<User> GetWorkers()
        {
            string query = $"SELECT * FROM managertasks.user JOIN managertasks.department ON user.departmentUserId=department.id WHERE Department NOT IN ('teamLeader','manager')";

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

        /// <summary>
        /// Gets projects of teamLeader
        /// </summary>
        /// <param name="id">teamLeaderId</param>
        /// <returns></returns>
        public static List<Project> GetProjectsManager(int tamLeaderId)
        {
            string query = $"SELECT * FROM managertasks.project  WHERE managerId ={tamLeaderId}";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projectsList = new List<Project>();
                while (reader.Read())
                {
                    projectsList.Add(ConvertProject.convertDBtoProjects(reader));
                }
                return projectsList;
            };

            List<Project> managerProjects = DBAccess.RunReader(query, func);
            managerProjects.ForEach(p =>
            {
                p.HoursForDepartment = LogicProjects.GetHoursDepartmentsProject(p.ProjectId);
            });
            return managerProjects;
        }

        /// <summary>
        /// Gets Worker projects
        /// </summary>
        /// <param name="id">workerId</param>
        /// <returns>List<ProjectWorker>- worker projects</returns>
        public static List<ProjectWorker> GetProjectsUser(int id)
        {
            string query = $"SELECT *,(select sum(sumHours) from presentday pd where pd.id=pw.id and pd.projectId=p.projectId group by id) as sumHoursDone FROM managertasks.projectworker pw join project p on  pw.projectId = p.projectId where pw.id = {id} and p.isFinish=false ";
            Func<MySqlDataReader, List<ProjectWorker>> func = (reader) =>
            {
                List<ProjectWorker> projectsList = new List<ProjectWorker>();
                while (reader.Read())
                {
                    projectsList.Add(ConvertProjectWorker.convertDBtoProjectWorkersWithProject(reader));
                }
                return projectsList;
            };

            return DBAccess.RunReader(query, func);
        }

        /// <summary>
        /// Gets user details
        /// </summary>
        /// <param name="id">userId</param>
        /// <returns></returns>
        public static User GetUserDetails(int id)
        {
            string query = $"SELECT * FROM managertasks.user JOIN managertasks.department ON user.departmentUserId=department.id WHERE user.id={id}";
            List<User> users = new List<User>();
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> projectsWorker = new List<User>();
                while (reader.Read())
                {
                    projectsWorker.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return projectsWorker;
            };
            List<User> users1 = DBAccess.RunReader(query, func);
            return users1 != null && users1.Count > 0 ? users1[0] as User : null;
        }

        /// <summary>
        /// Gets user by Password- login
        /// </summary>
        /// <param name="user">user- contain userName and password</param>
        /// <returns>User</returns>
        public static User GetUserDetailsByPassword(LoginUser user)
        {
            string query = $"SELECT * FROM managertasks.user JOIN managertasks.department ON user.departmentUserId=department.id  WHERE password='{user.Password}' AND userName='{user.UserName}'";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUserWithDepartment(reader));
                }
                return users;
            };

            List<User> usersLogin = DBAccess.RunReader(query, func);
            if (usersLogin != null && usersLogin.Count > 0 && user.Ip != null)
            {
                query = $"SET SQL_SAFE_UPDATES=0;    UPDATE `managertasks`.`user`SET`userComputer` = '{user.Ip}' WHERE password = '{user.Password}' ";
                DBAccess.RunNonQuery(query);
                return usersLogin[0];
            }
            if (usersLogin != null && usersLogin.Count > 0)
                return usersLogin[0];
            return null;

        }

        /// <summary>
        /// Remove user
        /// </summary>
        /// <param name="id">userId</param>
        /// <returns></returns>
        public static bool RemoveUser(int id)
        {
            string query = $"DELETE FROM managertasks.user WHERE id={id}";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user">Userv to update</param>
        /// <returns>bool- true if succsess false- if failed </returns>
        public static bool UpdateUser(User user)
        {
            string query;
            query = user.ManagerId == 0 || user.ManagerId == null ? $"SET SQL_SAFE_UPDATES=0;  UPDATE managertasks.user SET userName='{user.UserName}',departmentUserId={user.DepartmentId} ,email='{user.Email}',userComputer='{user.UserComputer}',numHourWork={user.NumHoursWork}  WHERE id={user.UserId} " : $"SET SQL_SAFE_UPDATES=0; UPDATE managertasks.user SET userName='{user.UserName}',departmentUserId={user.DepartmentId} ,managerId={user.ManagerId} ,email='{user.Email}',userComputer='{user.UserComputer}',numHourWork={user.NumHoursWork}  WHERE id={user.UserId} ";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="user">User to add</param>
        /// <returns>bool- true if success to add user false if failed to add user</returns>
        public static bool AddUser(User user)
        {
            string query;
            if (user.ManagerId == 0 || user.ManagerId == null)
                query = $"INSERT INTO `managertasks`.`user`(`userName`,`userComputer`,`password`,`departmentUserId`,`email`,`numHourWork`) VALUES('{user.UserName}','{user.UserComputer}','{user.Password}',{user.DepartmentId},'{user.Email}',{user.NumHoursWork}); ";
            else query = $"INSERT INTO `managertasks`.`user`(`userName`,`userComputer`,`password`,`departmentUserId`,`email`,`numHourWork`,`managerId`) VALUES('{user.UserName}','{user.UserComputer}','{user.Password}',{user.DepartmentId},'{user.Email}',{user.NumHoursWork},{user.ManagerId}); ";
            return DBAccess.RunNonQuery(query) != null;
        }

        /// <summary>
        /// Gets user details by ip
        /// </summary>
        /// <param name="computerUser">ip</param>
        /// <returns></returns>
        public static User GetUserDetailsComputerUser(string computerUser)
        {
            string query = $" SELECT* FROM managertasks.user JOIN managertasks.department ON user.departmentUserId = department.id  WHERE userComputer = '{computerUser}'";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUserWithDepartment(reader));

                }
                return users;
            };

            List<User> usersLogin = DBAccess.RunReader(query, func);
            if (usersLogin != null && usersLogin.Count > 0)
            {
                return usersLogin[0];
            }
            return null;
        }

        /// <summary>
        /// Gets manager user
        /// </summary>
        /// <param name="idUser">userId</param>
        /// <returns></returns>
        public static User GetUserManager(int idUser)
        {
            string query = $" select uu.* from user u join user uu on u.managerId=uu.id where u.id={idUser}";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            List<User> manager = DBAccess.RunReader(query, func);
            if (manager != null && manager.Count > 0)
            {
                return manager[0];
            }
            return null;
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="requestId">requestId of changePassword</param>
        /// <param name="user">User- contain userName and new password</param>
        /// <returns></returns>
        public static bool ChangePassword(int requestId, LoginUser user)
        {
            string query = $"select count(*) from requestpassword where idRequest={requestId} and userName='{user.UserName}' and CURDATE()>";
            int result = Convert.ToInt32(DBAccess.RunScalar(query));
            if (result == 1)
            {
                query = $"SET SQL_SAFE_UPDATES=0;  UPDATE `managertasks`.`user`SET`password` = '{ user.Password }' WHERE `userName` = '{ user.UserName}'";
                return DBAccess.RunNonQuery(query) != null;
            }
            return false;
        }

        /// <summary>
        /// Send Message to Manager-TeamLeader User
        /// </summary>
        /// <param name="idUser">userId</param>
        /// <param name="message">message contain -subject and body of email</param>
        /// <returns></returns>
        public static bool SendMessageToManagers(int idUser, SendEmail message)
        {
            User manager = GetUserManager(idUser);
            User user = GetUserDetails(idUser);
            if (manager == null)
                return false;
            return SendEmail(user.Email, manager.Email, message.Subject, message.Body);
        }

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="emailFrom">from-address email</param>
        /// <param name="emailTo">to- address email</param>
        /// <param name="sub">subject email</param>
        /// <param name="message">body email</param>
        /// <returns>bool true- succses to send email, false- failed to send email</returns>
        public static bool SendEmail(string emailFrom, string emailTo, string sub, string message)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["emailManager"].ToString(),
               ConfigurationManager.AppSettings["emailManagerPassword"].ToString());
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(emailFrom);
            msg.To.Add(new MailAddress(emailTo));
            msg.Subject = sub;
            msg.IsBodyHtml = true;
            msg.Body = string.Format($"<html><head>הודעה שנשלחה</head><body><p>{message}</br></p></body>");
            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

