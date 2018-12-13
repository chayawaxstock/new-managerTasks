using System;

namespace manageTask.Models
{
    public class ProjectWorker
    {
        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public decimal HoursForProject { get; set; }

        public Project Project { get; set; }

        public User User { get; set; }
     
        public decimal SumHoursDone { get; set; }

        public Double DaysLeft { get; set; }

        public decimal MadePercent { get; set; }
    }
}
