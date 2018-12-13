using manageTask.Validations;
using System;

namespace manageTask.Models
{
    public class PresentDay
    {
        public int PresentDayId { get; set; }

        [ValidDateTimeBegin]
        public DateTime TimeBegin { get; set; }

        [ValidDateTimeEnd]
        public DateTime TimeEnd { get; set; }

        public decimal SumHoursDay { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }


    }
}
