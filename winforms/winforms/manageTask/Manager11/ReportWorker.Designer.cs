namespace manageTask.Manager11
{
    partial class ReportWorker
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
            Telerik.WinControls.UI.ListViewDataItem listViewDataItem1 = new Telerik.WinControls.UI.ListViewDataItem("excel");
            Telerik.WinControls.UI.ListViewDataItem listViewDataItem2 = new Telerik.WinControls.UI.ListViewDataItem("clv");
            Telerik.WinControls.UI.ListViewDataItem listViewDataItem3 = new Telerik.WinControls.UI.ListViewDataItem("html");
            Telerik.WinControls.UI.ListViewDataItem listViewDataItem4 = new Telerik.WinControls.UI.ListViewDataItem("pdf");
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition12 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewRelation gridViewRelation1 = new Telerik.WinControls.UI.GridViewRelation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportWorker));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition9 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition10 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition11 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadPrintWatermark radPrintWatermark3 = new Telerik.WinControls.UI.RadPrintWatermark();
            this.ListViewOption = new Telerik.WinControls.UI.RadListView();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.gridViewTemplate1 = new Telerik.WinControls.UI.GridViewTemplate();
            this.gridViewTemplate2 = new Telerik.WinControls.UI.GridViewTemplate();
            this.gridViewTemplate3 = new Telerik.WinControls.UI.GridViewTemplate();
            this.btn_printPerview = new Telerik.WinControls.UI.RadButton();
            this.btn_printSetting = new Telerik.WinControls.UI.RadButton();
            this.btn_export = new Telerik.WinControls.UI.RadButton();
            this.btn_print = new Telerik.WinControls.UI.RadButton();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.radPrintDocument1 = new Telerik.WinControls.UI.RadPrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.listYear = new Telerik.WinControls.UI.RadDropDownList();
            this.listMonth = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.ListViewOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_printPerview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_printSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_export)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ListViewOption
            // 
            this.ListViewOption.GroupItemSize = new System.Drawing.Size(200, 36);
            listViewDataItem1.Text = "excel";
            listViewDataItem2.Text = "clv";
            listViewDataItem3.Text = "html";
            listViewDataItem4.Text = "pdf";
            this.ListViewOption.Items.AddRange(new Telerik.WinControls.UI.ListViewDataItem[] {
            listViewDataItem1,
            listViewDataItem2,
            listViewDataItem3,
            listViewDataItem4});
            this.ListViewOption.ItemSize = new System.Drawing.Size(200, 36);
            this.ListViewOption.Location = new System.Drawing.Point(837, 100);
            this.ListViewOption.Name = "ListViewOption";
            this.ListViewOption.Size = new System.Drawing.Size(113, 158);
            this.ListViewOption.TabIndex = 10;
            this.ListViewOption.ThemeName = "MaterialTeal";
            this.ListViewOption.SelectedIndexChanged += new System.EventHandler(this.radListBox1_SelectedIndexChanged);
            // 
            // radGridView1
            // 
            this.radGridView1.Location = new System.Drawing.Point(27, 136);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.Templates.AddRange(new Telerik.WinControls.UI.GridViewTemplate[] {
            this.gridViewTemplate1,
            this.gridViewTemplate2,
            this.gridViewTemplate3});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition12;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radGridView1.ReadOnly = true;
            gridViewRelation1.ChildColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ChildColumnNames")));
            gridViewRelation1.ParentColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ParentColumnNames")));
            this.radGridView1.Relations.AddRange(new Telerik.WinControls.UI.GridViewRelation[] {
            gridViewRelation1});
            this.radGridView1.Size = new System.Drawing.Size(786, 484);
            this.radGridView1.TabIndex = 9;
            this.radGridView1.ThemeName = "MaterialTeal";
            // 
            // gridViewTemplate1
            // 
            this.gridViewTemplate1.ViewDefinition = tableViewDefinition9;
            // 
            // gridViewTemplate2
            // 
            this.gridViewTemplate2.ViewDefinition = tableViewDefinition10;
            // 
            // gridViewTemplate3
            // 
            this.gridViewTemplate3.ViewDefinition = tableViewDefinition11;
            // 
            // btn_printPerview
            // 
            this.btn_printPerview.Location = new System.Drawing.Point(203, 30);
            this.btn_printPerview.Name = "btn_printPerview";
            this.btn_printPerview.Size = new System.Drawing.Size(127, 37);
            this.btn_printPerview.TabIndex = 6;
            this.btn_printPerview.Text = "printPerview";
            this.btn_printPerview.ThemeName = "MaterialTeal";
            this.btn_printPerview.Click += new System.EventHandler(this.radButtonPrintPreview_Click);
            // 
            // btn_printSetting
            // 
            this.btn_printSetting.Location = new System.Drawing.Point(356, 30);
            this.btn_printSetting.Name = "btn_printSetting";
            this.btn_printSetting.Size = new System.Drawing.Size(116, 37);
            this.btn_printSetting.TabIndex = 7;
            this.btn_printSetting.Text = "printSetting";
            this.btn_printSetting.ThemeName = "MaterialTeal";
            this.btn_printSetting.Click += new System.EventHandler(this.radButtonPrintSettings_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(834, 302);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(116, 51);
            this.btn_export.TabIndex = 8;
            this.btn_export.Text = "export";
            this.btn_export.ThemeName = "MaterialTeal";
            this.btn_export.Click += new System.EventHandler(this.radButtonExport_Click);
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(62, 29);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(116, 38);
            this.btn_print.TabIndex = 5;
            this.btn_print.Text = "print";
            this.btn_print.ThemeName = "MaterialTeal";
            this.btn_print.Click += new System.EventHandler(this.radButtonPrint_Click);
            // 
            // radPrintDocument1
            // 
            this.radPrintDocument1.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radPrintDocument1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radPrintDocument1.Watermark = radPrintWatermark3;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(27, 101);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(66, 18);
            this.radLabel1.TabIndex = 13;
            this.radLabel1.Text = "fillterByYear";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(295, 103);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(77, 18);
            this.radLabel2.TabIndex = 14;
            this.radLabel2.Text = "fillterByMonth";
            // 
            // listYear
            // 
            this.listYear.Location = new System.Drawing.Point(99, 94);
            this.listYear.Name = "listYear";
            this.listYear.Size = new System.Drawing.Size(156, 36);
            this.listYear.TabIndex = 15;
            this.listYear.ThemeName = "MaterialTeal";
            this.listYear.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.listYear_SelectedIndexChanged);
            // 
            // listMonth
            // 
            this.listMonth.Location = new System.Drawing.Point(378, 94);
            this.listMonth.Name = "listMonth";
            this.listMonth.Size = new System.Drawing.Size(166, 36);
            this.listMonth.TabIndex = 16;
            this.listMonth.ThemeName = "MaterialTeal";
            this.listMonth.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.listMonth_SelectedIndexChanged);
            // 
            // ReportWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 632);
            this.Controls.Add(this.listMonth);
            this.Controls.Add(this.listYear);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ListViewOption);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.btn_printPerview);
            this.Controls.Add(this.btn_printSetting);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_print);
            this.Name = "ReportWorker";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ReportWorker";
            this.ThemeName = "MaterialTeal";
            ((System.ComponentModel.ISupportInitialize)(this.ListViewOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_printPerview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_printSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_export)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadListView ListViewOption;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.GridViewTemplate gridViewTemplate1;
        private Telerik.WinControls.UI.GridViewTemplate gridViewTemplate2;
        private Telerik.WinControls.UI.GridViewTemplate gridViewTemplate3;
        private Telerik.WinControls.UI.RadButton btn_printPerview;
        private Telerik.WinControls.UI.RadButton btn_printSetting;
        private Telerik.WinControls.UI.RadButton btn_export;
        private Telerik.WinControls.UI.RadButton btn_print;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
        private Telerik.WinControls.UI.RadPrintDocument radPrintDocument1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList listYear;
        private Telerik.WinControls.UI.RadDropDownList listMonth;
    }
}
