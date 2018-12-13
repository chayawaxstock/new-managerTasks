using manageTask.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace manageTask.Models
{

    public class Project
    {

        public Project()
        {

            HoursForDepartment = new List<HourForDepartment>();
            PresentsDayUser = new List<PresentDay>();
            Workers = new List<User>();
        }

        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "ProjectName grade than 15 chars"), MinLength(2, ErrorMessage = "ProjectName less than 2 chars")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "CustomerName is required")]
        [MaxLength(15, ErrorMessage = "CustomerName grade than 15 chars"), MinLength(2, ErrorMessage = "CustomerName less than 2 chars")]
        public string CustomerName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "numHourForProject not grate than 1")]
        public decimal NumHourForProject { get; set; }


        [Required(ErrorMessage = "DateBegin is required")]
        [ValidDateTimeBegin]
        public DateTime DateBegin { get; set; }


        [Required(ErrorMessage = "DateEnd is required")]
        [ValidDateTimeEnd]
        public DateTime DateEnd { get; set; }

        public bool IsFinish { get; set; } = false;

        public int IdManager { get; set; }

        public User Manager { get; set; }

        [ValidSumHourDepartment]
        public List<HourForDepartment> HoursForDepartment { get; set; }

        public List<PresentDay> PresentsDayUser { get; set; }

        public List<User> Workers { get; set; }

    }
}
