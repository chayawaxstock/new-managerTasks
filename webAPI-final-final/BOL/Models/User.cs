using BOL.Models;
using BOL.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BOL
{
    public class User
    {
        public User()
        {
            ProjectsWorkers = new List<ProjectWorker>();
            Users = new List<User>();
        }

        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "name must be more than 2 chars"), MaxLength(15, ErrorMessage = "name must be less than 15 chars")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [UniquePassword]
        [MinLength(64), MaxLength(64)]
        public string Password { get; set; }

        [MinLength(64), MaxLength(64)]
        [Required(ErrorMessage = "ConfirmPassword is required")]
        [ConfirmPassword]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [UniqueEmail]
        [EmailAddress]
        public string Email { get; set; }

        public string UserComputer { get; set; } = "";

        [Range(1,12,ErrorMessage = "NumHoursWork betwween 1-12")]
        public decimal NumHoursWork { get; set; } = 9;

        public int? ManagerId { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }

        public DepartmentUser DepartmentUser { get; set; }
        public List<ProjectWorker> ProjectsWorkers { get; set; }
        public User Manager { get; set; }
        public List<User> Users { get; set; }

    }
}
