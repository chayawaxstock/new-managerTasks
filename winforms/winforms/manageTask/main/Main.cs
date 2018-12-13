using manageTask.Logic;
using manageTask.Models;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace manageTask
{
    public partial class Main : Telerik.WinControls.UI.RadForm
    {

        public Main()
        {
            Visible = false;
            Hide();
            InitializeComponent();
        }

        /// <summary>
        /// Try to get ip cumputer and login with ip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            string computerIp="";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    computerIp= ip.ToString();
                }
            }
          
            User user= UserRequests.LoginByIP(computerIp);

            //enter form by premission
            Form form = BaseService.GetDepartmentUser(user);
            form.BringToFront();
            form.TopMost = true;
            form.Focus();
            form.Show();
        }
    }
}
