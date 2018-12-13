namespace manageTask
{
    partial class CompanyWorkerTasks
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dvg_worker_projects = new Telerik.WinControls.UI.RadGridView();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_worker_projects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_worker_projects.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dvg_worker_projects
            // 
            this.dvg_worker_projects.Location = new System.Drawing.Point(45, 29);
            this.dvg_worker_projects.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            this.dvg_worker_projects.MasterTemplate.AllowAddNewRow = false;
            this.dvg_worker_projects.MasterTemplate.AllowColumnReorder = false;
            this.dvg_worker_projects.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dvg_worker_projects.Name = "dvg_worker_projects";
            this.dvg_worker_projects.ReadOnly = true;
            this.dvg_worker_projects.Size = new System.Drawing.Size(966, 502);
            this.dvg_worker_projects.TabIndex = 1;
            this.dvg_worker_projects.ThemeName = "MaterialTeal";
            // 
            // CompanyWorkerTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 562);
            this.Controls.Add(this.dvg_worker_projects);
            this.Name = "CompanyWorkerTasks";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CompanyWorkerTasks";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.CompanyWorkerTasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_worker_projects.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_worker_projects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dvg_worker_projects;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
    }
}