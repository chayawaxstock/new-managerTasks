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

namespace manageTask.Manager11
{
    public partial class Projects : Telerik.WinControls.UI.ShapedForm
    {
        private const int OleHeaderSize = 78;

        public Projects()
        {
            InitializeComponent();
            AddStyle();
            AddColumsToGrid();
            GetTeamLeaders();
            FillData();
        }
        private List<Project> projects;
        private List<User> teamLeaders;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FillComboBox();
        }
        private void AddStyle()
        {
            GlobalStyle.SetStyleForm(Controls);
            radGridView1.TableElement.Padding = new Padding(0);
            radGridView1.TableElement.DrawBorder = false;
            radGridView1.TableElement.CellSpacing = -1;
            radGridView1.TableElement.Text = "";
            radGridView1.TableElement.RowHeight = 60;
            radGridView1.MasterTemplate.BestFitColumns();
            date_begin.Format = DateTimePickerFormat.Custom;
            date_End.Format = DateTimePickerFormat.Custom;
            date_begin.CustomFormat = "MMM - dd - yyyy";
            date_End.CustomFormat = "MMM - dd - yyyy";
            date_End.NullableValue = null;
            date_begin.NullableValue = null;
            radGridView1.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }
        private void AddColumsToGrid()
        {
            radGridView1.Columns.Add("ProjectName");
            radGridView1.Columns.Add("CustomerName");
            radGridView1.Columns.Add("DateBegin");
            radGridView1.Columns.Add("DateEnd");
            radGridView1.Columns.Add("NumHourForProject");
            radGridView1.Columns.Add("Manager");
            radGridView1.Columns.Add("IsFinish");

        }
        private void FillData()
        {
            projects = TaskRequests.GetAllProjects();
            foreach (var item in projects)
            {
                radGridView1.Rows.Add(item.ProjectName, item.CustomerName, item.DateBegin.ToShortDateString(), item.DateEnd.ToShortDateString(), item.NumHourForProject, item.Manager.UserName, item.IsFinish);
                radGridView1.Rows[radGridView1.Rows.Count - 1].Tag = item;
            }
        }
        private void FillComboBox()
        {
            GetTeamLeaders();
        }
        private void GetTeamLeaders()
        {
            teamLeaders = DepartmentRequest.GetUserByDepartment(GlobalProp.TeamLeaderNameDepartment);
            cmbx_teamLeader.Items.AddRange(teamLeaders.Select(p => new RadListDataItem() { Tag = p, Text = p.UserName }));
        }
        private void UpdatePanelInfo(GridViewRowInfo currentRow)
        {
            if (currentRow != null && !(currentRow is GridViewNewRowInfo))
            {
                txt_projectName.Text = BaseService.GetSafeString(currentRow.Cells["ProjectName"].Value);
                txt_customer.Text = BaseService.GetSafeString(currentRow.Cells["CustomerName"].Value);
                date_begin.Value = Convert.ToDateTime(currentRow.Cells["DateBegin"].Value);
                date_End.Value = Convert.ToDateTime(currentRow.Cells["DateEnd"].Value);
                txt_numHourProject.Text = BaseService.GetSafeString(currentRow.Cells["NumHourForProject"].Value);
                var r = (currentRow.Cells["Manager"].Value).ToString();
                cmbx_teamLeader.SelectedItem = cmbx_teamLeader.Items.FirstOrDefault(p => p.Text.Equals((currentRow.Cells["Manager"].Value).ToString()));

                if (date_begin.Value < DateTime.Now)
                {
                    date_begin.ReadOnly = true;
                }
                if ((Convert.ToBoolean(currentRow.Cells["IsFinish"].Value) == true))
                {
                    txt_projectName.ReadOnly = true;
                    txt_customer.ReadOnly = true;
                    date_begin.ReadOnly = true;
                    date_End.ReadOnly = true;
                    txt_numHourProject.ReadOnly = true;
                    cmbx_teamLeader.ReadOnly = true;
                    updateButton.Enabled = false;
                }
                else
                {
                    txt_projectName.ReadOnly = false;
                    txt_customer.ReadOnly = false;
                    date_begin.ReadOnly = false;
                    date_End.ReadOnly = false;
                    txt_numHourProject.ReadOnly = false;
                    cmbx_teamLeader.ReadOnly = false;
                    updateButton.Enabled = true;
                }
                if (radGridView1.CurrentRow.Tag != null)
                    UpdateGroupDepartmentsHours();
            }
            else
            {
                txt_projectName.Text = string.Empty;
                txt_customer.Text = string.Empty;
                txt_numHourProject.Text = string.Empty;
                cmbx_teamLeader.SelectedItem = null;
            }
        }
        private void UpdateGroupDepartmentsHours()
        {
            int y = 33;
            gb_departmentsHours.Controls.Clear();
            foreach (var item in (radGridView1.CurrentRow.Tag as Project).HoursForDepartment)
            {
                RadLabel label = new RadLabel();
                label.Location = new Point(16, y);
                label.Name = item.DepartmentUser.Department;
                label.Size = new Size(55, 18);
                label.Text = item.DepartmentUser.Department;

                RadSpinEditor spinEditor = new RadSpinEditor();
                spinEditor.Location = new System.Drawing.Point(105, y);
                spinEditor.Name = item.DepartmentUser.Department;
                spinEditor.Size = new Size(88, 22);
                spinEditor.ThemeName = "EvalFormTheme";
                spinEditor.Minimum = 1;
                spinEditor.Maximum = 120000;
                spinEditor.Value = item.SumHours;

                gb_departmentsHours.Controls.Add(label);
                gb_departmentsHours.Controls.Add(spinEditor);
                y += 37;
            }

        }
        private void UpdateGridInfo(GridViewRowInfo currentRow)
        {
            if (currentRow == null)
            {
                return;
            }
            UpdateWorkerInDB(currentRow);

        }
        private void UpdateProjectInGridView()
        {
            radGridView1.Rows.Clear();
            FillData();
        }
        private void UpdateWorkerInDB(GridViewRowInfo RowInfo)
        {
            Project editProject = GetUpdateProject();
            var isValid = ModelState.IsValid(editProject);
            if (ModelState.Results.Count <= 1)
                try
                {
                    if (TaskRequests.UpdateProject(editProject) == true)
                    {
                        RadMessageBox.SetThemeName(ThemeName);
                        RadMessageBox.Show("sucsess to update project", "sucsess", MessageBoxButtons.OK, RadMessageIcon.None, MessageBoxDefaultButton.Button1);
                        UpdateProjectInGridView();
                    }
                    else
                    {
                        RadMessageBox.SetThemeName(ThemeName);
                        RadMessageBox.Show("update project failed", "error", MessageBoxButtons.OK, RadMessageIcon.None, MessageBoxDefaultButton.Button1);
                    }

                }
                catch
                {
                    
                    RadMessageBox.SetThemeName(ThemeName);
                    RadMessageBox.Show("update project failed", "error", MessageBoxButtons.OK, RadMessageIcon.None, MessageBoxDefaultButton.Button1);
                }
            else
            {
                foreach (var item in ModelState.Results)
                {
                    if (item.MemberNames.ToList()[0] == "UX")
                        errorProvider1.SetError(gb_departmentsHours, item.ErrorMessage);
                    else errorProvider1.SetError(radPanel1.Controls["txt_" + item.MemberNames.ToList()[0]], item.ErrorMessage);
                }
            }
        }
        private Project GetUpdateProject()
        {
            return new Project()
            {
                ProjectId = (radGridView1.CurrentRow.Tag as Project).ProjectId,
                ProjectName = txt_projectName.Text,
                CustomerName = txt_customer.Text,
                NumHourForProject = txt_numHourProject.Value,
                DateBegin = date_begin.Value,
                DateEnd = date_End.Value,
                IdManager = (cmbx_teamLeader.SelectedItem.Tag as User).UserId,
                IsFinish = cxb_isFinish.Checked

            };
        }
        private void radGridView1_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                BaseService.GetMessage("can not delete project", "error");
                e.Cancel = true;
            }
        }
        private void radGridView1_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            UpdatePanelInfo(radGridView1.CurrentRow);
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateGridInfo(radGridView1.CurrentRow);
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (radGridView1.CurrentRow != null)
            {
                UpdatePanelInfo(radGridView1.CurrentRow);
            }
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            Close();
            new AddProject().Show();
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            GridViewDataRowInfo dataRowInfo = radGridView1.CurrentRow as GridViewDataRowInfo;
            BaseService.GetMessage("can not delete project", "error");
        }
        private void btn_AddWorkers_Click(object sender, EventArgs e)
        {
            AddWorkerToProject addWorkerToProject = new AddWorkerToProject();
            addWorkerToProject.setProject((radGridView1.CurrentRow.Tag as Project));
            Close();
            addWorkerToProject.Show();
        }
    }
}
