using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class Diets : Form
    {
        private SqlDataAdapter adapter;
        private DataTable PatientParametersSetTable = new DataTable();
        private DataTable DietsTable = new DataTable();

        public Diets()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter("SELECT * FROM [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА]", Program.sqlConnection);
            adapter.Fill(PatientParametersSetTable);
            DPatientParametersSetComboBox.DataSource = PatientParametersSetTable;
            PatientParametersSetTable.Columns.Add(
                "Полное_описание_набора",
                typeof(string),
                "'Рост: ' + Рост_пациента + ' см, вес: ' + Вес_пациента + ' кг, пол: ' + Пол_пациента");
            DPatientParametersSetComboBox.DisplayMember = "Полное_описание_набора";
            DPatientParametersSetComboBox.ValueMember = "ID_набора_параметров_пациента";
            DPatientParametersSetComboBox.SelectedIndex = -1;
        }
        
        private void Diets_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента]", Program.sqlConnection);
            adapter.Fill(DietsTable);
            DDietsDataGridView.AutoGenerateColumns = true;
            DDietsDataGridView.DataSource = DietsTable;
            foreach (DataGridViewColumn column in DDietsDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DDietsDataGridView.EnableHeadersVisualStyles = false;
            DDietsDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = DDietsDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
        }

        private void DSearchButton_Click(object sender, EventArgs e)
        {
            if ((DPatientParametersSetComboBox.SelectedIndex == -1) && (DSurnameTextBox.Text == "") && (DNameTextBox.Text == "") && (DPatronymTextBox.Text == ""))
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Параметры поиска не были заданы.";
                ErrorForm.Text = "Внимание";
                ErrorForm.ShowDialog();
            }
            else if ((DPatientParametersSetComboBox.SelectedIndex != -1) && (DSurnameTextBox.Text == "") && (DNameTextBox.Text == "") && (DPatronymTextBox.Text == ""))
            {
                DietsTable.Clear();
                adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] = " + DPatientParametersSetComboBox.SelectedValue + ";", Program.sqlConnection);
                adapter.Fill(DietsTable);
                DDietsDataGridView.AutoGenerateColumns = true;
                DDietsDataGridView.DataSource = DietsTable;
                foreach (DataGridViewColumn column in DDietsDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                DDietsDataGridView.EnableHeadersVisualStyles = false;
                DDietsDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = DDietsDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            }
            else if ((DPatientParametersSetComboBox.SelectedIndex == -1) && ((DSurnameTextBox.Text != "") || (DNameTextBox.Text != "") || (DPatronymTextBox.Text != "")))
            {
                DietsTable.Clear();
                if ((DSurnameTextBox.Text != "") && (DNameTextBox.Text == "") && (DPatronymTextBox.Text == ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [ПАЦИЕНТ].[Фамилия_пациента] LIKE N'%" + DSurnameTextBox.Text + "%';", Program.sqlConnection);
                else if ((DSurnameTextBox.Text != "") && (DNameTextBox.Text != "") && (DPatronymTextBox.Text == ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [ПАЦИЕНТ].[Фамилия_пациента] LIKE N'%" + DSurnameTextBox.Text + "%' AND [ПАЦИЕНТ].[Имя_пациента] LIKE N'%" + DNameTextBox.Text + "%';", Program.sqlConnection);
                else if ((DSurnameTextBox.Text == "") && (DNameTextBox.Text != "") && (DPatronymTextBox.Text == ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [ПАЦИЕНТ].[Имя_пациента] LIKE N'%" + DNameTextBox.Text + "%';", Program.sqlConnection);
                else if ((DSurnameTextBox.Text == "") && (DNameTextBox.Text != "") && (DPatronymTextBox.Text != ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [ПАЦИЕНТ].[Имя_пациента] LIKE N'%" + DNameTextBox.Text + "%' AND [ПАЦИЕНТ].[Отчество_пациента] LIKE N'%" + DPatronymTextBox.Text + "%';", Program.sqlConnection);
                else if ((DSurnameTextBox.Text != "") && (DNameTextBox.Text == "") && (DPatronymTextBox.Text != ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [ПАЦИЕНТ].[Фамилия_пациента] LIKE N'%" + DSurnameTextBox.Text + "%' AND [ПАЦИЕНТ].[Отчество_пациента] LIKE N'%" + DPatronymTextBox.Text + "%';", Program.sqlConnection);
                else
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [ПАЦИЕНТ].[Фамилия_пациента] LIKE N'%" + DSurnameTextBox.Text + "%' AND [ПАЦИЕНТ].[Имя_пациента] LIKE N'%" + DNameTextBox.Text + "%' AND [ПАЦИЕНТ].[Отчество_пациента] LIKE N'%" + DPatronymTextBox.Text + "%';", Program.sqlConnection);
                adapter.Fill(DietsTable);
                DDietsDataGridView.AutoGenerateColumns = true;
                DDietsDataGridView.DataSource = DietsTable;
                foreach (DataGridViewColumn column in DDietsDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                DDietsDataGridView.EnableHeadersVisualStyles = false;
                DDietsDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = DDietsDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            }
            else
            {
                DietsTable.Clear();
                if ((DSurnameTextBox.Text != "") && (DNameTextBox.Text == "") && (DPatronymTextBox.Text == ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] = " + DPatientParametersSetComboBox.SelectedValue + " AND [ПАЦИЕНТ].[Фамилия_пациента] LIKE N'%" + DSurnameTextBox.Text + "%';", Program.sqlConnection);
                else if ((DSurnameTextBox.Text != "") && (DNameTextBox.Text != "") && (DPatronymTextBox.Text == ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] = " + DPatientParametersSetComboBox.SelectedValue + " AND [ПАЦИЕНТ].[Фамилия_пациента] LIKE N'%" + DSurnameTextBox.Text + "%' AND [ПАЦИЕНТ].[Имя_пациента] LIKE N'%" + DNameTextBox.Text + "%';", Program.sqlConnection);
                else if ((DSurnameTextBox.Text == "") && (DNameTextBox.Text != "") && (DPatronymTextBox.Text == ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] = " + DPatientParametersSetComboBox.SelectedValue + " AND [ПАЦИЕНТ].[Имя_пациента] LIKE N'%" + DNameTextBox.Text + "%';", Program.sqlConnection);
                else if ((DSurnameTextBox.Text == "") && (DNameTextBox.Text != "") && (DPatronymTextBox.Text != ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] = " + DPatientParametersSetComboBox.SelectedValue + " AND [ПАЦИЕНТ].[Имя_пациента] LIKE N'%" + DNameTextBox.Text + "%' AND [ПАЦИЕНТ].[Отчество_пациента] LIKE N'%" + DPatronymTextBox.Text + "%';", Program.sqlConnection);
                else if ((DSurnameTextBox.Text != "") && (DNameTextBox.Text == "") && (DPatronymTextBox.Text != ""))
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] = " + DPatientParametersSetComboBox.SelectedValue + " AND [ПАЦИЕНТ].[Фамилия_пациента] LIKE N'%" + DSurnameTextBox.Text + "%' AND [ПАЦИЕНТ].[Отчество_пациента] LIKE N'%" + DPatronymTextBox.Text + "%';", Program.sqlConnection);
                else
                    adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] WHERE [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента] = " + DPatientParametersSetComboBox.SelectedValue + " AND [ПАЦИЕНТ].[Фамилия_пациента] LIKE N'%" + DSurnameTextBox.Text + "%' AND [ПАЦИЕНТ].[Имя_пациента] LIKE N'%" + DNameTextBox.Text + "%' AND [ПАЦИЕНТ].[Отчество_пациента] LIKE N'%" + DPatronymTextBox.Text + "%';", Program.sqlConnection);
                adapter.Fill(DietsTable);
                DDietsDataGridView.AutoGenerateColumns = true;
                DDietsDataGridView.DataSource = DietsTable;
                foreach (DataGridViewColumn column in DDietsDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                DDietsDataGridView.EnableHeadersVisualStyles = false;
                DDietsDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = DDietsDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            }
        }

        private void DCancelButton_Click(object sender, EventArgs e)
        {
            DSurnameTextBox.Clear();
            DNameTextBox.Clear();
            DPatronymTextBox.Clear();
            DPatientParametersSetComboBox.SelectedIndex = -1;
            DietsTable.Clear();
            adapter = new SqlDataAdapter("SELECT [РАЦИОН].[ID_рациона] AS [ID рациона], [ПАЦИЕНТ].[Фамилия_пациента] + ' ' + [ПАЦИЕНТ].[Имя_пациента] + ' ' + COALESCE([ПАЦИЕНТ].[Отчество_пациента], '') AS [ФИО пациента], CAST([РАЦИОН].[Доступный_бюджет] AS NVARCHAR) + ' руб.' AS [Доступный бюджет], 'Рост: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Рост_пациента] AS NVARCHAR) + ' см, вес: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Вес_пациента] AS NVARCHAR) + ' кг, пол: ' + CAST([НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[Пол_пациента] AS NVARCHAR) AS [Набор параметров пациента] FROM [РАЦИОН] JOIN [ПАЦИЕНТ] ON [РАЦИОН].[ID_пациента] = [ПАЦИЕНТ].[ID_пациента] JOIN [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] ON [ПАЦИЕНТ].[ID_набора_параметров_пациента] = [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА].[ID_набора_параметров_пациента]", Program.sqlConnection);
            adapter.Fill(DietsTable);
            DDietsDataGridView.AutoGenerateColumns = true;
            DDietsDataGridView.DataSource = DietsTable;
            foreach (DataGridViewColumn column in DDietsDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DDietsDataGridView.EnableHeadersVisualStyles = false;
            DDietsDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = DDietsDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
        }

        private void DDietsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string selectedDietId = DDietsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                DietInfo DietInfo = new DietInfo(selectedDietId);
                DietInfo.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void DDietsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DDietsDataGridView.ClearSelection();
        }
    }
}