using manageTask.Logic;
using System;
using System.Drawing;

namespace manageTask
{

    public partial class TeamLeader : Telerik.WinControls.UI.RadForm
    {

        public TeamLeader()
        {
            InitializeComponent();
        }
        private void projectsDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           BaseService.OpenForm(new ProjectDetails(),this);
        }
        private void graphHoursStatusToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BaseService.OpenForm(new GraphHoursStatus(),this);
        }
        private void editHoursForWorkerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BaseService.OpenForm(new EditHoursForWorker(),this);
        }
        private void TeamLeader_Load(object sender, EventArgs e)
        {
            //user profile
            GlobalStyle.SetProfile(profile1);
            GlobalStyle.SetStyleForm(Controls);
            GlobalStyle.setAccessibility(accessibility1);
            GlobalStyle.SetSizeForm(this);
        }

    }
}
