using BOL.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace BOL.Models
{
    public class PresentDay
    {
        public int PresentDayId { get; set; }

        [ValidDateToday]
        public DateTime TimeBegin { get; set; }

        [ValidDateToday]
        public DateTime TimeEnd { get; set; }

        public decimal SumHoursDay { get; set; }

        [Required(ErrorMessage = "UserId is Required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "ProjectId is Required")]
        public int ProjectId { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }

    }
}
