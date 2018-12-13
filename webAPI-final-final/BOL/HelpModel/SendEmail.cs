using System.ComponentModel.DataAnnotations;

namespace BOL.HelpModel
{
    public  class SendEmail
    {
        public string Subject { get; set; }

        [Required(ErrorMessage ="body of email required")]
        [MinLength(2,ErrorMessage ="body contain less than two charecters")]
        public string Body { get; set; }
    }
}
