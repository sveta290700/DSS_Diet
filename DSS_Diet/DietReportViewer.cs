using System;
using System.IO;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DietProject
{
    public partial class DietReportViewer : Form
    {
        int DietID;
        public class Employee
        {
            public string ProductName { get; set; }
            public int ProductCount { get; set; }
        }
        public DietReportViewer(int DietID)
        {
            InitializeComponent();
            this.DietID = DietID;
            DRVreportViewer = new ReportViewer();
            DRVreportViewer.Dock = DockStyle.Fill;
            Controls.Add(DRVreportViewer);
        }

        private void DietReportViewer_Load(object sender, EventArgs e)
        {
            using var fs = new FileStream("../../../DietReport.rdlc", FileMode.Open);
            DRVreportViewer.LocalReport.LoadReportDefinition(fs);
            //adapter = DSS_Diet.DietDBDataSetTableAdapters.DietReportTableAdapter
            //adapter = new SqlDataAdapter("SELECT [ПРОДУКТ].[Название_продукта] AS [Название продукта], [ЭЛЕМЕНТ_РАЦИОНА].[Количество_продукта] AS [Количество продукта] FROM [ЭЛЕМЕНТ_РАЦИОНА] JOIN [РАЦИОН] ON [ЭЛЕМЕНТ_РАЦИОНА].[ID_рациона] = [РАЦИОН].[ID_рациона] JOIN [ПРОДУКТ] ON [ЭЛЕМЕНТ_РАЦИОНА].[ID_продукта] = [ПРОДУКТ].[ID_продукта] WHERE [РАЦИОН].[ID_рациона] = " + DietID.ToString() + ";", Program.sqlConnection);
            //adapter.Fill(DietElementsTable);
            DSS_Diet.DietDBDataSetTableAdapters.DietReportTableAdapter dietReportTableAdapter = new DSS_Diet.DietDBDataSetTableAdapters.DietReportTableAdapter();
            DSS_Diet.DietDBDataSet.DietReportDataTable DietReport = new DSS_Diet.DietDBDataSet.DietReportDataTable();
            dietReportTableAdapter.Fill(DietReport, DietID);
            List<Employee> employees = new List<Employee>();
            foreach (DataRow row in DietReport.Rows)
            {
                Employee employee = new Employee();
                employee.ProductName = row["ProductName"].ToString();
                employee.ProductCount = Convert.ToInt32(row["ProductCount"]);
                employees.Add(employee);
            }
            DRVreportViewer.LocalReport.DataSources.Clear();
            DRVreportViewer.LocalReport.DataSources.Add(new ReportDataSource("DietDataSet", employees));
            DRVreportViewer.RefreshReport();
        }
    }
}
