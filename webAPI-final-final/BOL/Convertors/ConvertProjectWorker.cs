using BOL.Models;
using MySql.Data.MySqlClient;
using System;

namespace BOL.Convertors
{
    public class ConvertProjectWorker
    {
        public static ProjectWorker convertDBtoProjectWorkersWithProjectAndUser(MySqlDataReader readerRow)
        {
            return new ProjectWorker()
            {
                ProjectId = readerRow.GetInt32(0),
                HoursForProject = readerRow.IsDBNull(9) ? 0 : readerRow.GetDecimal(9),
                UserId = readerRow.GetInt32(10),
                User = new User()
                {
                    UserId = readerRow.GetInt32(10),
                    UserName = readerRow.GetString(13),
                    UserComputer = readerRow.IsDBNull(14) ? "" : readerRow.GetString(14),

                    DepartmentId = readerRow.GetInt32(16),
                    Email = readerRow.GetString(17),
                    NumHoursWork = readerRow.GetDecimal(18),
                    ManagerId = readerRow.IsDBNull(19) ? 0 : readerRow.GetInt32(19),
                },
                Project = new Project()
                {
                    ProjectId = readerRow.GetInt32(0),
                    NumHourForProject = readerRow.GetDecimal(1),
                    ProjectName = readerRow.GetString(2),
                    DateBegin = readerRow.GetMySqlDateTime(3).GetDateTime(),
                    DateEnd = readerRow.GetMySqlDateTime(4).GetDateTime(),
                    IsFinish = readerRow.GetBoolean(5),
                    CustomerName = readerRow.GetString(6),
                    IdManager = readerRow.GetInt32(7),
                }
            };
        }

        public static ProjectWorker convertDBtoProjectWorkersWithProjectAndUserShort(MySqlDataReader readerRow)
        {
            return new ProjectWorker()
            {
                ProjectId = readerRow.GetInt32(0),
                UserId = readerRow.GetInt32(1),
                HoursForProject = readerRow.IsDBNull(2) ? 0 : readerRow.GetDecimal(2),
                Project = new Project()
                {
                    ProjectName = readerRow.GetString(3),
                },
                User = new User()
                {
                    UserName = readerRow.GetString(4),
                }

            };

        }

        public static ProjectWorker convertDBtoProjectWorkersWithProject(MySqlDataReader readerRow)
        {
            return new ProjectWorker()
            {
                ProjectId = readerRow.GetInt32(0),
                HoursForProject = readerRow.IsDBNull(1) ? 0 : readerRow.GetDecimal(1),
                UserId = readerRow.GetInt32(2),
                SumHoursDone = readerRow.IsDBNull(12) ? 0 : readerRow.GetDecimal(12),
                DaysLeft = (readerRow.GetMySqlDateTime(8).GetDateTime() - DateTime.Now).TotalDays,
                MadePercent = readerRow.IsDBNull(12) || readerRow.IsDBNull(1) || readerRow.GetDecimal(1) == 0 ? 0 : readerRow.GetDecimal(12) / readerRow.GetDecimal(1) * 100,
                Project = new Project()
                {
                    ProjectId = readerRow.GetInt32(4),
                    NumHourForProject = readerRow.GetDecimal(5),
                    ProjectName = readerRow.GetString(6),
                    DateBegin = readerRow.GetMySqlDateTime(7).GetDateTime(),
                    DateEnd = readerRow.GetMySqlDateTime(8).GetDateTime(),
                    IsFinish = readerRow.GetBoolean(9),
                    CustomerName = readerRow.GetString(10),
                    IdManager = readerRow.GetInt32(11),
                }
            };

        }
    }
}
