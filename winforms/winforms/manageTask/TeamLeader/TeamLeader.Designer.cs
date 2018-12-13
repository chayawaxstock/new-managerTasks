namespace manageTask
{
    partial class TeamLeader
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
            Telerik.WinControls.ThemeSource themeSource1 = new Telerik.WinControls.ThemeSource();
            Telerik.WinControls.ThemeSource themeSource2 = new Telerik.WinControls.ThemeSource();
            Telerik.WinControls.ThemeSource themeSource3 = new Telerik.WinControls.ThemeSource();
            this.menuStrip1 = new Telerik.WinControls.UI.RadMenu();
            this.projectsDetailsToolStripMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.graphHoursStatusToolStripMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.editHoursForWorkerToolStripMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.rad = new Telerik.WinControls.RadThemeManager();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.accessibility1 = new Accessibility.Accessibility();
            this.profile1 = new Profile.Profile();
            ((System.ComponentModel.ISupportInitialize)(this.menuStrip1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Controls.Add(this.profile1);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.projectsDetailsToolStripMenuItem,
            this.graphHoursStatusToolStripMenuItem,
            this.editHoursForWorkerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1586, 49);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.ThemeName = "MaterialTeal";
            // 
            // projectsDetailsToolStripMenuItem
            // 
            this.projectsDetailsToolStripMenuItem.Name = "projectsDetailsToolStripMenuItem";
            this.projectsDetailsToolStripMenuItem.Text = "Project\'s details";
            this.projectsDetailsToolStripMenuItem.Click += new System.EventHandler(this.projectsDetailsToolStripMenuItem_Click_1);
            // 
            // graphHoursStatusToolStripMenuItem
            // 
            this.graphHoursStatusToolStripMenuItem.Name = "graphHoursStatusToolStripMenuItem";
            this.graphHoursStatusToolStripMenuItem.Text = "Graph hours status";
            this.graphHoursStatusToolStripMenuItem.Click += new System.EventHandler(this.graphHoursStatusToolStripMenuItem_Click_1);
            // 
            // editHoursForWorkerToolStripMenuItem
            // 
            this.editHoursForWorkerToolStripMenuItem.Name = "editHoursForWorkerToolStripMenuItem";
            this.editHoursForWorkerToolStripMenuItem.Text = "Edit hours for worker";
            this.editHoursForWorkerToolStripMenuItem.Click += new System.EventHandler(this.editHoursForWorkerToolStripMenuItem_Click_1);
            // 
            // rad
            // 
            this.rad.LoadedThemes.AddRange(new Telerik.WinControls.ThemeSource[] {
            themeSource1,
            themeSource2});
            // 
            // radThemeManager1
            // 
            this.radThemeManager1.LoadedThemes.AddRange(new Telerik.WinControls.ThemeSource[] {
            themeSource3});
            // 
            // accessibility1
            // 
            this.accessibility1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.accessibility1.Location = new System.Drawing.Point(1502, 536);
            this.accessibility1.Name = "accessibility1";
            this.accessibility1.Size = new System.Drawing.Size(72, 56);
            this.accessibility1.TabIndex = 4;
            // 
            // profile1
            // 
            this.profile1.BackColor = System.Drawing.Color.Transparent;
            this.profile1.Location = new System.Drawing.Point(1300, 4);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(262, 41);
            this.profile1.TabIndex = 0;
            // 
            // TeamLeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1586, 604);
            this.Controls.Add(this.accessibility1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TeamLeader";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "TeamLeader";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.TeamLeader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuStrip1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadMenu menuStrip1;
        private Telerik.WinControls.UI.RadMenuItem projectsDetailsToolStripMenuItem;
        private Telerik.WinControls.UI.RadMenuItem graphHoursStatusToolStripMenuItem;
        private Telerik.WinControls.UI.RadMenuItem editHoursForWorkerToolStripMenuItem;
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.RadThemeManager rad;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Profile.Profile profile1;
        private Accessibility.Accessibility accessibility1;
    }
}