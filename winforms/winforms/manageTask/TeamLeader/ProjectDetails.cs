using manageTask.Logic;
using manageTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using Telerik.WinControls.UI;

namespace manageTask
{
    public partial class ProjectDetails : Telerik.WinControls.UI.RadForm
    {
        public ProjectDetails()
        {
            InitializeComponent();
            Style();
        }
        public void Style()
        {
            GlobalStyle.SetStyleForm(Controls);
            grid_worker_project.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }
        private void UpdateGroupDepartmentsHours()
        {
            int y = 40;
            gb_departmentsHours.Controls.Clear();
            foreach (var item in (listProjectName.SelectedItem.Tag as Project).HoursForDepartment)
            {
                RadLabel label = new RadLabel();
                label.Location = new Point(23, y);
                label.Name = item.DepartmentUser.Department;
                label.Size = new Size(72, 21);
                label.Text = item.DepartmentUser.Department;

                RadSpinEditor spinEditor = new RadSpinEditor();
                spinEditor.Location = new System.Drawing.Point(110, y);
                spinEditor.Name = item.DepartmentUser.Department;
                spinEditor.Size = new Size(100, 20);
                spinEditor.ThemeName = "EvalFormTheme";
                spinEditor.Value = item.SumHours;
                spinEditor.ReadOnly = true;

                gb_departmentsHours.Controls.Add(label);
                gb_departmentsHours.Controls.Add(spinEditor);
                y += 40;
            }

        }
        private void ProjectDetails_Load(object sender, EventArgs e)
        {
            listProjectName.Items.Clear();

            List<Project> projects = TaskRequests.GetProjectsManager(GlobalProp.CurrentUser.UserId);
            if (projects != null)
            {
                listProjectName.Items.AddRange(projects.Select(p => new RadListDataItem() { Tag = p, Text = p.ProjectName }));
            }
        }
        private void listProjectName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Project project = listProjectName.SelectedItem.Tag as Project;

            List<User> projectWorkers = TaskRequests.GetUserBelongProject(project.ProjectId);

            if (projectWorkers != null)
            {
                grid_worker_project.DataSource = projectWorkers.Select(p => new { p.UserName, p.Email, p.NumHoursWork, p.DepartmentUser.Department });
                txt_name.Text = project.ProjectName;
                txt_customer.Text = project.CustomerName;
                txt_hour.Text = project.NumHourForProject.ToString();
                txt_date_begin.Text = project.DateBegin.ToShortDateString();
                txt_date_end.Text = project.DateEnd.ToShortDateString();
                UpdateGroupDepartmentsHours();
            }
        }
        private void btn_graf_Click(object sender, EventArgs e)
        {
            GraphHoursStatus chart = new GraphHoursStatus();
            chart.setProject(listProjectName.SelectedItem.Tag as Project);
            chart.BringToFront();
            chart.TopMost = true;
            chart.Focus();
            chart.Show();
        }
      
    }
}
