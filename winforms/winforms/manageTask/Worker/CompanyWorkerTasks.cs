using manageTask.Logic;
using manageTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Telerik.WinControls.UI;

namespace manageTask
{
    public partial class CompanyWorkerTasks : Telerik.WinControls.UI.RadForm
    {
        public CompanyWorkerTasks()
        {
            InitializeComponent();
            AddStyle();
        }

        public void AddStyle()
        {
            GlobalStyle.SetStyleForm(Controls);
            GlobalStyle.SetMiddle(dvg_worker_projects);
            
        }

        private void CompanyWorkerTasks_Load(object sender, EventArgs e)
        {
            List<ProjectWorker> projects = TaskRequests.GetProjectsById(GlobalProp.CurrentUser.UserId);

            if (projects.Count>0)
            {
                dvg_worker_projects.DataSource = projects.Select(p => new { p.Project.ProjectName,p.Project.DateBegin,p.Project.DateEnd, p.HoursForProject, p.SumHoursDone,p.MadePercent,p.DaysLeft }).ToList();
                dvg_worker_projects.Columns["DateBegin"].FormatString = "{0:dd/MM/yyyy}";
                dvg_worker_projects.Columns["DateEnd"].FormatString = "{0:dd/MM/yyyy}";
                this.dvg_worker_projects.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
