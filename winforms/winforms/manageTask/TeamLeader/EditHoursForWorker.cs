using manageTask.HelpModel;
using manageTask.Logic;
using manageTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Telerik.WinControls.UI;

namespace manageTask
{
    public partial class EditHoursForWorker : Telerik.WinControls.UI.RadForm
    {

        private List<ProjectWorker> tasks;

        public EditHoursForWorker()
        {
            InitializeComponent();
            Style();

        }
        public void Style()
        {
            GlobalStyle.SetMiddle(gb_hours_worker);
            GlobalStyle.SetStyleForm(Controls);
            dgv_projectHours.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }
        private void EditHoursForWorker_Load(object sender, EventArgs e)
        {
            List<User> workers = UserRequests.GetUsersOfTeamLeader(GlobalProp.CurrentUser.UserId);
            if (workers != null)
            {
                list_workers.Items.AddRange(workers.Select(p => new RadListDataItem() { Tag = p, Text = p.UserName }));
            }
        }
        private void Edit_hours(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            decimal x = Decimal.Parse(dgv_projectHours.Rows[e.RowIndex].Cells["NumHoursForProject"].Value.ToString());
            ProjectWorker projectWorker = new ProjectWorker() { UserId = (list_workers.SelectedItem.Tag as User).UserId, HoursForProject = x, ProjectId = tasks[e.RowIndex].ProjectId };
            if (TaskRequests.UpdateProjectHours(projectWorker))
                BaseService.GetMessage("sucsess update hours", "succsess");
            else BaseService.GetMessage("failed to update hours", "error");

        }
        private void list_workers_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            dgv_projectHours.Visible = true;

            int userId = (list_workers.SelectedItem.Tag as User).UserId;
            tasks = TaskRequests.GetAllTasksByUserId(userId);
            List<ProjectWithHoursForUser> selectTask = new List<ProjectWithHoursForUser>();
            if (tasks != null)
            {
                foreach (ProjectWorker item in tasks)
                {
                    selectTask.Add(new ProjectWithHoursForUser { ProjectName = item.Project.ProjectName, NumHoursForProject = item.HoursForProject });
                }
                dgv_projectHours.DataSource = tasks.Select(t=>new ProjectWithHoursForUser() { ProjectName = t.Project.ProjectName, NumHoursForProject = t.HoursForProject });
            }
        }
    }
}
