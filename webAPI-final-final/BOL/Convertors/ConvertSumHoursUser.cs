using BOL.HelpModel;
using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertSumHoursUser
    {
        public static SumHoursDoneUser convertDBtoSumHoursUser(MySqlDataReader readerRow)
        {
            return new SumHoursDoneUser()
            {
                Label = readerRow.IsDBNull(1) ? "" : readerRow.GetString(1),
                Data = readerRow.IsDBNull(0) ? 0 : readerRow.GetDecimal(0)
            };
        }

        public static SumHoursDoneUser convertDBtoSumHoursUser1(MySqlDataReader readerRow)
        {
            return new SumHoursDoneUser()
            {
                Label = readerRow.IsDBNull(3) ? "" : readerRow.GetString(3),
                Data = readerRow.IsDBNull(0) ? 0 : readerRow.GetDecimal(0)
            };
        }
    }
}
