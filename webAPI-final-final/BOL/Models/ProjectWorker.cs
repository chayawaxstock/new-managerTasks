using System.ComponentModel.DataAnnotations;

namespace BOL.Models
{
    public class ProjectWorker
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int UserId { get; set; }

        public decimal HoursForProject { get; set; }

        public bool IsActive { get; set; } = true;

        public Project Project { get; set; }

        public User User { get; set; }

        public decimal SumHoursDone { get; set; }

        public decimal MadePercent { get; set; }

        public double DaysLeft  { get; set; }
    }
}
