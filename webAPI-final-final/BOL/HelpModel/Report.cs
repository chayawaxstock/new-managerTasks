using System;
using System.Collections.Generic;

namespace BOL.HelpModel
{
    public class ReportProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal TotalHours { get; set; }
        public decimal SumHoursDo { get; set; }
        public decimal PrecentsDone { get; set; }
        public int Daysleft { get; set; }
        public bool IsFinish { get; set; }
        public string TeamLeader { get; set; }
        public List<ReportProject> Items { get; set; } = new List<ReportProject>();
    }
}
