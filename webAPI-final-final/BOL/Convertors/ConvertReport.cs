using BOL.HelpModel;
using MySql.Data.MySqlClient;

namespace BOL.Convertors
{
    public class ConvertReport
    {
        public static ReportProject ConvertDBtoReport(MySqlDataReader readerRow)
        {
            return new ReportProject()
            {
                Id = readerRow.GetInt32(0),
                TotalHours = readerRow.GetDecimal(1),
                Name = readerRow.GetString(2),
                DateBegin = readerRow.GetDateTime(3),
                DateEnd = readerRow.GetDateTime(4),
                IsFinish = readerRow.GetBoolean(5),
                CustomerName = readerRow.GetString(6),
                TeamLeader = readerRow.GetString(8),
                SumHoursDo = readerRow.IsDBNull(9) ? 0 : readerRow.GetDecimal(9),
                Daysleft = readerRow.GetInt32(10),
                PrecentsDone = readerRow.IsDBNull(11) ? 0 : readerRow.GetDecimal(11)
            };
        }

        public static ReportWorker ConvertDBtoReportWorker(MySqlDataReader readerRow)
        {
            return new ReportWorker()
            {
                Id = readerRow.GetInt32(0),
                Name = readerRow.GetString(1),
                SumHoursDo = readerRow.GetInt32(2),
                TotalHours = readerRow.GetInt32(3)
            };
        }

        public static ReportProject ConvertDBtoDepartment(MySqlDataReader readerRow)
        {
            return new ReportProject()
            {
                Id = readerRow.GetInt32(0),
                Name = readerRow.GetString(1),
                TotalHours = readerRow.IsDBNull(2) ? 0 : readerRow.GetDecimal(2),
                SumHoursDo = readerRow.IsDBNull(3) ? 0 : readerRow.GetDecimal(3),
                PrecentsDone = readerRow.IsDBNull(4) ? 0 : readerRow.GetDecimal(4)
            };
        }

        public static ReportProject ConvertDBtoWorkerInReport(MySqlDataReader readerRow)
        {
            return new ReportProject()
            {
                SumHoursDo = readerRow.IsDBNull(0) ? 0 : readerRow.GetDecimal(0),
                PrecentsDone = readerRow.IsDBNull(1) ? 0 : readerRow.GetDecimal(1),
                TotalHours = readerRow.IsDBNull(2) ? 0 : readerRow.GetDecimal(2),
                Name = readerRow.GetString(5),
                Id = readerRow.GetInt32(4)
            };
        }

        public static ReportWorker ConvertDBtoWorkersReport(MySqlDataReader readerRow)
        {
            return new ReportWorker()
            {
                Year = readerRow.GetInt32(0),
                Month = readerRow.GetInt32(1),
                Name = readerRow.GetString(2),
                TotalHours = readerRow.GetDecimal(3),
                SumHoursDo = readerRow.GetDecimal(4),
                SumHoursDoMonth = readerRow.GetDecimal(5),
                PrecentsDone = readerRow.GetDecimal(3) == 0 ? 0 : readerRow.GetDecimal(5) / readerRow.GetDecimal(3) * 100
            };
        }
    }
}
