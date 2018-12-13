using manageTask.Logic;
using manageTask.Manager;
using manageTask.Manager11;
using manageTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

namespace manageTask
{
    public partial class AddWorker : Telerik.WinControls.UI.RadForm
    {
        public AddWorker()
        {
            InitializeComponent();
            radWaitingBar1.Hide();
        } 
        public User GetWorker()
        {
            User worker = new User();
            worker.UserName = txt_UserName.Text;

            //convert password to sha256
            worker.Password = UserLogic.PasswordToSHA(txt_Password.Text);
            worker.ConfirmPassword= UserLogic.PasswordToSHA(txt_ConfirmPassword.Text);

            worker.NumHoursWork = txt_NumHoursWork.Value;
            worker.Email = txt_Email.Text;
            worker.DepartmentId = (cmbx_department.SelectedItem as DepartmentUser).Id;

            if (cmbx_teamLeader.Items.Count != 0)
                worker.ManagerId = (cmbx_teamLeader.SelectedItem as User).UserId;
            else
                worker.ManagerId = 0;
            return worker;
        }

        //get all departments
        public void FillComboxDepartments()
        {
            List<DepartmentUser> departments = DepartmentRequest.GetAllDepartments();
            cmbx_department.DisplayMember = "Department";
            cmbx_department.Items.AddRange((departments.ToArray()));
        }
        public void FillComboxTeamLeaders()
        {
            List<User> teamLeaders = DepartmentRequest.GetUserByDepartment(GlobalProp.TeamLeaderNameDepartment);
            if (teamLeaders != null)
            {
                cmbx_teamLeader.DisplayMember = "UserName";
                cmbx_teamLeader.Items.AddRange(teamLeaders.ToArray());
            }
        }
        public void FillComboxManagers()
        {
            List<User> managers = DepartmentRequest.GetUserByDepartment(GlobalProp.ManagerNameDepartment);
            cmbx_teamLeader.DisplayMember = "UserName";
            cmbx_teamLeader.Items.AddRange(managers.ToArray());
        }
        private void AddWorker_Load(object sender, EventArgs e)
        {
            //get all departments
            FillComboxDepartments();
            GlobalStyle.SetStyleForm(Controls);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            User worker = GetWorker();

            //check if all worker details valid
            if (ModelState.IsValid(worker))
            {
                radWaitingBar1.Show();
                radWaitingBar1.StartWaiting();

                //add worker to db
                if (UserRequests.AddUser(worker)!=null)
                {
                    //secsess add worker
                    RadMessageBox.SetThemeName(ThemeName);
                    RadMessageBox.Show("succsess", "worker added", MessageBoxButtons.OK, RadMessageIcon.None, MessageBoxDefaultButton.Button1);
                    BaseService.CloseAllPageWithoutMain();
                    new ManagerMenu().Show();
                }
                radWaitingBar1.StopWaiting();
                radWaitingBar1.Hide();
            }
            else
            {
                //model invalid set error
                foreach (var item in ModelState.Results)
                {
                    errorProvider1.SetError(Controls["txt_" + item.MemberNames.ToList()[0]], item.ErrorMessage);
                }
            }
        }
        private void cmbx_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbx_teamLeader.Items.Clear();

            //choose to add develpment,QA,QX,UI
            if ((cmbx_department.SelectedItem as DepartmentUser).Department.ToUpper() == department.DEVELOPMENT.ToString() || (cmbx_department.SelectedItem as DepartmentUser).Department.ToUpper() == department.UI.ToString() || (cmbx_department.SelectedItem as DepartmentUser).Department.ToUpper() == department.UX.ToString() || (cmbx_department.SelectedItem as DepartmentUser).Department.ToUpper() == department.QA.ToString())
            {
                cmbx_teamLeader.Visible = true;
                lbl_team_leader.Visible = true;

                //get all the teamleaders
                FillComboxTeamLeaders();

            }

            //choose to add teamLeader
            else if ((cmbx_department.SelectedItem as DepartmentUser).Department.ToUpper() == department.TEAMLEADER.ToString())
            {
                cmbx_teamLeader.Visible = true;
                lbl_team_leader.Text = "Manager";
                lbl_team_leader.Visible = true;

                //get all Managers
                FillComboxManagers();

            }

            //choose add manager
            else if ((cmbx_department.SelectedItem as DepartmentUser).Department.ToUpper() == department.MANAGER.ToString())
            {
                cmbx_teamLeader.Visible = false;
                lbl_team_leader.Visible = false;
            }

        }
    }
}

