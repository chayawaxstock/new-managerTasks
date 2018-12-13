using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertorUser
    {

        public static User convertDBtoUserWithManager(MySqlDataReader readerRow)
        {
            return new User()
            {
                UserId = readerRow.GetInt32(0),
                UserName = readerRow.GetString(1),
                UserComputer = readerRow.IsDBNull(2) ? "" : readerRow.GetString(2),
                DepartmentId = readerRow.GetInt32(4),
                Email = readerRow.GetString(5),
                NumHoursWork = readerRow.GetDecimal(6),
                ManagerId = readerRow.IsDBNull(7) ? 0 : readerRow.GetInt32(7),
                DepartmentUser = new Models.DepartmentUser()
                {
                    Id = readerRow.GetInt32(8),
                    Department = readerRow.GetString(9)
                }
               ,
                Manager = new User()
                {
                    UserId = readerRow.IsDBNull(10) ? 0 : readerRow.GetInt32(10),
                    UserName = readerRow.IsDBNull(11) ? string.Empty : readerRow.GetString(11),
                    Email = readerRow.IsDBNull(15) ? string.Empty : readerRow.GetString(15)
                }
            };
        }


        public static User convertDBtoUser(MySqlDataReader readerRow)
        {
            return new User()
            {
                UserId = readerRow.GetInt32(0),
                UserName = readerRow.GetString(1),
                UserComputer = readerRow.IsDBNull(2) ? "" : readerRow.GetString(2),
                DepartmentId = readerRow.GetInt32(4),
                Email = readerRow.GetString(5),
                NumHoursWork = readerRow.GetDecimal(6),
                ManagerId = readerRow.IsDBNull(7) ? 0 : readerRow.GetInt32(7),
            };
        }

        public static User convertDBtoUserWithDepartment(MySqlDataReader readerRow)
        {
            return new User()
            {
                UserId = readerRow.GetInt32(0),
                UserName = readerRow.GetString(1),
                UserComputer = readerRow.IsDBNull(2) ? "" : readerRow.GetString(2),
                Password = readerRow.GetString(3),
                DepartmentId = readerRow.GetInt32(4),
                Email = readerRow.GetString(5),
                NumHoursWork = readerRow.GetDecimal(6),
                ManagerId = readerRow.IsDBNull(7) ? 0 : readerRow.GetInt32(7),
                DepartmentUser = new Models.DepartmentUser()
                {
                    Id = readerRow.GetInt32(8),
                    Department = readerRow.GetString(9)
                }
            };
        }

        public static User convertDBtoNameUser(MySqlDataReader readerRow)
        {
            return new User()
            {
                UserId = readerRow.GetInt32(0),
                UserName = readerRow.GetString(1),
            };
        }
    }
}
