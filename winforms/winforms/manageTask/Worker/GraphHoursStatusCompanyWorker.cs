using manageTask.Logic;
using System;
using System.Collections.Generic;

namespace manageTask
{
    public partial class GraphHoursStatusCompanyWorker : Telerik.WinControls.UI.RadForm
    {
        public GraphHoursStatusCompanyWorker()
        {
            InitializeComponent();
            AddStyle();
        }
        public void AddStyle()
        {
            GlobalStyle.SetStyleForm(Controls);
            GlobalStyle.SetMiddle(graph_status_hours_for_projects);
        }
        private void GraphHoursStatusCompanyWorker_Load(object sender, EventArgs e)
        {
            Dictionary<string, decimal> projectsDictionary = TaskRequests.GetHoursUsersProject();
            graph_status_hours_for_projects.Series[0].Points.DataBindXY(projectsDictionary.Keys, projectsDictionary.Values);
            if (projectsDictionary.Count == 0)
                lbl_message.Text = "don't have projects...";
        }
    }
}
