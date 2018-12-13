using System;
using System.Windows.Forms;

namespace Profile
{


    public partial class Profile: UserControl
    {
        public delegate void LogoutClickedHandler();
        public event LogoutClickedHandler logoutClicked;

        public Profile()
        {
            InitializeComponent();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
             logoutClicked();
        }
    }
}

