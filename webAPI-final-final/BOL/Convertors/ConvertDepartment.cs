using BOL.Models;
using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertDepartment
    {

        public static DepartmentUser convertDBtoDepartment(MySqlDataReader readerRow)
        {
            return new DepartmentUser()
            {
                Id = readerRow.GetInt32(0),
                Department = readerRow.GetString(1)
            };
        }


        public static HourForDepartment ConvertToHoursDepartmentProject(MySqlDataReader readerRow)
        {
            return new HourForDepartment()
            {
                ProjectId = readerRow.GetInt32(0),
                DepartmentId = readerRow.GetInt32(1),
                SumHours = readerRow.GetInt32(2),
                DepartmentUser = new DepartmentUser()
                {
                    Department = readerRow.GetString(4)
                }
            };
        }
    }
}
