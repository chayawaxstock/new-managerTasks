using manageTask.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace manageTask
{
    public partial class CompanyWorker : Telerik.WinControls.UI.RadForm
    {
        public CompanyWorker()
        {
            InitializeComponent();

        }
        private void CompanyWorker_Load(object sender, EventArgs e)
        {
            //user profile-set user controller
            GlobalStyle.SetProfile(profile1);
            GlobalStyle.SetStyleForm(Controls);
            GlobalStyle.setClock(radClock1);
            GlobalStyle.setAccessibility(accessibility1);
            GlobalStyle.SetSizeForm(this);
        }
        //open form start work to project
        private void setTimeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BaseService.OpenForm(new SetTime(), this);
        }
        //open form send email to manager
        private void cotactTheManagerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BaseService.OpenForm(new ContactManager(), this);
        }
        //open form show chart
        private void graphHoursStatusToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BaseService.OpenForm(new GraphHoursStatusCompanyWorker(), this);
        }
        //open form to see all projects user
        private void yourTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseService.OpenForm(new CompanyWorkerTasks(), this);
        }
    }
}
