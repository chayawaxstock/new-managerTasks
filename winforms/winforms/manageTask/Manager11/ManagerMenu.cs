using manageTask.Logic;
using manageTask.Manager;
using System;


namespace manageTask.Manager11
{
    public partial class ManagerMenu : Telerik.WinControls.UI.RadForm
    {
  
        public ManagerMenu()
        {
            InitializeComponent();
            IsMdiContainer = true;

            //defult open page all projects
            openPageAllProjects();
        }

        private void openPageAllProjects()
        {
            BaseService.OpenForm(new Projects(),this);
        }
        private void ManagerMenu_Load(object sender, EventArgs e)
        {  
            //user profile
            GlobalStyle.SetProfile(profile1);
            GlobalStyle.setAccessibility(accessibility1);
            GlobalStyle.SetStyleForm(Controls);
            GlobalStyle.SetSizeForm(this);
        }
      
        private void addWorkerToProjectToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BaseService.OpenForm(new AddWorkerToProject(), this);
        }
   
       
        //Show form allProject
        private void MenuItemProject_Click(object sender, EventArgs e)
        {
            BaseService.OpenForm(new Projects(),this);
        }

        //Show form add new Project
        private void MenuItemAddProject_Click(object sender, EventArgs e)
        {
            BaseService.OpenForm(new AddProject(),this);
        }

        //Show form allWorker
        private void radMenuItemAllWorkers_Click(object sender, EventArgs e)
        {
            BaseService.OpenForm(new AllWorkers(),this);
        }

        //Show form add new worker
        private void addANewWorkerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BaseService.OpenForm(new AddWorker(),this);
        }

        //Show form add report worker
        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            BaseService.OpenForm(new ReportProject(),this);
        }

        //Show form add report worker
        private void radMenuItemWorker_Click(object sender, EventArgs e)
        {
           BaseService.OpenForm(new ReportWorker(),this);
        }

      
       

    }
}

