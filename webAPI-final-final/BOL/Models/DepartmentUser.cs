using System.Collections.Generic;

namespace BOL.Models
{
    public class DepartmentUser
    {
        public DepartmentUser()
        {
            HourForDepartments = new List<HourForDepartment>();
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string Department { get; set; }
        public List<HourForDepartment> HourForDepartments { get; set; }
        public List<User> Users { get; set; }

    }
}
