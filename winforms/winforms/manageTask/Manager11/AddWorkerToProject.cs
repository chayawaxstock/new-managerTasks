using manageTask.Logic;
using manageTask.Manager11;
using manageTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace manageTask
{
    public partial class AddWorkerToProject : Telerik.WinControls.UI.RadForm
    {

        Project project;
        public AddWorkerToProject()
        {
            InitializeComponent();
        }
        public void setProject(Project project)
        {
            this.project = project;
        }

        //remove worker
        private void RemoveWorker(string userName)
        {
            bool isDelete = false;
            int index = -1;
            for (int i = 0; i < selectedWorkers.Controls.Count; i++)
            {
                if (selectedWorkers.Controls[i].Name == userName)
                {
                    index = i;
                    isDelete = true;
                    y -= 60;
                }
                if (isDelete)
                {
                    if (selectedWorkers.Controls.Count != 0)
                        selectedWorkers.Controls[i].Location = new Point(19, selectedWorkers.Controls[i].Location.Y - 60);
                }
            }
            selectedWorkers.Controls.Remove(selectedWorkers.Controls[index]);
        }

        //add hour work to worker
        int y = 20;
        public void AddNumWorke(string nameWorker)
        {
            RadGroupBox radGroupBox = new RadGroupBox()
            {
                AccessibleRole = AccessibleRole.Grouping,
                HeaderText = "",
                Location = new Point(19, y),
                Name = nameWorker,
                Size = new System.Drawing.Size(200, 53),
                ThemeName = "MaterialTeal"
            };

            RadLabel label = new RadLabel()
            {
                Location = new Point(13, 19),
                Name = "lbl_" + nameWorker,
                Size = new Size(100, 36),
                TabIndex = 0,
                Text = nameWorker,
                ThemeName = "MaterialTeal"
            };

            RadSpinEditor spinEditor = new RadSpinEditor()
            {
                Location = new Point(94, 9),
                Name = "num_" + nameWorker,
                Size = new Size(100, 36),
                TabIndex = 1,
                ThemeName = "MaterialTeal"
            };
            radGroupBox.Controls.Add(label);
            radGroupBox.Controls.Add(spinEditor);
            selectedWorkers.Controls.Add(radGroupBox);
            y += 60;
        }
        public ListViewDataItem GetItemWorker(User worker)
        {
            ListViewDataItem item = new ListViewDataItem();
            item.Text = worker.UserName;
            item.Tag = worker;
            return item;
        }

        //add worker to project
        private void AddWorkerToProject_Load(object sender, EventArgs e)
        {
            //get all project
            List<Project> projects = TaskRequests.GetAllProjects();
            cmbx_projects.Items.AddRange(projects.Select(p => new RadListDataItem() { Tag = p, Text = p.ProjectName }));
            if (project != null && project.ProjectId != 0)
                cmbx_projects.SelectedIndex = projects.FindIndex(p => p.ProjectId == project.ProjectId);
        }
        private void btn_checkAll_Click(object sender, EventArgs e)
        {
            if (btn_checkAll.Text == "Check all")
            {
                checkedListBoxWorkers.CheckAllItems();
                btn_checkAll.Text = "Uncheck all";
            }
            else
            {
                checkedListBoxWorkers.UncheckAllItems();
                btn_checkAll.Text = "Check all";
            }
        }
        private void checkedListBoxWorkers_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            if (checkedListBoxWorkers.Items.Where(p => p.CheckState == ToggleState.On).Count() > 0)
            {
                btn_addProjectToWorker.Visible = true;
            }
            else btn_addProjectToWorker.Visible = false;

            if (e.Item.CheckState == ToggleState.On)
                AddNumWorke(((e.Item.Tag) as User).UserName);
            else RemoveWorker(((e.Item.Tag) as User).UserName);


        }
        private void cmbx_projects_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            checkedListBoxWorkers.Items.Clear();
            selectedWorkers.Controls.Clear();
            int idPprojectSelect = (cmbx_projects.SelectedItem.Tag as Project).ProjectId;
            List<User> workers = UserRequests.GetWorkerNotInProject(idPprojectSelect);
            if (workers != null)
            {
                checkedListBoxWorkers.DisplayMember = "UserName";
                foreach (User worker in workers)
                {
                    checkedListBoxWorkers.Items.Add(GetItemWorker(worker));
                }

            }

        }

        //add worker to project save in db
        private void btn_addProjectToWorker_Click(object sender, EventArgs e)
        {
            var workerAdd = checkedListBoxWorkers.CheckedItems.Select(p => p.Tag).ToList();
            int projectId = (cmbx_projects.SelectedItem.Tag as Project).ProjectId;
            List<ProjectWorker> users = new List<ProjectWorker>();

            for (int i = 0; i < workerAdd.Count(); i++)
            {
                users.Add(new ProjectWorker() { ProjectId = projectId, UserId = (workerAdd[i] as User).UserId, User = workerAdd[i] as User, HoursForProject = (selectedWorkers.Controls[i].Controls[1] as RadSpinEditor).Value });
            }


            if (BaseService.CheckValidSumHourDepartment(project, users))
            {
                bool isSuccess = UserRequests.AddWorkerToProject(projectId, users);
                if (isSuccess)
                {
                    RadMessageBox.SetThemeName(ThemeName);
                    RadMessageBox.Show("sucsess to add workers", "sucsess", MessageBoxButtons.OK, RadMessageIcon.None, MessageBoxDefaultButton.Button1);
                    BaseService.CloseAllPageWithoutMain();
                    new ManagerMenu().Show();
                }
            }
            else
            {
                for (int i = 0; i < workerAdd.Count; i++)
                {
                    errorProvider1.SetError((selectedWorkers.Controls[i].Controls[1] as RadSpinEditor), "num hour grate than sum hours for department");
                }
            }
        }
    }
}
