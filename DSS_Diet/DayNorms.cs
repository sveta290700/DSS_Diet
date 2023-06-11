using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class DayNorms : Form
    {
        private SqlDataAdapter adapter;
        private DataTable PatientParametersSetTable = new DataTable();

        public DayNorms()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter("SELECT * FROM [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА]", Program.sqlConnection);
            adapter.Fill(PatientParametersSetTable);
            DNPatientParametersSetComboBox.DataSource = PatientParametersSetTable;
            PatientParametersSetTable.Columns.Add(
                "Полное_описание_набора",
                typeof(string),
                "'Рост: ' + Рост_пациента + ' см, вес: ' + Вес_пациента + ' кг, пол: ' + Пол_пациента");
            DNPatientParametersSetComboBox.DisplayMember = "Полное_описание_набора";
            DNPatientParametersSetComboBox.ValueMember = "ID_набора_параметров_пациента";
        }

        private void DNSubstanceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.sqlConnection.State == ConnectionState.Open)
                Program.sqlConnection.Close();
            Program.sqlConnection.Open();
            DataRowView item = (DataRowView)DNPatientParametersSetComboBox.SelectedItem;
            int selectedSetId = (int)item.Row[0];
            SqlCommand getProteinDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_белков] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
            object proteinDayNormRes = getProteinDayNorm.ExecuteScalar();
            decimal proteinDayNorm = (decimal)0.000;
            if (proteinDayNormRes != null)
            {
                proteinDayNorm = (decimal)proteinDayNormRes;
            }
            SqlCommand getFatsDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_жиров] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
            object fatsDayNormRes = getFatsDayNorm.ExecuteScalar();
            decimal fatsDayNorm = (decimal)0.000;
            if (fatsDayNormRes != null)
            {
                fatsDayNorm = (decimal)fatsDayNormRes;
            }
            SqlCommand getCarhydDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_углеводов] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
            object carhydDayNormRes = getCarhydDayNorm.ExecuteScalar();
            decimal carhydDayNorm = (decimal)0.000;
            if (carhydDayNormRes != null)
            {
                carhydDayNorm = (decimal)carhydDayNormRes;
            }
            SqlCommand getVitADayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_витамина_A] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
            object vitADayNormRes = getVitADayNorm.ExecuteScalar();
            decimal vitADayNorm = (decimal)0.000;
            if (vitADayNormRes != null)
            {
                vitADayNorm = (decimal)vitADayNormRes;
            }
            SqlCommand getVitB1DayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_витамина_B1] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
            object vitB1DayNormRes = getVitB1DayNorm.ExecuteScalar();
            decimal vitB1DayNorm = (decimal)0.000;
            if (vitB1DayNormRes != null)
            {
                vitB1DayNorm = (decimal)vitB1DayNormRes;
            }
            SqlCommand getVitCDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_витамина_C] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
            object vitCDayNormRes = getVitCDayNorm.ExecuteScalar();
            decimal vitCDayNorm = (decimal)0.000;
            if (vitCDayNormRes != null)
            {
                vitCDayNorm = (decimal)vitCDayNormRes;
            }
            SqlCommand getCellDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_клетчатки] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
            object cellDayNormRes = getCellDayNorm.ExecuteScalar();
            decimal cellDayNorm = (decimal)0.000;
            if (cellDayNormRes != null)
            {
                cellDayNorm = (decimal)cellDayNormRes;
            }
            SqlCommand getEnergyDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_калорий] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
            object energyDayNormRes = getEnergyDayNorm.ExecuteScalar();
            decimal energyDayNorm = (decimal)0.000;
            if (energyDayNormRes != null)
            {
                energyDayNorm = (decimal)energyDayNormRes;
            }
            Program.sqlConnection.Close();
            DNProteinsNumericUpDown.Value = proteinDayNorm;
            DNFatsNumericUpDown.Value = fatsDayNorm;
            DNCarhydNumericUpDown.Value = carhydDayNorm;
            DNVitANumericUpDown.Value = vitADayNorm;
            DNVitB1NumericUpDown.Value = vitB1DayNorm;
            DNVitCNumericUpDown.Value = vitCDayNorm;
            DNCellNumericUpDown.Value = cellDayNorm;
            DNEnergyNumericUpDown.Value = energyDayNorm;
        }

        private void DNAddButton_Click(object sender, EventArgs e)
        {
            if (DNPatientParametersSetComboBox.SelectedIndex != -1)
            {
                //todo
            }
            else
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Выберите набор параметров пациента для задания суточной нормы.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
        }
    }
}
