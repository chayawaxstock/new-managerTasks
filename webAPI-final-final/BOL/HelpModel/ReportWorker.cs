using System.Collections.Generic;

namespace BOL.HelpModel
{
    public  class ReportWorker
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalHours { get; set; }
        public decimal SumHoursDoMonth { get; set; }
        public decimal SumHoursDo { get; set; }
        public decimal PrecentsDone { get; set; }
        public string TeamLeader { get; set; }
        public List<ReportWorker> Items { get; set; } = new List<ReportWorker>();
    }
}
