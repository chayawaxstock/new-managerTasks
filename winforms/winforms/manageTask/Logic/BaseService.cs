using Accessibility;
using manageTask.Manager11;
using manageTask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Telerik.WinControls;

namespace manageTask.Logic
{
    public class BaseService
    {
        /// <summary>
        /// DateDiffInDays
        /// </summary>
        /// <param name="dateBegin">dateBegin</param>
        /// <param name="dateEnd">dateEnd</param>
        /// <returns></returns>
        public static int DateDiffInDays(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan duration = dateEnd - dateBegin;
            return int.Parse(duration.TotalDays.ToString());
        }

        /// <summary>
        /// ParseStringToInt
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>int- number</returns>
        public static int ParseStringToInt(string s)
        {
            return Convert.ToInt32(s);
        }

        //TODO
        public static bool CheckValidSumHourDepartment(Project project, List<ProjectWorker> ProjectWorker)
        {
            return true;
        }

      

        /// <summary>
        /// GetSafeString
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>string</returns>
        public static string GetSafeString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.ToString();
        }

        /// <summary>
        /// GetErrorsFromServer
        /// </summary>
        /// <param name="ex">errors</param>
        public static void GetErrorsFromServer(WebException ex)
        {
            try
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    RadMessageBox.SetThemeName(GlobalStyle.ThemName);
                    RadMessageBox.Show(new Form() { TopMost = true, TopLevel = true }, reader.ReadToEnd(), "errors", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch
            {
                GetMessage("error", "error");
            }

        }

        /// <summary>
        /// GetMessage
        /// </summary>
        /// <param name="mess">message</param>
        /// <param name="header">header</param>
        public static void GetMessage(string mess, string header)
        {
            RadMessageBox.SetThemeName(GlobalStyle.ThemName);
            RadMessageBox.Show(new Form() { TopMost = true, TopLevel = true }, mess, header, MessageBoxButtons.OK);
        }

        /// <summary>
        /// GetDepartmentUser
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>Form- to open from this department</returns>
        public static Form GetDepartmentUser(User user)
        {
            if (user != null)
            {
                //Enters an appropriate page according to the permission
                if (user.DepartmentUser.Department.ToUpper() == department.MANAGER.ToString())
                {
                    return new ManagerMenu();
                }

                else if (user.DepartmentUser.Department.ToUpper() == department.TEAMLEADER.ToString())
                {
                    return new TeamLeader();
                }
                else
                {
                    return new CompanyWorker();
                }
            }
            else return new Login();
        }

        /// <summary>
        /// FormatDate
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>string</returns>
        public static string FormatDate(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.ToString("d MMM yyyy");
            }
            return value.ToString();
        }

        /// <summary>
        /// OpenForm
        /// </summary>
        /// <param name="f">Form</param>
        /// <param name="parent">parent form</param>
        public static void OpenForm(Form f, Form parent)
        {
            f.MdiParent = parent;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// LogoutClicked
        /// </summary>
        public static void LogoutClicked()
        {
            GlobalProp.CurrentUser = null;
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Main")
                    Application.OpenForms[i].Close();
            }
            new Login().Show();
        }

        public static void CloseAllPageWithoutMain()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "Main")
                    f.Close();
            }
        }

    }
}
