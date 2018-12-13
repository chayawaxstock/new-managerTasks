namespace manageTask
{
    partial class GraphHoursStatus
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.dropDown_projects = new Telerik.WinControls.UI.RadDropDownList();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.gb_graf_hours = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropDown_projects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_graf_hours)).BeginInit();
            this.gb_graf_hours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(176, 123);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(612, 417);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(411, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Graph hours status";
            this.label2.ThemeName = "MaterialTeal";
            // 
            // dropDown_projects
            // 
            this.dropDown_projects.Location = new System.Drawing.Point(176, 80);
            this.dropDown_projects.Name = "dropDown_projects";
            this.dropDown_projects.Size = new System.Drawing.Size(158, 36);
            this.dropDown_projects.TabIndex = 4;
            this.dropDown_projects.Text = "choose project";
            this.dropDown_projects.ThemeName = "MaterialTeal";
            this.dropDown_projects.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.dropDown_projects_SelectedIndexChanged);
            // 
            // gb_graf_hours
            // 
            this.gb_graf_hours.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gb_graf_hours.Controls.Add(this.dropDown_projects);
            this.gb_graf_hours.Controls.Add(this.label2);
            this.gb_graf_hours.Controls.Add(this.chart1);
            this.gb_graf_hours.HeaderText = "";
            this.gb_graf_hours.Location = new System.Drawing.Point(77, 23);
            this.gb_graf_hours.Name = "gb_graf_hours";
            this.gb_graf_hours.Size = new System.Drawing.Size(971, 566);
            this.gb_graf_hours.TabIndex = 5;
            this.gb_graf_hours.ThemeName = "MaterialTeal";
            // 
            // GraphHoursStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 606);
            this.Controls.Add(this.gb_graf_hours);
            this.Name = "GraphHoursStatus";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "GraphHoursStatus";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.GraphHoursStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropDown_projects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_graf_hours)).EndInit();
            this.gb_graf_hours.ResumeLayout(false);
            this.gb_graf_hours.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadDropDownList dropDown_projects;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadGroupBox gb_graf_hours;
    }
}