using manageTask.HelpModel;
using manageTask.Logic;
using manageTask.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace manageTask
{
    public partial class Login : Telerik.WinControls.UI.RadForm
    {

        bool isToggleClick = false;
        public Login()
        {
            InitializeComponent();
            txt_Password.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
        }

        //get user by ip
        public UserLogin getLoginUser()
        {
            string computerIp = "";
            if (rememberMe.Checked == true)
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        computerIp = ip.ToString();
                    }
                }
            }

            return new UserLogin()
            {
                UserName = txt_UserName.Text,
                Password = UserLogic.PasswordToSHA(txt_Password.Text),
                Ip = computerIp
            };
        }


        //sign in
        private void btn_signIn_Click_1(object sender, EventArgs e)
        {

            UserLogin LoginUser = getLoginUser();
            if (checkValidUserLogin(LoginUser))
            {
                User user = UserRequests.LoginUser(LoginUser);
                    Form form = BaseService.GetDepartmentUser(user);
                    form.Show();
                    Close();
            
            }
        }


        //change type of password from password to text
   
        private void btn_show_password_Click(object sender, EventArgs e)
        {
            if (isToggleClick== true)
            {
                btn_show_password.Image = Properties.Resources.hide;
                txt_Password.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
                isToggleClick = false;
            }
            else
            {
                //Hides Textbox password
                txt_Password.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
                btn_show_password.Image = Properties.Resources.view;
                isToggleClick = true;
            }
        }


        private bool checkValidUserLogin(UserLogin loginUser)
        {
            errorProvider1.Clear();

            //check validation model
            if (ModelState.IsValid(loginUser))
            {
                return true;
            }
            else
            {
                //inValid set error
                foreach (var item in ModelState.Results)
                {
                    errorProvider1.SetError(gb_signIn.Controls["txt_" + item.MemberNames.ToList()[0]], item.ErrorMessage);
                }
                return false;
            }
        }

        //forgot password
        private void radLabel1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txt_UserName.Text == "")
            {
                errorProvider1.SetError(txt_UserName, "to change password you need enter userName");
                return;
            }
            UserRequests.ForgetPassword(txt_UserName.Text);
           
        }

      
    }
}
