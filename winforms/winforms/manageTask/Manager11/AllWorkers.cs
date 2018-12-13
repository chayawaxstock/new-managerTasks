using manageTask.Logic;
using manageTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace manageTask.Manager
{
    public partial class AllWorkers : Telerik.WinControls.UI.ShapedForm
    {
        private bool selectManager = false;

        public AllWorkers()
        {
            InitializeComponent();
            AddColumsToGrid();
            FillData();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Styles();
            FillComboBox();
        }
        private void AddColumsToGrid()
        {
            radGridView1.Columns.Add("UserName");
            radGridView1.Columns.Add("Email");
            radGridView1.Columns.Add("NumHoursWork");
            radGridView1.Columns.Add("Department");
            radGridView1.Columns.Add("Manager");
        }
        private void FillData()
        {
            List<User> users = UserRequests.GetAllUsers();

            foreach (var item in users)
            {
                radGridView1.Rows.Add(item.UserName, item.Email, item.NumHoursWork, item.DepartmentUser.Department, item.Manager.UserName);
                radGridView1.Rows[radGridView1.Rows.Count - 1].Tag = item;
            }
        }
        public void Styles()
        {
            GlobalStyle.SetStyleForm(Controls);
            radGridView1.TableElement.Padding = new Padding(0);
            radGridView1.TableElement.DrawBorder = false;
            radGridView1.TableElement.CellSpacing = -1;
            radGridView1.TableElement.Text = "";
            radGridView1.TableElement.RowHeight = 80;
            radGridView1.MasterTemplate.BestFitColumns();
            radGridView1.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }
        public bool DeleteFromDb()
        { 
            DialogResult dialogResult = MessageBox.Show("Do you want to delete this worker?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if (dialogResult != DialogResult.OK)
            {
                return false;
            }
            else
            {
                if (UserRequests.DeleteUser((radGridView1.CurrentRow.Tag as User).UserId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private void UpdatePanelInfo(GridViewRowInfo currentRow)
        {
            if (currentRow != null && !(currentRow is GridViewNewRowInfo))
            {
                txt_userName.Text = BaseService.GetSafeString(currentRow.Cells["UserName"].Value);
                txt_email.Text = BaseService.GetSafeString(currentRow.Cells["Email"].Value);
                txt_numHourDay.Text = BaseService.GetSafeString(currentRow.Cells["NumHoursWork"].Value);
                cmb_department.SelectedValue = (currentRow.Cells["Department"].Value);
                cmbx_manager.SelectedValue = (currentRow.Cells["Manager"].Value);
            }
            else
            {
                txt_userName.Text = string.Empty;
                txt_email.Text = string.Empty;
                txt_numHourDay.Text = string.Empty;

                radPanel2.BackgroundImage = new Bitmap(10, 10);
                cmbx_manager.SelectedIndex = -1;
                cmbx_manager.Text = string.Empty;
            }
        }
        private void UpdateGridInfo(GridViewRowInfo currentRow)
        {
            if (currentRow == null)
            {
                return;
            }

            radGridView1.CloseEditor();
            UpdateWorkerInDB(currentRow);
            GridViewNewRowInfo newRowInfo = currentRow as GridViewNewRowInfo;
            if (newRowInfo != null)
            {
                currentRow.InvalidateRow();
            }
        }
        private void UpdateWorkerInGridView()
        {
            radGridView1.Rows.Clear();
            FillData();
        }
        private void UpdateWorkerInDB(GridViewRowInfo newRowInfo)
        {
            User editWorker = getUpdateWorker();
            editWorker.UserId = (newRowInfo.Tag as User).UserId;
            try
            {
                if (UserRequests.UpdateUser(editWorker))
                {
                    UpdateWorkerInGridView();
                }
                else
                {
                    this.radGridView1.CloseEditor();
                }
            }
            catch 
            {
                radGridView1.CloseEditor();
                RadMessageBox.SetThemeName(ThemeName);
                RadMessageBox.Show("update worker failed", "error", MessageBoxButtons.OK, RadMessageIcon.None, MessageBoxDefaultButton.Button1);
            }
        }
        private User getUpdateWorker()
        {
            int? idManager = (radGridView1.CurrentRow.Tag as User).ManagerId;
            if (selectManager)
            {
                idManager = (cmbx_manager.SelectedItem.Tag as User).UserId;
            }
            return new User()
            {

                UserName = txt_userName.Text,
                NumHoursWork = decimal.Parse(txt_numHourDay.Text),
                DepartmentId = (cmb_department.SelectedItem.Tag as DepartmentUser).Id,
                ManagerId = idManager,
                Email = txt_email.Text
            };
        }
        private void FillComboBox()
        {
            cmb_department.DisplayMember = "Department";
            GetDepartment();
        }
        private void GetDepartment()
        {
            List<DepartmentUser> departments = DepartmentRequest.GetAllDepartments();
            if (departments != null)
            {
                cmb_department.Items.AddRange(departments.Select(p => new RadListDataItem() { Tag = p, Text = p.Department }));
            }
        }
       
        private void radGridView1_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (DeleteFromDb() == false)
                    e.Cancel = true;
            }
        }
        private void radGridView1_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            UpdatePanelInfo(radGridView1.CurrentRow);
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateGridInfo(this.radGridView1.CurrentRow);
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (this.radGridView1.CurrentRow != null)
            {
                UpdatePanelInfo(this.radGridView1.CurrentRow);
            }
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            Close();
            new AddWorker().Show();
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            GridViewDataRowInfo dataRowInfo = radGridView1.CurrentRow as GridViewDataRowInfo;
            if (dataRowInfo != null)
            {
                //delete worker succsesed
                if (DeleteFromDb() == true)
                {
                    radGridView1.Rows.Remove(dataRowInfo);
                    UpdatePanelInfo(radGridView1.CurrentRow);
                }
            }
        }

        private void cmb_department_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            cmbx_manager.Items.Clear();
            //choose to change to develpment,QA,QX,UI
            if ((cmb_department.SelectedItem.Tag as DepartmentUser).Department.ToUpper() == department.DEVELOPMENT.ToString() || (cmb_department.SelectedItem.Tag as DepartmentUser).Department.ToUpper() == department.UI.ToString() || (cmb_department.SelectedItem.Tag as DepartmentUser).Department.ToUpper() == department.UX.ToString() || (cmb_department.SelectedItem.Tag as DepartmentUser).Department.ToUpper() == department.QA.ToString())
            {
                //get all the teamleaders
                List<User> teamLeaders = DepartmentRequest.GetUserByDepartment(GlobalProp.TeamLeaderNameDepartment);
                if (teamLeaders != null)
                {
                    cmbx_manager.Items.AddRange(teamLeaders.Select(p => new RadListDataItem() { Tag = p, Text = p.UserName }).ToArray());
                }
            }
            //choose to change to teamLeader
            else if ((cmb_department.SelectedItem.Tag as DepartmentUser).Department.ToUpper() == department.TEAMLEADER.ToString())
            {
                //get all Managers
                List<User> managers = DepartmentRequest.GetUserByDepartment(GlobalProp.ManagerNameDepartment);
                if (managers != null)
                    cmbx_manager.Items.AddRange(managers.Select(p => new RadListDataItem() { Tag = p, Text = p.UserName }));
            }
            //choose change to manager
            else if ((cmb_department.SelectedItem.Tag as DepartmentUser).Department.ToUpper() == department.MANAGER.ToString())
            {
                cmbx_manager.Items.Clear();
            }
        }
        private void cmbx_manager_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            selectManager = true;
        }
    }
}
