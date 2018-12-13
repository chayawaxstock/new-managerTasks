
using System.ComponentModel.DataAnnotations;


namespace BOL.HelpModel
{
   public class LoginUser
    {
        [Required]
        [MinLength(64),MaxLength(64)]
        public string Password { get; set; }
        [Required]
        [MinLength(2), MaxLength(15)]
        public string UserName { get; set; }
        public string Ip { get; set; }
    }
}
