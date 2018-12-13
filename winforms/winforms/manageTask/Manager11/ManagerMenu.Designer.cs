namespace manageTask.Manager11
{
    partial class ManagerMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addProjectToolStripMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemProject = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuItemAddProject = new Telerik.WinControls.UI.RadMenuItem();
            this.managmentWorkersToolStripMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.addANewWorkerToolStripMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.addWorkerToProjectToolStripMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemAllWorkers = new Telerik.WinControls.UI.RadMenuItem();
            this.reportsToolStripMenuProject = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemWorker = new Telerik.WinControls.UI.RadMenuItem();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.menuStrip1 = new Telerik.WinControls.UI.RadMenu();
            this.profile1 = new Profile.Profile();
            this.accessibility1 = new Accessibility.Accessibility();
            ((System.ComponentModel.ISupportInitialize)(this.menuStrip1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // addProjectToolStripMenuItem
            // 
            this.addProjectToolStripMenuItem.AutoSize = true;
            this.addProjectToolStripMenuItem.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItemProject,
            this.MenuItemAddProject});
            this.addProjectToolStripMenuItem.Name = "addProjectToolStripMenuItem";
            this.addProjectToolStripMenuItem.Text = "Projects Management";
            this.addProjectToolStripMenuItem.UseCompatibleTextRendering = false;
            // 
            // radMenuItemProject
            // 
            this.radMenuItemProject.Name = "radMenuItemProject";
            this.radMenuItemProject.Text = "Prodects";
            this.radMenuItemProject.Click += new System.EventHandler(this.MenuItemProject_Click);
            // 
            // MenuItemAddProject
            // 
            this.MenuItemAddProject.Name = "MenuItemAddProject";
            this.MenuItemAddProject.Text = "Add Project";
            this.MenuItemAddProject.Click += new System.EventHandler(this.MenuItemAddProject_Click);
            // 
            // managmentWorkersToolStripMenuItem
            // 
            this.managmentWorkersToolStripMenuItem.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.addANewWorkerToolStripMenuItem,
            this.addWorkerToProjectToolStripMenuItem,
            this.radMenuItemAllWorkers});
            this.managmentWorkersToolStripMenuItem.Name = "managmentWorkersToolStripMenuItem";
            this.managmentWorkersToolStripMenuItem.Text = "Managment workers";
            this.managmentWorkersToolStripMenuItem.UseCompatibleTextRendering = false;
            // 
            // addANewWorkerToolStripMenuItem
            // 
            this.addANewWorkerToolStripMenuItem.Name = "addANewWorkerToolStripMenuItem";
            this.addANewWorkerToolStripMenuItem.Text = "Add a new worker";
            this.addANewWorkerToolStripMenuItem.UseCompatibleTextRendering = false;
            this.addANewWorkerToolStripMenuItem.Click += new System.EventHandler(this.addANewWorkerToolStripMenuItem_Click_1);
            // 
            // addWorkerToProjectToolStripMenuItem
            // 
            this.addWorkerToProjectToolStripMenuItem.Name = "addWorkerToProjectToolStripMenuItem";
            this.addWorkerToProjectToolStripMenuItem.Text = "Add worker to project";
            this.addWorkerToProjectToolStripMenuItem.UseCompatibleTextRendering = false;
            this.addWorkerToProjectToolStripMenuItem.Click += new System.EventHandler(this.addWorkerToProjectToolStripMenuItem_Click_1);
            // 
            // radMenuItemAllWorkers
            // 
            this.radMenuItemAllWorkers.Name = "radMenuItemAllWorkers";
            this.radMenuItemAllWorkers.Text = "AllWorkers";
            this.radMenuItemAllWorkers.Click += new System.EventHandler(this.radMenuItemAllWorkers_Click);
            // 
            // reportsToolStripMenuProject
            // 
            this.reportsToolStripMenuProject.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItemWorker});
            this.reportsToolStripMenuProject.Name = "reportsToolStripMenuProject";
            this.reportsToolStripMenuProject.Text = "Reports";
            this.reportsToolStripMenuProject.UseCompatibleTextRendering = false;
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "reportProjects";
            this.radMenuItem1.Click += new System.EventHandler(this.radMenuItem1_Click);
            // 
            // radMenuItemWorker
            // 
            this.radMenuItemWorker.Name = "radMenuItemWorker";
            this.radMenuItemWorker.Text = "reportWorker";
            this.radMenuItemWorker.Click += new System.EventHandler(this.radMenuItemWorker_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Controls.Add(this.profile1);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.addProjectToolStripMenuItem,
            this.managmentWorkersToolStripMenuItem,
            this.reportsToolStripMenuProject});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(926, 37);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.ThemeName = "MaterialTeal";
            // 
            // profile1
            // 
            this.profile1.BackColor = System.Drawing.Color.Transparent;
            this.profile1.Location = new System.Drawing.Point(650, -4);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(262, 41);
            this.profile1.TabIndex = 0;
            // 
            // accessibility1
            // 
            this.accessibility1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.accessibility1.Location = new System.Drawing.Point(840, 558);
            this.accessibility1.Name = "accessibility1";
            this.accessibility1.Size = new System.Drawing.Size(72, 56);
            this.accessibility1.TabIndex = 8;
            // 
            // ManagerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 626);
            this.Controls.Add(this.accessibility1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "ManagerMenu";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ManagerMenu";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.ManagerMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuStrip1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadMenuItem addProjectToolStripMenuItem;
        private Telerik.WinControls.UI.RadMenuItem managmentWorkersToolStripMenuItem;
        private Telerik.WinControls.UI.RadMenuItem addANewWorkerToolStripMenuItem;
        private Telerik.WinControls.UI.RadMenuItem addWorkerToProjectToolStripMenuItem;
        private Telerik.WinControls.UI.RadMenuItem reportsToolStripMenuProject;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemAllWorkers;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemProject;
        private Telerik.WinControls.UI.RadMenuItem MenuItemAddProject;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemWorker;
        private Telerik.WinControls.UI.RadMenu menuStrip1;
        private Profile.Profile profile1;
        private Accessibility.Accessibility accessibility1;
    }
}
