namespace manageTask
{
    partial class GraphHoursStatusCompanyWorker
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graph_status_hours_for_projects = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lbl_message = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.graph_status_hours_for_projects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_message)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // graph_status_hours_for_projects
            // 
            this.graph_status_hours_for_projects.AccessibleDescription = "";
            this.graph_status_hours_for_projects.AccessibleName = "";
            chartArea1.Name = "ChartArea1";
            this.graph_status_hours_for_projects.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graph_status_hours_for_projects.Legends.Add(legend1);
            this.graph_status_hours_for_projects.Location = new System.Drawing.Point(43, 37);
            this.graph_status_hours_for_projects.Margin = new System.Windows.Forms.Padding(4);
            this.graph_status_hours_for_projects.Name = "graph_status_hours_for_projects";
            this.graph_status_hours_for_projects.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graph_status_hours_for_projects.Series.Add(series1);
            this.graph_status_hours_for_projects.Size = new System.Drawing.Size(538, 426);
            this.graph_status_hours_for_projects.TabIndex = 1;
            this.graph_status_hours_for_projects.Text = "chart1";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(405, 114);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(2, 2);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.ThemeName = "MaterialTeal";
            // 
            // lbl_message
            // 
            this.lbl_message.Location = new System.Drawing.Point(246, 59);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(2, 2);
            this.lbl_message.TabIndex = 3;
            this.lbl_message.ThemeName = "MaterialTeal";
            // 
            // GraphHoursStatusCompanyWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 514);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.graph_status_hours_for_projects);
            this.Name = "GraphHoursStatusCompanyWorker";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "GraphHoursStatusCompanyWorker";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.GraphHoursStatusCompanyWorker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graph_status_hours_for_projects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_message)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graph_status_hours_for_projects;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lbl_message;
    }
}