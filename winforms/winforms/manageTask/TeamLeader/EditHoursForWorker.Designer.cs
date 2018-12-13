namespace manageTask
{
    partial class EditHoursForWorker
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dgv_projectHours = new Telerik.WinControls.UI.RadGridView();
            this.lbl_worker = new Telerik.WinControls.UI.RadLabel();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.list_workers = new Telerik.WinControls.UI.RadDropDownList();
            this.gb_hours_worker = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_projectHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_projectHours.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_worker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.list_workers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_hours_worker)).BeginInit();
            this.gb_hours_worker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_projectHours
            // 
            this.dgv_projectHours.Location = new System.Drawing.Point(54, 121);
            this.dgv_projectHours.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            this.dgv_projectHours.MasterTemplate.AllowAddNewRow = false;
            this.dgv_projectHours.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.dgv_projectHours.Name = "dgv_projectHours";
            this.dgv_projectHours.Size = new System.Drawing.Size(789, 432);
            this.dgv_projectHours.TabIndex = 7;
            this.dgv_projectHours.ThemeName = "MaterialTeal";
            this.dgv_projectHours.Visible = false;
            this.dgv_projectHours.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.Edit_hours);
            // 
            // lbl_worker
            // 
            this.lbl_worker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_worker.Location = new System.Drawing.Point(97, 59);
            this.lbl_worker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_worker.Name = "lbl_worker";
            this.lbl_worker.Size = new System.Drawing.Size(89, 19);
            this.lbl_worker.TabIndex = 6;
            this.lbl_worker.Text = "Worker name";
            this.lbl_worker.ThemeName = "MaterialTeal";
            // 
            // list_workers
            // 
            this.list_workers.Location = new System.Drawing.Point(230, 51);
            this.list_workers.Name = "list_workers";
            this.list_workers.Size = new System.Drawing.Size(172, 36);
            this.list_workers.TabIndex = 9;
            this.list_workers.Text = "choose worker";
            this.list_workers.ThemeName = "MaterialTeal";
            this.list_workers.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.list_workers_SelectedIndexChanged);
            // 
            // gb_hours_worker
            // 
            this.gb_hours_worker.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gb_hours_worker.Controls.Add(this.lbl_worker);
            this.gb_hours_worker.Controls.Add(this.dgv_projectHours);
            this.gb_hours_worker.Controls.Add(this.list_workers);
            this.gb_hours_worker.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.gb_hours_worker.HeaderText = "Edit hours for worker";
            this.gb_hours_worker.Location = new System.Drawing.Point(164, 13);
            this.gb_hours_worker.Name = "gb_hours_worker";
            this.gb_hours_worker.Size = new System.Drawing.Size(894, 579);
            this.gb_hours_worker.TabIndex = 10;
            this.gb_hours_worker.Text = "Edit hours for worker";
            this.gb_hours_worker.ThemeName = "MaterialTeal";
            // 
            // EditHoursForWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 603);
            this.Controls.Add(this.gb_hours_worker);
            this.Name = "EditHoursForWorker";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "EditHoursForWorker";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.EditHoursForWorker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_projectHours.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_projectHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_worker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.list_workers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_hours_worker)).EndInit();
            this.gb_hours_worker.ResumeLayout(false);
            this.gb_hours_worker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dgv_projectHours;
        private Telerik.WinControls.UI.RadLabel lbl_worker;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadDropDownList list_workers;
        private Telerik.WinControls.UI.RadGroupBox gb_hours_worker;
    }
}