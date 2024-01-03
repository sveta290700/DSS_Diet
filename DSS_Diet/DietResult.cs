using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class DietResult : Form
    {
        public DietResult()
        {
            InitializeComponent();
        }

        private void DRPrintButton_Click(object sender, EventArgs e)
        {
            if (Program.sqlConnection.State == ConnectionState.Open)
                Program.sqlConnection.Close();
            Program.sqlConnection.Open();
            SqlCommand getLastDietId = new SqlCommand("SELECT TOP 1 [РАЦИОН].[ID_рациона] FROM [РАЦИОН] ORDER BY [РАЦИОН].[ID_рациона] DESC;", Program.sqlConnection);
            int dietId = (int)getLastDietId.ExecuteScalar();
            Program.sqlConnection.Close(); 
            DietReportViewer dietReportViewer = new DietReportViewer(Convert.ToInt32(dietId));
            dietReportViewer.ShowDialog();
        }
    }
}
