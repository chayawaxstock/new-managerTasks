

using manageTask.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using Telerik.WinControls.UI.Export;
using System.Diagnostics;

namespace manageTask.Manager11
{
    public partial class ReportProject : Telerik.WinControls.UI.RadForm
    {

        public DataTable dataSource = new DataTable();

        public ReportProject()
        {
            InitializeComponent();
        }
        private DataTable CreateDataSource()
        {
            dataSource = new DataTable();
            dataSource.Columns.Add("ID", typeof(int));
            dataSource.Columns.Add("ParentID", typeof(int));
            dataSource.Columns.Add("Name", typeof(string));
            dataSource.Columns.Add("TotalHours", typeof(decimal));
            dataSource.Columns.Add("SumHourWork", typeof(decimal));
            dataSource.Columns.Add("PresentDoing", typeof(decimal));
            dataSource.Columns.Add("DaysStay", typeof(int));
            dataSource.Columns.Add("DateBegin", typeof(DateTime));
            dataSource.Columns.Add("DateEnd", typeof(DateTime));
            dataSource.Columns.Add("IsFinish", typeof(bool));
            dataSource.Columns.Add("CustomerName", typeof(string));

            List<HelpModel.ReportProject> reportProjects = ReportRequests.CreateReportProjects();
            int index = 1;
            reportProjects.ForEach(project =>
            {

                int projectId = index++;

                dataSource.Rows.Add(
                    projectId, 0, project.Name, project.TotalHours
                    , project.SumHoursDo, project.PrecentsDone, project.Daysleft, project.DateBegin,
                    project.DateEnd, project.IsFinish, project.CustomerName);

                project.Items.ForEach(departmentHours =>
                {
                    int departmentHoursId = index++;

                    dataSource.Rows.Add(
                      departmentHoursId, projectId, departmentHours.Name, departmentHours.TotalHours,
                      departmentHours.SumHoursDo, departmentHours.PrecentsDone);

                    departmentHours.Items.ForEach(worker =>
                    {
                        dataSource.Rows.Add(index++, departmentHoursId, worker.Name,
                        worker.TotalHours, worker.SumHoursDo, worker.PrecentsDone);
                    });
                });
            });

            radGridView1.EnableHotTracking = true;
            radGridView1.EnableAlternatingRowColor = true;
            radGridView1.AutoGenerateHierarchy = true;
            radGridView1.EnableFiltering = true;
            radGridView1.ShowFilteringRow = true;
            radGridView1.MasterTemplate.EnableFiltering = true;

            return dataSource;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            radGridView1.AllowAddNewRow = false;
            radGridView1.TableElement.RowHeight = 40;

            radGridView1.ReadOnly = true;

            radGridView1.DataSource = CreateDataSource();
            radGridView1.Relations.AddSelfReference(this.radGridView1.MasterTemplate, "ID", "ParentID");

            radGridView1.Columns["ID"].IsVisible = false;
            radGridView1.Columns["ParentID"].IsVisible = false;
            radGridView1.Columns["DateBegin"].FormatString = "{0:dd/MM/yyyy}";
            radGridView1.Columns["DateEnd"].FormatString = "{0:dd/MM/yyyy}";

            radGridView1.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            radGridView1.Columns[0].BestFit();
            radGridView1.EnableFiltering = true;
            radGridView1.MasterTemplate.DataView.BypassFilter = true;        
        }
        private void radButtonPrint_Click(object sender, EventArgs e)
        {
            radGridView1.Print(true, radPrintDocument1);
        }
        private void radButtonPrintPreview_Click(object sender, EventArgs e)
        {
            RadPrintPreviewDialog dialog1 = new RadPrintPreviewDialog();
            dialog1.ThemeName = radGridView1.ThemeName;
            dialog1.Document = radPrintDocument1;
            dialog1.StartPosition = FormStartPosition.CenterScreen;
            dialog1.ShowDialog();
        }
        private void radButtonPrintSettings_Click(object sender, EventArgs e)
        {
            GridViewPrintSettingsDialog dialog = new GridViewPrintSettingsDialog();
            dialog.ThemeName = radGridView1.ThemeName;
            dialog.ShowPreviewButton = false;
            dialog.PrintDocument = radPrintDocument1;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                radButtonPrintPreview_Click(sender, e);
            }
        }
        private void radButtonExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(radGridView1.ThemeName);
                RadMessageBox.Show("Please enter a file name.");
                return;
            }

            string fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;

            switch (ListViewOption.SelectedIndex)
            {
                case 0: //export to excelML
                    RunExportToExcelML(fileName, ref openExportFile);
                    break;

                case 1: //export to CSV
                    RunExportToCSV(fileName, ref openExportFile);
                    break;

                case 2: //export to HTML
                    RunExportToHTML(fileName, ref openExportFile);
                    break;

                case 3: //export to PDF
                    RunExportToPDF(fileName, ref openExportFile);
                    break;
            }

            if (openExportFile)
            {
                try
                {
                    Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }
        private void RunExportToExcelML(string fileName, ref bool openExportFile)
        {
            ExportToExcelML excelExporter = new ExportToExcelML(this.radGridView1);

            //set export settings
            excelExporter.ExportVisualSettings = true;
            excelExporter.ExportHierarchy = true;
            excelExporter.HiddenColumnOption = HiddenOption.DoNotExport;

            try
            {
                Cursor = Cursors.WaitCursor;

                excelExporter.RunExport(fileName);

                RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
                DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                    "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RunExportToCSV(string fileName, ref bool openExportFile)
        {
            ExportToCSV csvExporter = new ExportToCSV(this.radGridView1);
            csvExporter.CSVCellFormatting += csvExporter_CSVCellFormatting;

            //set export settings
            csvExporter.ExportHierarchy = true;
            csvExporter.HiddenColumnOption = HiddenOption.DoNotExport;

            try
            {
                Cursor = Cursors.WaitCursor;

                csvExporter.RunExport(fileName);

                RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
                DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                    "Export to CSV", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        void csvExporter_CSVCellFormatting(object sender, Telerik.WinControls.UI.Export.CSV.CSVCellFormattingEventArgs e)
        {
            if (e.GridCellInfo.ColumnInfo is GridViewDateTimeColumn)
            {
                e.CSVCellElement.Value = BaseService.FormatDate(e.CSVCellElement.Value);
            }
        }
        private void RunExportToHTML(string fileName, ref bool openExportFile)
        {
            ExportToHTML htmlExporter = new ExportToHTML(radGridView1);
            htmlExporter.HTMLCellFormatting += htmlExporter_HTMLCellFormatting;
            //set export settings
            htmlExporter.ExportVisualSettings = true;
            htmlExporter.ExportHierarchy = true;
            htmlExporter.HiddenColumnOption = HiddenOption.DoNotExport;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                htmlExporter.RunExport(fileName);

                RadMessageBox.SetThemeName(radGridView1.ThemeName);
                DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                    "Export to HTML", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        void htmlExporter_HTMLCellFormatting(object sender, Telerik.WinControls.UI.Export.HTML.HTMLCellFormattingEventArgs e)
        {
            if (e.GridCellInfo.ColumnInfo is GridViewDateTimeColumn)
            {
                e.HTMLCellElement.Value = BaseService.FormatDate(e.HTMLCellElement.Value);
            }
        }
        private void RunExportToPDF(string fileName, ref bool openExportFile)
        {
            ExportToPDF pdfExporter = new ExportToPDF(this.radGridView1);
            pdfExporter.PdfExportSettings.Title = "My PDF Title";
            pdfExporter.PdfExportSettings.PageWidth = 297;
            pdfExporter.PdfExportSettings.PageHeight = 210;
            pdfExporter.FitToPageWidth = true;
            pdfExporter.HTMLCellFormatting += pdfExporter_HTMLCellFormatting;

            //set export settings
            pdfExporter.ExportVisualSettings = true;
            pdfExporter.ExportHierarchy = true;
            pdfExporter.HiddenColumnOption = HiddenOption.DoNotExport;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pdfExporter.RunExport(fileName);

                RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
                DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                    "Export to PDF", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }

            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(radGridView1.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        void pdfExporter_HTMLCellFormatting(object sender, Telerik.WinControls.UI.Export.HTML.HTMLCellFormattingEventArgs e)
        {
            if (e.GridCellInfo.ColumnInfo is GridViewDateTimeColumn)
            {
                e.HTMLCellElement.Value = BaseService.FormatDate(e.HTMLCellElement.Value);
            }
        }
        private void radListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";

            switch (ListViewOption.SelectedIndex)
            {
                case 0: //export to excelML 
                    break;
                case 1: //export to CSV
                    saveFileDialog.Filter = "CSV File (*.csv)|*.csv";
                    break;
                case 2: //export to HTML
                    saveFileDialog.Filter = "Html File (*.htm)|*.htm";
                    break;
                case 3: //export to PDF
                    saveFileDialog.Filter = "PDF File (*.pdf)|*.pdf";
                    break;
            }
        }
    }
}
