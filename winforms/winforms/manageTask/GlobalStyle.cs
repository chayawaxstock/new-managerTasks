using manageTask.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace manageTask
{
   public class GlobalStyle
    {
        public static string ThemName = "MaterialTeal";
        public static Size sizeForm = Screen.PrimaryScreen.Bounds.Size;
        
        

        /// <summary>
        /// setAccessibility
        /// </summary>
        /// <param name="accessibility">user control-accessibility</param>
        public static void setAccessibility(Accessibility.Accessibility accessibility)
        {
            accessibility.Location =new Point(sizeForm.Width-accessibility.Width-10,sizeForm.Height-accessibility.Height- sizeForm.Height/10);
        }

        public static void setClock(RadClock clock)
        {
            clock.Location =new Point(sizeForm.Width -clock.Size.Width- (sizeForm.Width/20), sizeForm.Height/12) ;
        }

        /// <summary>
        /// SetProfile
        /// </summary>
        /// <param name="profile">profile- user control profile</param>
        public static void SetProfile(Profile.Profile profile)
        {
            profile.Controls["lbl_name"].Text = GlobalProp.CurrentUser.UserName;
            profile.Controls["lbl_department"].Text = GlobalProp.CurrentUser.DepartmentUser.Department;
            profile.logoutClicked += new Profile.Profile.LogoutClickedHandler(BaseService.LogoutClicked);
            profile.Location = new Point(sizeForm.Width - profile.Size.Width - 10,1);
        }

        /// <summary>
        /// set font size to controls
        /// </summary>
        /// <param name="controls">list of controls</param>
        public static void SetStyleForm(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                c.Font = Accessibility.GlobalStyle.segoeFont;
                SetStyleForm(c.Controls);
                c.FindForm().Cursor = Accessibility.GlobalStyle.cursor;
            }
        }

        public static void SetSizeForm(Form form)
        {
           form.Size = sizeForm;
        }

        public static void SetMiddle(Control control)
        {
            control.Location = new Point(sizeForm.Width / 3 - control.Size.Width / 2, sizeForm.Height / 3 - control.Size.Height / 2);
        }
    }
}
