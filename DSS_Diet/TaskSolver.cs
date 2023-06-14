using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using Google.OrTools.LinearSolver;

namespace DietProject
{
    public partial class TaskSolver : Form
    {
        private SqlDataAdapter adapter;
        private DataTable PatientParametersSetTable = new DataTable();
        private DataTable ProductsNamesTable = new DataTable();
        private List<string> ProductsNamesList = new List<string>();

        private const int FEATURES_COUNT = 9;

        public TaskSolver()
        {
            InitializeComponent();
        }

        private void TaskSolver_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА]", Program.sqlConnection);
            adapter.Fill(PatientParametersSetTable);
            TSPatientParametersSetComboBox.DataSource = PatientParametersSetTable;
            PatientParametersSetTable.Columns.Add(
                "Полное_описание_набора",
                typeof(string),
                "'Рост: ' + Рост_пациента + ' см, вес: ' + Вес_пациента + ' кг, пол: ' + Пол_пациента");
            TSPatientParametersSetComboBox.DisplayMember = "Полное_описание_набора";
            TSPatientParametersSetComboBox.ValueMember = "ID_набора_параметров_пациента";
            adapter = new SqlDataAdapter("SELECT * FROM [ПРОДУКТ]", Program.sqlConnection);
            adapter.Fill(ProductsNamesTable);
            ProductsNamesList = ProductsNamesTable.AsEnumerable().Select(n => n.Field<string>(1)).ToList();
            foreach (var productName in ProductsNamesList)
            {
                TSProductsNamesListBox.Items.Add(productName);
            }
        }

        private void MoveSelectedItems(ListBox lstFrom, ListBox lstTo)
        {
            while (lstFrom.SelectedItems.Count > 0)
            {
                string item = (string)lstFrom.SelectedItems[0];
                lstTo.Items.Add(item);
                lstFrom.Items.Remove(item);
            }
        }

        private void TSSelectButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(TSProductsNamesListBox, TSDietProductsListBox);
        }

        private void TSUnselectButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(TSDietProductsListBox, TSProductsNamesListBox);
        }

        private void TSSolveButton_Click(object sender, EventArgs e)
        {
            if (TSDietProductsListBox.Items.Cast<string>().ToList().Count != 0)
            {
                if ((TSSurnameTextBox.Text != "") && (TSNameTextBox.Text != ""))
                {
                    if (Program.sqlConnection.State == ConnectionState.Open)
                        Program.sqlConnection.Close();
                    Program.sqlConnection.Open();
                    List<string> notCompatibleMessagesList = new List<string>();
                    string notCompatibleMessagesString = "";
                    foreach (var dietProductName1 in TSDietProductsListBox.Items)
                    {
                        SqlCommand getDietProductId1 = new SqlCommand("SELECT [ID_продукта] FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + dietProductName1 + "';", Program.sqlConnection);
                        int dietProductId1 = (int)getDietProductId1.ExecuteScalar();
                        SqlCommand getDietProductCategoryId1 = new SqlCommand("SELECT [ID_категории_продуктов] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId1 + ";", Program.sqlConnection);
                        int dietProductCategoryId1 = (int)getDietProductCategoryId1.ExecuteScalar();
                        SqlCommand getDietProductCategoryName1 = new SqlCommand("SELECT [Название_категории_продуктов] FROM [КАТЕГОРИЯ_ПРОДУКТОВ] WHERE [ID_категории_продуктов] = " + dietProductCategoryId1 + ";", Program.sqlConnection);
                        string dietProductCategoryName1 = (string)getDietProductCategoryName1.ExecuteScalar();
                        List<string> dietProductsNamesExceptThis = new List<string>(TSDietProductsListBox.Items.Cast<string>().ToList());
                        dietProductsNamesExceptThis.Remove((string)dietProductName1);
                        foreach (var dietProductName2 in dietProductsNamesExceptThis)
                        {
                            SqlCommand getDietProductId2 = new SqlCommand("SELECT [ID_продукта] FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + dietProductName2 + "';", Program.sqlConnection);
                            int dietProductId2 = (int)getDietProductId2.ExecuteScalar();
                            SqlCommand getDietProductCategoryId2 = new SqlCommand("SELECT [ID_категории_продуктов] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId2 + ";", Program.sqlConnection);
                            int dietProductCategoryId2 = (int)getDietProductCategoryId2.ExecuteScalar();
                            SqlCommand getDietProductCategoryName2 = new SqlCommand("SELECT [Название_категории_продуктов] FROM [КАТЕГОРИЯ_ПРОДУКТОВ] WHERE [ID_категории_продуктов] = " + dietProductCategoryId2 + ";", Program.sqlConnection);
                            string dietProductCategoryName2 = (string)getDietProductCategoryName2.ExecuteScalar();
                            SqlCommand checkIfCompatible = new SqlCommand("SELECT COUNT(*) FROM [СОВМЕСТИМОСТЬ_КАТЕГОРИЙ_ПРОДУКТОВ] WHERE [ID_категории_продуктов] = " + dietProductCategoryId1 + " AND [ID_совместимой_категории_продуктов] = " + dietProductCategoryId2 + ";", Program.sqlConnection);
                            int checkIfCompatibleRes = (int)checkIfCompatible.ExecuteScalar();
                            if (checkIfCompatibleRes == 0)
                            {
                                string stringResult1 = "Продукты " + dietProductName1 + " (категория: " + dietProductCategoryName1 + ") и " + dietProductName2 + " (категория: " + dietProductCategoryName2 + ") несовместимы!\n\n";
                                string stringResult2 = "Продукты " + dietProductName2 + " (категория: " + dietProductCategoryName2 + ") и " + dietProductName1 + " (категория: " + dietProductCategoryName1 + ") несовместимы!\n\n";
                                if (!notCompatibleMessagesList.Contains(stringResult2))
                                {
                                    notCompatibleMessagesList.Add(stringResult1);
                                    notCompatibleMessagesString += stringResult1;
                                }
                            }
                        }
                    }
                    if (notCompatibleMessagesString.Length == 0)
                    {
                        double[,] systemLeft = new double[FEATURES_COUNT, TSDietProductsListBox.Items.Count];
                        double[] systemRight = new double[FEATURES_COUNT];
                        int counterProducts = 0;
                        foreach (var dietProductName in TSDietProductsListBox.Items)
                        {
                            SqlCommand getDietProductId = new SqlCommand("SELECT [ID_продукта] FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + dietProductName + "';", Program.sqlConnection);
                            int dietProductId = (int)getDietProductId.ExecuteScalar();
                            SqlCommand getFeatureValue = new SqlCommand("SELECT [Содержание_белков_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId + ";", Program.sqlConnection);
                            object featureValueRes = getFeatureValue.ExecuteScalar();
                            double featureValue = decimal.ToDouble((decimal)featureValueRes);
                            systemLeft[0, counterProducts] = featureValue / 100;
                            getFeatureValue = new SqlCommand("SELECT [Содержание_жиров_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId + ";", Program.sqlConnection);
                            featureValueRes = getFeatureValue.ExecuteScalar();
                            featureValue = decimal.ToDouble((decimal)featureValueRes);
                            systemLeft[1, counterProducts] = featureValue / 100;
                            getFeatureValue = new SqlCommand("SELECT [Содержание_углеводов_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId + ";", Program.sqlConnection);
                            featureValueRes = getFeatureValue.ExecuteScalar();
                            featureValue = decimal.ToDouble((decimal)featureValueRes);
                            systemLeft[2, counterProducts] = featureValue / 100;
                            getFeatureValue = new SqlCommand("SELECT [Содержание_витамина_A_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId + ";", Program.sqlConnection);
                            featureValueRes = getFeatureValue.ExecuteScalar();
                            featureValue = decimal.ToDouble((decimal)featureValueRes);
                            systemLeft[3, counterProducts] = featureValue / 100;
                            getFeatureValue = new SqlCommand("SELECT [Содержание_витамина_B1_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId + ";", Program.sqlConnection);
                            featureValueRes = getFeatureValue.ExecuteScalar();
                            featureValue = decimal.ToDouble((decimal)featureValueRes);
                            systemLeft[4, counterProducts] = featureValue / 100;
                            getFeatureValue = new SqlCommand("SELECT [Содержание_витамина_C_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId + ";", Program.sqlConnection);
                            featureValueRes = getFeatureValue.ExecuteScalar();
                            featureValue = decimal.ToDouble((decimal)featureValueRes);
                            systemLeft[5, counterProducts] = featureValue / 100;
                            getFeatureValue = new SqlCommand("SELECT [Содержание_клетчатки_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId + ";", Program.sqlConnection);
                            featureValueRes = getFeatureValue.ExecuteScalar();
                            featureValue = decimal.ToDouble((decimal)featureValueRes);
                            systemLeft[6, counterProducts] = featureValue / 100;
                            getFeatureValue = new SqlCommand("SELECT [Калорийность_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId + ";", Program.sqlConnection);
                            featureValueRes = getFeatureValue.ExecuteScalar();
                            featureValue = Convert.ToDouble((int)featureValueRes);
                            systemLeft[7, counterProducts] = featureValue / 100;
                            getFeatureValue = new SqlCommand("SELECT [Стоимость_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + dietProductId + ";", Program.sqlConnection);
                            featureValueRes = getFeatureValue.ExecuteScalar();
                            featureValue = decimal.ToDouble((decimal)featureValueRes);
                            systemLeft[8, counterProducts] = featureValue / 100;
                            counterProducts++;
                        }
                        DataRowView item = (DataRowView)TSPatientParametersSetComboBox.SelectedItem;
                        int selectedSetId = (int)item.Row[0];
                        SqlCommand getDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_белков] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
                        double dayNorm = decimal.ToDouble((decimal)getDayNorm.ExecuteScalar());
                        systemRight[0] = dayNorm;
                        getDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_жиров] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
                        dayNorm = decimal.ToDouble((decimal)getDayNorm.ExecuteScalar());
                        systemRight[1] = dayNorm;
                        getDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_углеводов] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
                        dayNorm = decimal.ToDouble((decimal)getDayNorm.ExecuteScalar());
                        systemRight[2] = dayNorm;
                        getDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_витамина_A] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
                        dayNorm = decimal.ToDouble((decimal)getDayNorm.ExecuteScalar());
                        systemRight[3] = dayNorm;
                        getDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_витамина_B1] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
                        dayNorm = decimal.ToDouble((decimal)getDayNorm.ExecuteScalar());
                        systemRight[4] = dayNorm;
                        getDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_витамина_C] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
                        dayNorm = decimal.ToDouble((decimal)getDayNorm.ExecuteScalar());
                        systemRight[5] = dayNorm;
                        getDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_клетчатки] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
                        dayNorm = decimal.ToDouble((decimal)getDayNorm.ExecuteScalar());
                        systemRight[6] = dayNorm;
                        getDayNorm = new SqlCommand("SELECT [Значение_суточной_нормы_калорий] FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
                        dayNorm = Convert.ToDouble((int)getDayNorm.ExecuteScalar());
                        systemRight[7] = dayNorm;
                        systemRight[8] = (double)TSMoneyNumericUpDown.Value;
                        adapter = new SqlDataAdapter("SELECT Id FROM ProductsNames;", Program.sqlConnection);
                        Solver solver = Solver.CreateSolver("GLOP");
                        List<Variable> foods = new List<Variable>();
                        for (int i = 0; i < TSDietProductsListBox.Items.Cast<string>().ToList().Count; ++i)
                        {
                            string varName = "x" + i;
                            foods.Add(solver.MakeNumVar(0.0, 1000.0, varName));
                        }
                        List<Google.OrTools.LinearSolver.Constraint> constraints = new List<Google.OrTools.LinearSolver.Constraint>();
                        Objective objective = solver.Objective();
                        for (int i = 0; i < FEATURES_COUNT; i++)
                        {
                            Google.OrTools.LinearSolver.Constraint constraint = solver.MakeConstraint();
                            if (i == FEATURES_COUNT - 1)
                            {
                                constraint.SetBounds(0.0, systemRight[FEATURES_COUNT - 1]);
                            }
                            else
                            {
                                constraint.SetBounds(systemRight[i], double.PositiveInfinity);
                            }
                            for (int j = 0; j < TSDietProductsListBox.Items.Count; j++)
                            {
                                if (i == FEATURES_COUNT - 1)
                                {
                                    objective.SetCoefficient(foods[j], systemLeft[i, j]);
                                }
                                constraint.SetCoefficient(foods[j], systemLeft[i, j]);
                            }
                            constraints.Add(constraint);
                        }
                        objective.SetMinimization();
                        Solver.ResultStatus resultStatus = solver.Solve();
                        if (resultStatus == Solver.ResultStatus.INFEASIBLE)
                        {
                            MessageFormSmall ErrorForm = new MessageFormSmall();
                            ErrorForm.LabelText.Text = "Рацион с таким набором продуктов и доступным бюджетом составить нельзя.";
                            ErrorForm.Text = "Ошибка";
                            ErrorForm.ShowDialog();
                        }
                        else
                        {
                            string dietReady = "";
                            for (int i = 0; i < foods.Count; ++i)
                            {
                                dietReady += $"{TSDietProductsListBox.Items[i]} - {foods[i].SolutionValue():N3} г\n\n";
                            }
                            MessageFormLarge TaskResultForm = new MessageFormLarge();
                            TaskResultForm.LabelText.Text = "Согласно списку выбранных продуктов и доступному бюджету\n для Вас был спроектирован следующий суточный рацион:\n\n" + dietReady;
                            TaskResultForm.Text = "Результат решения задачи";
                            TaskResultForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageFormLarge ErrorFormIncompatible = new MessageFormLarge();
                        ErrorFormIncompatible.LabelText.Text = notCompatibleMessagesString;
                        ErrorFormIncompatible.Text = "Найдены несовместимые продукты.";
                        ErrorFormIncompatible.ShowDialog();
                    }
                    Program.sqlConnection.Close();
                }
                else
                {
                    MessageFormSmall ErrorForm = new MessageFormSmall();
                    ErrorForm.LabelText.Text = "Фамилия и имя пациента не могут быть пустыми.";
                    ErrorForm.Text = "Ошибка";
                    ErrorForm.ShowDialog();
                }
            }
            else
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "В рацион должен входить хотя бы один продукт.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
        }
    }
}
