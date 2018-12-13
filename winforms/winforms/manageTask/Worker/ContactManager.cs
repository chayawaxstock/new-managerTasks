using manageTask.HelpModel;
using manageTask.Logic;
using System;
using System.Linq;

namespace manageTask
{
    public partial class ContactManager : Telerik.WinControls.UI.RadForm
    {
        public ContactManager()
        {
            InitializeComponent();
            AddStyle();
        }
        public void AddStyle()
        {
            GlobalStyle.SetStyleForm(Controls);
            GlobalStyle.SetMiddle(gb_email);
        }

        private void btn_send_message_Click(object sender, EventArgs e)
        {
            SendEmail sendMassage = new SendEmail();
            sendMassage.Body = txt_Body.Text;
            sendMassage.Subject = txt_Body.Text;
            if (ModelState.IsValid(sendMassage))
                UserRequests.SendMessage(GlobalProp.CurrentUser.UserId, sendMassage);
            else
            {
                foreach (var item in ModelState.Results)
                {
                    errorProvider1.SetError(Controls["txt_" + item.MemberNames.ToList()[0]], item.ErrorMessage);
                }
            }
        }

    }
}
