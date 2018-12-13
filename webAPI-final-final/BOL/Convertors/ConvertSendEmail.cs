using BOL.HelpModel;
using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertSendEmail
    {
        public static SendEmailEndProject convertDBtoProjects(MySqlDataReader readerRow)
        {
            return new SendEmailEndProject()
            {
                UserName = readerRow.GetString(0),
                EmailUser = readerRow.GetString(1),
                nameProject = readerRow.GetString(2),
                userNameManager = readerRow.GetString(3),
                EmailManager = readerRow.GetString(4),
                HourDo = readerRow.GetDecimal(5),
                hoursForProject = readerRow.GetDecimal(6),
                stayToDo = readerRow.GetDecimal(7)
            };
        }
    }
}
