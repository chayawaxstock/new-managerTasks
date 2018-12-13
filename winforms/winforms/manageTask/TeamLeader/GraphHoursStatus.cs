using manageTask.Logic;
using manageTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Telerik.WinControls.UI;

namespace manageTask
{
    public partial class GraphHoursStatus : Telerik.WinControls.UI.RadForm
    {

        private Project project;
        public GraphHoursStatus()
        {
            InitializeComponent();

        }
        public void setProject(Project project)
        {
            this.project = project;
        }
        private void GraphHoursStatus_Load(object sender, EventArgs e)
        {
            GlobalStyle.SetStyleForm(Controls);
            GlobalStyle.SetMiddle(gb_graf_hours);
            List<Project> projects = TaskRequests.GetProjectsManager(GlobalProp.CurrentUser.UserId);
            if (projects != null)
            {
                dropDown_projects.Items.AddRange(projects.Select(p => new RadListDataItem() { Tag = p, Text = p.ProjectName }));
                if (project != null && project.ProjectId != 0)
                    dropDown_projects.SelectedIndex =projects.FindIndex(p=>p.ProjectId== project.ProjectId);
            }
        }
        //choose project to see chart
        private void dropDown_projects_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Dictionary<string, decimal> workersDictionary = new Dictionary<string, decimal>();
            int idProjectSelect = (dropDown_projects.SelectedItem.Tag as Project).ProjectId;

            List<SumHoursDoneUser> sumHoursDoneUsers = UserRequests.GetSumHoursDoneForUsers(idProjectSelect);
            if (sumHoursDoneUsers != null)
            {
                foreach (SumHoursDoneUser sumHoursDoneUser in sumHoursDoneUsers)
                {

                    workersDictionary.Add(sumHoursDoneUser.Label, sumHoursDoneUser.Data);
                }
                chart1.Series[0].Points.DataBindXY(workersDictionary.Keys, workersDictionary.Values);
            }
        }
    }
}
