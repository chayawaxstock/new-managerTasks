using manageTask.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace manageTask.Manager11
{
    public partial class ReportWorker : Telerik.WinControls.UI.RadForm
    {

        List<HelpModel.ReportWorker> reportWorker;
        public DataTable dataSource = new DataTable();

        public ReportWorker()
        {
            InitializeComponent();

            //LIST OF FILLTERS
            List<string> month = new List<string>() { "January", "February", "March ", "April ", "May", "June", "July", "August", "September", "October", "November", "December" };
            listMonth.Items.AddRange(month.Select(p => new RadListDataItem() { Text = p }));

            List<string> years = new List<string>();
            years.Add("all");

            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                years.Add(i.ToString());
            }
            listYear.Items.AddRange(years.Select(p => new RadListDataItem() { Text = p }));

        }

        private DataTable CreateDataSource(int? year, int? month)
        {
            dataSource = new DataTable();
            dataSource.Columns.Add("ID", typeof(int));
            dataSource.Columns.Add("ParentID", typeof(int));
            dataSource.Columns.Add("Name", typeof(string));
            dataSource.Columns.Add("Year", typeof(int));
            dataSource.Columns.Add("Month", typeof(int));
            dataSource.Columns.Add("TotalHours", typeof(decimal));
            dataSource.Columns.Add("SumHoursDo", typeof(decimal));
            dataSource.Columns.Add("PrecentsDone", typeof(decimal));
            dataSource.Columns.Add("SumHoursDoMonth", typeof(decimal));
            dataSource.Columns.Add("Department", typeof(bool));
            dataSource.Columns.Add("TeamLeader", typeof(string));

            //create report hirarcy self reference
            reportWorker = ReportRequests.CreateReportWorker();
            int index = 1;
            reportWorker.ForEach(worker =>
            {
                int workerId = index++;
                dataSource.Rows.Add(
                    workerId, 0, worker.Name, worker.Year, worker.Month, worker.TotalHours,
                    worker.SumHoursDo, worker.PrecentsDone, worker.SumHoursDoMonth, worker.Department,
                    worker.TeamLeader
                   );

                if (worker.Items != null)
                    worker.Items.ForEach(pressent =>
                    {
                        int? pressentId = null;
                        if (month == null && year == null || year == null && worker.Month == month ||
                        month == null && year == worker.Year || worker.Month == month && year == worker.Year)
                        {
                            pressentId = index++;

                            dataSource.Rows.Add(
                          pressentId, workerId, pressent.Name, pressent.Year, pressent.Month,
                          pressent.TotalHours, pressent.SumHoursDo, pressent.PrecentsDone, pressent.SumHoursDoMonth);
                        }
                    });
            });

            return dataSource;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //definitions of grid
            radGridView1.EnableHotTracking = true;
            radGridView1.EnableAlternatingRowColor = true;
            radGridView1.AutoGenerateHierarchy = true;
            radGridView1.EnableFiltering = true;
            radGridView1.ShowFilteringRow = true;
            radGridView1.MasterTemplate.EnableFiltering = true;
            radGridView1.AllowAddNewRow = false;
            radGridView1.TableElement.RowHeight = 40;
            radGridView1.ReadOnly = true;
            radGridView1.DataSource = CreateDataSource(null, null);
            radGridView1.Relations.AddSelfReference(radGridView1.MasterTemplate, "ID", "ParentID");
            radGridView1.Columns["ID"].IsVisible = false;
            radGridView1.Columns["ParentID"].IsVisible = false;
            radGridView1.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            radGridView1.Columns[0].BestFit();
            radGridView1.MasterTemplate.DataView.BypassFilter = true;

        }
        private void radButtonPrint_Click(object sender, EventArgs e)
        {
           radGridView1.Print(true, this.radPrintDocument1);
        }
        private void radButtonPrintPreview_Click(object sender, EventArgs e)
        {
            RadPrintPreviewDialog dialog1 = new RadPrintPreviewDialog();
            dialog1.ThemeName = this.radGridView1.ThemeName;
            dialog1.Document = this.radPrintDocument1;
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
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog1.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
                RadMessageBox.Show("Please enter a file name.");
                return;
            }

            string fileName = this.saveFileDialog1.FileName;
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
                this.Cursor = Cursors.WaitCursor;

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
                this.Cursor = Cursors.Default;
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
                this.Cursor = Cursors.WaitCursor;

                csvExporter.RunExport(fileName);

                RadMessageBox.SetThemeName(radGridView1.ThemeName);
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
                this.Cursor = Cursors.Default;
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
            ExportToHTML htmlExporter = new ExportToHTML(this.radGridView1);
            htmlExporter.HTMLCellFormatting += htmlExporter_HTMLCellFormatting;
            //set export settings
            htmlExporter.ExportVisualSettings = true;
            htmlExporter.ExportHierarchy = true;
            htmlExporter.HiddenColumnOption = HiddenOption.DoNotExport;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                htmlExporter.RunExport(fileName);

                RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
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
                RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
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
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";

            switch (this.ListViewOption.SelectedIndex)
            {
                case 0: //export to excelML 
                    break;
                case 1: //export to CSV
                    saveFileDialog1.Filter = "CSV File (*.csv)|*.csv";
                    break;
                case 2: //export to HTML
                    saveFileDialog1.Filter = "Html File (*.htm)|*.htm";
                    break;
                case 3: //export to PDF
                    saveFileDialog1.Filter = "PDF File (*.pdf)|*.pdf";
                    break;
            }
        }

        //fillter by year
        private void listYear_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (listYear.SelectedIndex == 0)
                CreateDataSource(null, null);
            else CreateDataSource(listYear.SelectedIndex + 2000, null);
        }

        //fillter by month
        private void listMonth_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int? year = null;
            if (listYear.SelectedIndex != -1)
                year = listYear.SelectedIndex + 2000;
            CreateDataSource(year, listMonth.SelectedIndex + 1);
        }
    }
}
