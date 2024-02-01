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

        public static double GetPseudoDoubleWithinRange(double lowerBound, double upperBound)
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
            return rRangeDouble;
        }

        private void TaskSolver_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА]", Program.sqlConnection);
            adapter.Fill(PatientParametersSetTable);
            TSPatientParametersSetComboBox.DataSource = PatientParametersSetTable;
            PatientParametersSetTable.Columns.Add(
                "Полное_описание_набора",
                typeof(string),
                "'Рост: ' + Рост_пациента + ' см, вес: ' + Вес_пациента + ' кг, пол: ' + Пол_пациента + ', заболевание: ' + Заболевание_пациента");
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
                    DataRowView item = (DataRowView)TSPatientParametersSetComboBox.SelectedItem;
                    int selectedSetId = (int)item.Row[0];
                    if (Program.sqlConnection.State == ConnectionState.Open)
                        Program.sqlConnection.Close();
                    Program.sqlConnection.Open();
                    string stringCheckIfPaientExists = "SELECT COUNT(*) FROM [ПАЦИЕНТ] WHERE [Фамилия_пациента] = N'" + TSSurnameTextBox.Text.ToString() + "' AND [Имя_пациента] = N'" + TSNameTextBox.Text.ToString() + "' AND [Отчество_пациента] IS NULL AND [ID_набора_параметров_пациента] = " + selectedSetId + ";";
                    if (TSPatronymTextBox.Text != "")
                        stringCheckIfPaientExists = "SELECT COUNT(*) FROM [ПАЦИЕНТ] WHERE [Фамилия_пациента] = N'" + TSSurnameTextBox.Text.ToString() + "' AND [Имя_пациента] = N'" + TSNameTextBox.Text.ToString() + "' AND [Отчество_пациента] = N'" + TSPatronymTextBox.Text.ToString() + "' AND [ID_набора_параметров_пациента] = " + selectedSetId + ";";
                    SqlCommand checkIfPaientExists = new SqlCommand(stringCheckIfPaientExists, Program.sqlConnection);
                    int res = (int)checkIfPaientExists.ExecuteScalar();
                    if (res == 0)
                    {
                        string stringAddPatient = "INSERT INTO [ПАЦИЕНТ] ([ID_набора_параметров_пациента], [Фамилия_пациента], [Имя_пациента], [Отчество_пациента]) VALUES (" + selectedSetId + ", N'" + TSSurnameTextBox.Text.ToString() + "', N'" + TSNameTextBox.Text.ToString() + "', NULL);";
                        if (TSPatronymTextBox.Text != "")
                            stringAddPatient = "INSERT INTO [ПАЦИЕНТ] ([ID_набора_параметров_пациента], [Фамилия_пациента], [Имя_пациента], [Отчество_пациента]) VALUES (" + selectedSetId + ", N'" + TSSurnameTextBox.Text.ToString() + "', N'" + TSNameTextBox.Text.ToString() + "', N'" + TSPatronymTextBox.Text.ToString() + "');";
                        SqlCommand addPatient = new SqlCommand(stringAddPatient, Program.sqlConnection);
                        addPatient.ExecuteNonQuery();
                    }
                    SqlCommand checkIsIll = new SqlCommand("SELECT [Заболевание_пациента] FROM [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + ";", Program.sqlConnection);
                    string illnesInfo = (string)checkIsIll.ExecuteScalar();
                    string notAcceptedMessagesString = "";
                    if (illnesInfo == "гастрит" || illnesInfo == "сахарный диабет")
                    {
                        if (illnesInfo == "гастрит")
                        {
                            foreach (var dietProductName in TSDietProductsListBox.Items)
                            {
                                SqlCommand getGastritisInfo = new SqlCommand("SELECT [Запрет_при_гастрите] FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + dietProductName + "';", Program.sqlConnection);
                                byte gastritisInfo = (byte)getGastritisInfo.ExecuteScalar();
                                if (Convert.ToBoolean(gastritisInfo))
                                {
                                    string stringResult = "Продукт " + dietProductName + " не разрешен к употреблению при заболевании " + illnesInfo + "!\n";
                                    notAcceptedMessagesString += stringResult;
                                }
                            }
                        }
                        else
                        {
                            foreach (var dietProductName in TSDietProductsListBox.Items)
                            {
                                SqlCommand getDiabetesInfo = new SqlCommand("SELECT [Запрет_при_диабете] FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + dietProductName + "';", Program.sqlConnection);
                                byte diabetesInfo = (byte)getDiabetesInfo.ExecuteScalar();
                                if (Convert.ToBoolean(diabetesInfo))
                                {
                                    string stringResult = "Продукт " + dietProductName + " не разрешен к употреблению при заболевании " + illnesInfo + "!\n";
                                    notAcceptedMessagesString += stringResult;
                                }
                            }
                        }
                    }
                    if (notAcceptedMessagesString.Length == 0)
                    {
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
                                    string stringResult1 = "Продукты " + dietProductName1 + " (категория: " + dietProductCategoryName1 + ") и " + dietProductName2 + " (категория: " + dietProductCategoryName2 + ") несовместимы!\n";
                                    string stringResult2 = "Продукты " + dietProductName2 + " (категория: " + dietProductCategoryName2 + ") и " + dietProductName1 + " (категория: " + dietProductCategoryName1 + ") несовместимы!\n";
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
                            Solver solver = Solver.CreateSolver("GLOP");
                            List<Variable> foods = new List<Variable>();
                            for (int i = 0; i < TSDietProductsListBox.Items.Cast<string>().ToList().Count; ++i)
                            {
                                string varName = "x" + i;
                                //foods.Add(solver.MakeNumVar(GetPseudoDoubleWithinRange(50.0, 100.0), GetPseudoDoubleWithinRange(450.0, 500.0), varName));
                                foods.Add(solver.MakeNumVar(50.0, 400.0, varName));
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
                                    //constraint.SetBounds(systemRight[i], double.PositiveInfinity);
                                    constraint.SetBounds(systemRight[i], systemRight[i] + 500.0);
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
                                ErrorForm.Text = "Результат решения задачи";
                                ErrorForm.ShowDialog();
                            }
                            else
                            {
                                string dietReady = "";
                                string stringGetPaientID = "SELECT [ID_пациента] FROM [ПАЦИЕНТ] WHERE [Фамилия_пациента] = N'" + TSSurnameTextBox.Text.ToString() + "' AND [Имя_пациента] = N'" + TSNameTextBox.Text.ToString() + "' AND [Отчество_пациента] IS NULL AND [ID_набора_параметров_пациента] = " + selectedSetId + ";";
                                if (TSPatronymTextBox.Text != "")
                                {
                                    stringGetPaientID = "SELECT [ID_пациента] FROM [ПАЦИЕНТ] WHERE [Фамилия_пациента] = N'" + TSSurnameTextBox.Text.ToString() + "' AND [Имя_пациента] = N'" + TSNameTextBox.Text.ToString() + "' AND [Отчество_пациента] = N'" + TSPatronymTextBox.Text + "' AND [ID_набора_параметров_пациента] = " + selectedSetId + ";";
                                }
                                SqlCommand getPatientID = new SqlCommand(stringGetPaientID, Program.sqlConnection);
                                int patientID = (int)getPatientID.ExecuteScalar();
                                SqlCommand addDiet = new SqlCommand("INSERT INTO [РАЦИОН] ([ID_набора_параметров_пациента], [Доступный_бюджет], [ID_пациента]) VALUES (" + selectedSetId + ", CONVERT(DECIMAL(6, 2), " + TSMoneyNumericUpDown.Value + "), " + patientID + ");", Program.sqlConnection);
                                addDiet.ExecuteNonQuery();
                                SqlCommand getDietID = new SqlCommand("SELECT TOP 1 [ID_рациона] FROM [РАЦИОН] WHERE [ID_набора_параметров_пациента] = " + selectedSetId + " AND [Доступный_бюджет] = CONVERT(DECIMAL(6, 2), " + TSMoneyNumericUpDown.Value + ") AND [ID_пациента] = " + patientID + " ORDER BY [ID_рациона] DESC;", Program.sqlConnection);
                                int dietID = (int)getDietID.ExecuteScalar();
                                for (int i = 0; i < foods.Count; ++i)
                                {
                                    SqlCommand getProductID = new SqlCommand("SELECT [ID_продукта] FROM [Продукт] WHERE [Название_продукта] = N'" + TSDietProductsListBox.Items[i] + "';", Program.sqlConnection);
                                    int productID = (int)getProductID.ExecuteScalar();
                                    dietReady += $"{TSDietProductsListBox.Items[i]} - {foods[i].SolutionValue():N0} г\n";
                                    SqlCommand addDietElement = new SqlCommand("INSERT INTO [ЭЛЕМЕНТ_РАЦИОНА] ([ID_продукта], [Количество_продукта], [ID_рациона]) VALUES (" + productID + ", CONVERT(INTEGER, " + foods[i].SolutionValue().ToString("N0") + "), " + dietID + ");", Program.sqlConnection);
                                    addDietElement.ExecuteNonQuery();
                                }
                                DietResult TaskResultForm = new DietResult();
                                TaskResultForm.LabelText.Text = "Согласно списку выбранных продуктов и доступному бюджету\nбыл составлен следующий суточный рацион:\n\n" + dietReady;
                                TaskResultForm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageFormLarge ErrorFormIncompatible = new MessageFormLarge();
                            ErrorFormIncompatible.LabelText.Text = notCompatibleMessagesString;
                            ErrorFormIncompatible.Text = "Найдены несовместимые продукты";
                            ErrorFormIncompatible.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageFormLarge ErrorFormIncompatible = new MessageFormLarge();
                        ErrorFormIncompatible.LabelText.Text = notAcceptedMessagesString;
                        ErrorFormIncompatible.Text = "Найдены недопустимые продукты";
                        ErrorFormIncompatible.ShowDialog();
                    }
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
            if (Program.sqlConnection.State == ConnectionState.Open)
                Program.sqlConnection.Close();
        }
    }
}
