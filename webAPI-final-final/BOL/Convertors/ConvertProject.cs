﻿using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertProject
    {
        public static Project convertDBtoProjectsWithManager(MySqlDataReader readerRow)
        {
            return new Project()
            {
                ProjectId = readerRow.GetInt32(0),
                NumHourForProject = readerRow.GetDecimal(1),
                ProjectName = readerRow.GetString(2),
                DateBegin = readerRow.GetMySqlDateTime(3).GetDateTime(),
                DateEnd = readerRow.GetMySqlDateTime(4).GetDateTime(),
                IsFinish = readerRow.GetBoolean(5),
                CustomerName = readerRow.GetString(6),
                IdManager = readerRow.GetInt32(7),
                Manager = new User()
                {
                    UserId = readerRow.GetInt32(8),
                    UserName = readerRow.GetString(9),
                    UserComputer = readerRow.IsDBNull(10) ? "" : readerRow.GetString(10),
                    DepartmentId = readerRow.GetInt32(12),
                    Email = readerRow.GetString(13),
                    NumHoursWork = readerRow.GetDecimal(14),
                    ManagerId = readerRow.IsDBNull(15) ? 0 : readerRow.GetInt32(15)
                }
            };


        }

        public static Project convertDBtoProjects(MySqlDataReader readerRow)
        {
            return new Project()
            {
                ProjectId = readerRow.GetInt32(0),
                NumHourForProject = readerRow.GetDecimal(1),
                ProjectName = readerRow.GetString(2),
                DateBegin = readerRow.GetMySqlDateTime(3).GetDateTime(),
                DateEnd = readerRow.GetMySqlDateTime(4).GetDateTime(),
                IsFinish = readerRow.GetBoolean(5),
                CustomerName = readerRow.GetString(6),
                IdManager = readerRow.IsDBNull(7) ? 0 : readerRow.GetInt32(7),
            };
        }
    }
}
