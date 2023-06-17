using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class DietInfo : Form
    {
        private string dietId = "";
        private SqlDataAdapter adapter;
        private DataTable DietElementsTable = new DataTable();

        public DietInfo(string dietId)
        {
            InitializeComponent();
            this.dietId = dietId;
        }
        
        private void DietInfo_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT [ПРОДУКТ].[Название_продукта] AS [Название продукта], [ЭЛЕМЕНТ_РАЦИОНА].[Количество_продукта] AS [Количество продукта] FROM [ЭЛЕМЕНТ_РАЦИОНА] JOIN [РАЦИОН] ON [ЭЛЕМЕНТ_РАЦИОНА].[ID_рациона] = [РАЦИОН].[ID_рациона] JOIN [ПРОДУКТ] ON [ЭЛЕМЕНТ_РАЦИОНА].[ID_продукта] = [ПРОДУКТ].[ID_продукта] WHERE [РАЦИОН].[ID_рациона] = " + dietId + ";", Program.sqlConnection);
            adapter.Fill(DietElementsTable);
            DIDietInfoDataGridView.AutoGenerateColumns = true;
            DIDietInfoDataGridView.DataSource = DietElementsTable;
            foreach (DataGridViewColumn column in DIDietInfoDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DIDietInfoDataGridView.EnableHeadersVisualStyles = false;
            DIDietInfoDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = DIDietInfoDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            this.Text += dietId;
            DIDIetInfoLabel.Text += dietId;
        }
    }
}