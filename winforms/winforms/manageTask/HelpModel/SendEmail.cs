using System.ComponentModel.DataAnnotations;

namespace manageTask.HelpModel
{
    public class SendEmail
    {
        [Required(ErrorMessage ="body of email required")]
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
