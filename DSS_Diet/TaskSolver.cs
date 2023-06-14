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

        public TaskSolver()
        {
            InitializeComponent();
        }

        private void TaskDataInput_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА]", Program.sqlConnection);
            adapter.Fill(PatientParametersSetTable);
            DNPatientParametersSetComboBox.DataSource = PatientParametersSetTable;
            PatientParametersSetTable.Columns.Add(
                "Полное_описание_набора",
                typeof(string),
                "'Рост: ' + Рост_пациента + ' см, вес: ' + Вес_пациента + ' кг, пол: ' + Пол_пациента");
            DNPatientParametersSetComboBox.DisplayMember = "Полное_описание_набора";
            DNPatientParametersSetComboBox.ValueMember = "ID_набора_параметров_пациента";
            adapter = new SqlDataAdapter("SELECT * FROM [ПРОДУКТ]", Program.sqlConnection);
            adapter.Fill(ProductsNamesTable);
            ProductsNamesList = ProductsNamesTable.AsEnumerable().Select(n => n.Field<string>(1)).ToList();
            foreach (var productName in ProductsNamesList)
            {
                DTProductsNamesListBox.Items.Add(productName);
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

        private void DTSelectButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(DTProductsNamesListBox, DietProductsListBox);
        }

        private void DTUnselectButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(DietProductsListBox, DTProductsNamesListBox);
        }

        private void TDSolveButton_Click(object sender, EventArgs e)
        {
            if (DietProductsListBox.Items.Cast<string>().ToList().Count != 0)
            {
                if (Program.sqlConnection.State == ConnectionState.Open)
                    Program.sqlConnection.Close();
                Program.sqlConnection.Open();
                List<string> notCompatibleMessagesList = new List<string>();
                string notCompatibleMessagesString = "";
                foreach (var dietProductName1 in DietProductsListBox.Items)
                {
                    SqlCommand getDietProductId1 = new SqlCommand("SELECT Id FROM ProductsNames WHERE Name = N'" + dietProductName1 + "';", Program.sqlConnection);
                    int dietProductId1 = (int)getDietProductId1.ExecuteScalar();
                    SqlCommand getDietProductCategoryId1 = new SqlCommand("SELECT CategoryId FROM ProductsOfCategories WHERE ProductId = " + dietProductId1 + ";", Program.sqlConnection);
                    int dietProductCategoryId1 = (int)getDietProductCategoryId1.ExecuteScalar();
                    SqlCommand getDietProductCategoryName1 = new SqlCommand("SELECT Name FROM Categories WHERE Id = " + dietProductCategoryId1 + ";", Program.sqlConnection);
                    string dietProductCategoryName1 = (string)getDietProductCategoryName1.ExecuteScalar();
                    List<string> dietProductsNamesExceptThis = new List<string>(DietProductsListBox.Items.Cast<string>().ToList());
                    dietProductsNamesExceptThis.Remove((string)dietProductName1);
                    foreach (var dietProductName2 in dietProductsNamesExceptThis)
                    {
                        SqlCommand getDietProductId2 = new SqlCommand("SELECT Id FROM ProductsNames WHERE Name = N'" + dietProductName2 + "';", Program.sqlConnection);
                        int dietProductId2 = (int)getDietProductId2.ExecuteScalar();
                        SqlCommand getDietProductCategoryId2 = new SqlCommand("SELECT CategoryId FROM ProductsOfCategories WHERE ProductId = " + dietProductId2 + ";", Program.sqlConnection);
                        int dietProductCategoryId2 = (int)getDietProductCategoryId2.ExecuteScalar();
                        SqlCommand getDietProductCategoryName2 = new SqlCommand("SELECT Name FROM Categories WHERE Id = " + dietProductCategoryId2 + ";", Program.sqlConnection);
                        string dietProductCategoryName2 = (string)getDietProductCategoryName2.ExecuteScalar();
                        SqlCommand checkIfCompatible = new SqlCommand("SELECT COUNT(*) FROM CompatibleCategories WHERE CategoryId1 = " + dietProductCategoryId1 + " AND CategoryId2 = " + dietProductCategoryId2 + ";", Program.sqlConnection);
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
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable FeaturesTable = new DataTable();
                    List<int> FeaturesIdList = new List<int>();
                    SqlCommand getFeaturesCount = new SqlCommand("SELECT COUNT (*) FROM Features;", Program.sqlConnection);
                    int featuresCount = (int)getFeaturesCount.ExecuteScalar();
                    double[,] systemLeft = new double[featuresCount, DietProductsListBox.Items.Count];
                    double[] systemRight = new double[featuresCount];
                    int counterProducts = 0;
                    foreach (var dietProductName in DietProductsListBox.Items)
                    {
                        SqlCommand getDietProductId = new SqlCommand("SELECT Id FROM ProductsNames WHERE Name = N'" + dietProductName + "';", Program.sqlConnection);
                        int dietProductId = (int)getDietProductId.ExecuteScalar();
                        adapter = new SqlDataAdapter("SELECT Id FROM Features;", Program.sqlConnection);
                        FeaturesTable.Clear();
                        adapter.Fill(FeaturesTable);
                        FeaturesIdList.Clear();
                        FeaturesIdList = FeaturesTable.AsEnumerable().Select(n => n.Field<int>(0)).ToList();
                        int counterFeatures = 0;
                        foreach (var featureId in FeaturesIdList)
                        {
                            SqlCommand getFeatureValue = new SqlCommand("SELECT Value FROM ProductsFeaturesValues WHERE ProductId = " + dietProductId + " AND FeatureId = " + featureId + ";", Program.sqlConnection);
                            object featureValueRes = getFeatureValue.ExecuteScalar();
                            double featureValue = 0.0;
                            if (featureValueRes != null)
                            {
                                featureValue = decimal.ToDouble((decimal)featureValueRes);
                            }
                            systemLeft[counterFeatures, counterProducts] = featureValue;
                            counterFeatures++;
                        }
                        counterProducts++;               
                    }
                    int counterFeaturesRight = 0;
                    foreach (var featureId in FeaturesIdList)
                    {
                        if (featureId != 1)
                        {
                            SqlCommand getDayNorm = new SqlCommand("SELECT Value FROM DayNorms WHERE SubstanceId = " + featureId + ";", Program.sqlConnection);
                            double dayNorm = decimal.ToDouble((decimal)getDayNorm.ExecuteScalar());
                            systemRight[counterFeaturesRight] = dayNorm;
                        }
                        else
                        {
                            systemRight[counterFeaturesRight] = (double)TSMoneyNumericUpDown.Value;
                        }
                        counterFeaturesRight++;
                    }
                    adapter = new SqlDataAdapter("SELECT Id FROM ProductsNames;", Program.sqlConnection);
                    FeaturesTable.Clear();
                    adapter.Fill(FeaturesTable);
                    FeaturesIdList.Clear();
                    FeaturesIdList = FeaturesTable.AsEnumerable().Select(n => n.Field<int>(0)).ToList();
                    Solver solver = Solver.CreateSolver("GLOP");
                    List<Variable> foods = new List<Variable>();
                    for (int i = 0; i < DietProductsListBox.Items.Cast<string>().ToList().Count; ++i)
                    {
                        string varName = "x" + i;
                        foods.Add(solver.MakeNumVar(0.0, 10.0, varName));
                    }
                    List<Google.OrTools.LinearSolver.Constraint> constraints = new List<Google.OrTools.LinearSolver.Constraint>();
                    Objective objective = solver.Objective();
                    for (int i = 0; i < featuresCount; i++)
                    {
                        Google.OrTools.LinearSolver.Constraint constraint = solver.MakeConstraint();
                        if (i == 0)
                        {
                            constraint.SetBounds(0.0, systemRight[i]);
                        }
                        else
                        {
                            constraint.SetBounds(systemRight[i], double.PositiveInfinity);
                        }
                        for (int j = 0; j < DietProductsListBox.Items.Count; j++)
                        {
                            if (i == 0)
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
                        double[] solveResult = new double[DietProductsListBox.Items.Count];
                        string dietReady = "";
                        for (int i = 0; i < foods.Count; ++i)
                        {
                            dietReady += $"{DietProductsListBox.Items[i]} - {foods[i].SolutionValue():N3} кг\n\n";
                        }
                        MessageFormLarge TaskResultForm = new MessageFormLarge();
                        TaskResultForm.LabelText.Text = "Согласно списку выбранных продуктов и доступному бюджету для Вас был спроектирован следующий суточный рацион:\n\n" + dietReady;
                        TaskResultForm.Text = "Результат решения задачи";
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
                Program.sqlConnection.Close();
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
