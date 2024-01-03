using System;
using System.IO;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace DietProject
{
    public partial class DietReportViewer : Form
    {
        int DietID;

        private class DietElement
        {
            public string ProductName { get; set; }
            public int ProductCount { get; set; }
            public string PatientName { get; set; }
            public string PatientSurname { get; set; }
            public string PatientPatronym { get; set; }
            public string PatientGender { get; set; }
            public int PatientHeight { get; set; }
            public int PatientWeight { get; set; }
        }

        public DietReportViewer(int DietID)
        {
            InitializeComponent();
            this.DietID = DietID;
            DRVreportViewer = new ReportViewer();
            DRVreportViewer.Dock = DockStyle.Fill;
            DRVreportViewer.ZoomMode = ZoomMode.PageWidth;
            Controls.Add(DRVreportViewer);
        }

        private void DietReportViewer_Load(object sender, EventArgs e)
        {
            using var fs = new FileStream("../../../DietReport.rdlc", FileMode.Open);
            DRVreportViewer.LocalReport.LoadReportDefinition(fs);
            DSS_Diet.DietDBDataSetTableAdapters.DietReportTableAdapter dietReportTableAdapter = new DSS_Diet.DietDBDataSetTableAdapters.DietReportTableAdapter();
            DSS_Diet.DietDBDataSet.DietReportDataTable DietReport = new DSS_Diet.DietDBDataSet.DietReportDataTable();
            dietReportTableAdapter.Fill(DietReport, DietID);
            List<DietElement> deList = new List<DietElement>();
            foreach (DataRow row in DietReport.Rows)
            {
                DietElement de = new DietElement
                {
                    ProductName = row["ProductName"].ToString(),
                    ProductCount = Convert.ToInt32(row["ProductCount"]),
                    PatientName = row["PatientName"].ToString(),
                    PatientSurname = row["PatientSurname"].ToString(),
                    PatientPatronym = row["PatientPatronym"].ToString(),
                    PatientGender = row["PatientGender"].ToString(),
                    PatientHeight = Convert.ToInt32(row["PatientHeight"]),
                    PatientWeight = Convert.ToInt32(row["PatientWeight"])
                };
                deList.Add(de);
            }
            DRVreportViewer.LocalReport.DataSources.Clear();
            DRVreportViewer.LocalReport.DataSources.Add(new ReportDataSource("DietDataSet", deList));
            PageSettings pg = new PageSettings();
            pg.Margins.Top = 0;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            PaperSize size = new PaperSize
            {
                RawKind = (int)PaperKind.A4
            };
            pg.PaperSize = size;
            DRVreportViewer.SetPageSettings(pg);
            DRVreportViewer.RefreshReport();
        }
    }
}
