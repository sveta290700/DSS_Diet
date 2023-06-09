using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class MainScreen : Form
    {
        private List<KECheck> ErrorsList = new List<KECheck>();

        public MainScreen()
        {
            InitializeComponent();
        }

        private void ButtonToKE_Click(object sender, EventArgs e)
        {
            DataEditor KnowledgeEditor = new DataEditor();
            KnowledgeEditor.ShowDialog();
        }

        private class KECheck
        {
            private bool resultCheck;
            private string messageCheck;
            public bool ResultCheck { get => resultCheck; set => resultCheck = value; }
            public string MessageCheck { get => messageCheck; set => messageCheck = value; }
            public KECheck()
            {
                ResultCheck = true;
                MessageCheck = "";
            }
            public KECheck(bool resultCheck, string messageCheck)
            {
                ResultCheck = resultCheck;
                MessageCheck = messageCheck;
            }
        }

        private KECheck CheckIfHasProductsNames()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countProductsNames = new SqlCommand("SELECT COUNT(*) FROM ProductsNames;", Program.sqlConnection);
            int countProductsNamesRes = (int)countProductsNames.ExecuteScalar();
            if (countProductsNamesRes == 0)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Не задано ни одно название продукта.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private KECheck CheckIfHasCategories()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countCategories = new SqlCommand("SELECT COUNT(*) FROM Categories;", Program.sqlConnection);
            int countCategoriesRes = (int)countCategories.ExecuteScalar();
            if (countCategoriesRes == 0)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Не задана ни одна категория продуктов.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private KECheck CheckIfHasCompatibleCategories()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countCompatibleCategories = new SqlCommand("SELECT COUNT(*) FROM CompatibleCategories;", Program.sqlConnection);
            int countCompatibleCategoriesRes = (int)countCompatibleCategories.ExecuteScalar();
            if (countCompatibleCategoriesRes == 0)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Нет хотя бы одной пары совместимых категорий продуктов.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private KECheck CheckIfHasProductsOfCategories()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countProductsOfCategories = new SqlCommand("SELECT COUNT(*) FROM ProductsOfCategories;", Program.sqlConnection);
            int countProductsOfCategoriesRes = (int)countProductsOfCategories.ExecuteScalar();
            if (countProductsOfCategoriesRes == 0)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Ни один продукт не отнесён к какой-либо категории продуктов.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private KECheck CheckIfHasProductsWithoutCategories()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countNotProductsOfCategories = new SqlCommand("SELECT COUNT(*) FROM ProductsNames LEFT JOIN ProductsOfCategories ON ProductsNames.Id = ProductsOfCategories.ProductId WHERE ProductsOfCategories.ProductId IS NULL;", Program.sqlConnection);
            int countNotProductsOfCategoriesRes = (int)countNotProductsOfCategories.ExecuteScalar();
            if (countNotProductsOfCategoriesRes > 0)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Не все продукты были отнесены к категориям продуктов.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private KECheck CheckIfHasSubstances()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countSubstances = new SqlCommand("SELECT COUNT(*) FROM Features WHERE Name != N'стоимость за 1 кг продукта';", Program.sqlConnection);
            int countSubstancesRes = (int)countSubstances.ExecuteScalar();
            if (countSubstancesRes == 0)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Не задан ни один признак-вещество продуктов.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private KECheck CheckIfAllHasPossibleValues()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countNullPV = new SqlCommand("SELECT COUNT(*) FROM PossibleFeaturesValues WHERE Low IS NULL OR LowIncl IS NULL OR High IS NULL OR HighIncl IS NULL;", Program.sqlConnection);
            int countNullPVRes = (int)countNullPV.ExecuteScalar();
            if (countNullPVRes > 0)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Не все возможные значения признаков продуктов были заданы.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private KECheck CheckIfHasFeatureOutOfFeatureDescriptions()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countFeaturesOutOfFDs = new SqlCommand("SELECT COUNT(*) FROM Features LEFT JOIN FeatureDescriptions ON Features.Id = FeatureDescriptions.FeatureId WHERE FeatureDescriptions.FeatureId IS NULL;", Program.sqlConnection);
            int countFeaturesOutOfFDsRes = (int)countFeaturesOutOfFDs.ExecuteScalar();
            if (countFeaturesOutOfFDsRes > 0)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Не все признаки-вещества продуктов вошли в признаковые описания продуктов.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private KECheck CheckIfAllHasFeatureValues()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countFV = new SqlCommand("SELECT COUNT(*) FROM ProductsFeaturesValues;", Program.sqlConnection);
            int countFVRes = (int)countFV.ExecuteScalar();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id FROM Features;", Program.sqlConnection);
            DataTable FeaturesTable = new DataTable();
            adapter.Fill(FeaturesTable);
            List<int> FeaturesIdList = FeaturesTable.AsEnumerable().Select(n => n.Field<int>(0)).ToList();
            bool errorFlag = false;
            foreach (var featureId in FeaturesIdList)
            {
                SqlCommand countFDofFeature = new SqlCommand("SELECT COUNT(*) FROM FeatureDescriptions WHERE FeatureId = " + featureId + ";", Program.sqlConnection);
                int countFDofFeatureRes = (int)countFDofFeature.ExecuteScalar();
                SqlCommand countFVOfFeature = new SqlCommand("SELECT COUNT(*) FROM ProductsFeaturesValues WHERE FeatureId = " + featureId + ";", Program.sqlConnection);
                int countFVOfFeatureRes = (int)countFVOfFeature.ExecuteScalar();
                if (countFDofFeatureRes != countFVOfFeatureRes)
                {
                    errorFlag = true;
                    break;
                }
            }
            if (errorFlag)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Не все значения признаков продуктов из признаковых описаний продуктов были заданы.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private KECheck CheckIfAllHasDayNorms()
        {
            Program.sqlConnection.Open();
            KECheck result = new KECheck();
            SqlCommand countNullDN = new SqlCommand("SELECT COUNT(*) FROM DayNorms WHERE Value IS NULL;", Program.sqlConnection);
            int countNullDNRes = (int)countNullDN.ExecuteScalar();
            if (countNullDNRes > 0)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Не все значения суточных норм веществ были заданы.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private string CheckKnowledgeIntegrity()
        {
            string errorsText = "";
            ErrorsList.Clear();
            CheckIfHasProductsNames();
            CheckIfHasCategories();
            CheckIfHasCompatibleCategories();
            CheckIfHasProductsOfCategories();
            CheckIfHasProductsWithoutCategories();
            PossibleValues PossibleValues = new PossibleValues();
            PossibleValues.Close();
            CheckIfHasSubstances();
            CheckIfAllHasPossibleValues();
            CheckIfHasFeatureOutOfFeatureDescriptions();
            CheckIfAllHasFeatureValues();
            DayNorms DayNorms = new DayNorms();
            DayNorms.Close();
            CheckIfAllHasDayNorms();
            if (ErrorsList.Count != 0)
            {
                foreach (KECheck item in ErrorsList)
                {
                    errorsText += item.MessageCheck;
                }
            }
            return errorsText;
        }
        private void ButtonToTS_Click(object sender, EventArgs e)
        {
            string knowledgeErrors = CheckKnowledgeIntegrity();
            if (knowledgeErrors != "")
            {
                MessageFormLarge ErrorFormIntegrity = new MessageFormLarge();
                ErrorFormIntegrity.LabelText.Text = knowledgeErrors;
                ErrorFormIntegrity.Text = "Проверка целостности базы знаний";
                ErrorFormIntegrity.ShowDialog();
            }
            else 
            {
                MessageFormSmall OKFormIntegrity = new MessageFormSmall();
                OKFormIntegrity.LabelText.Text = "Проверка целостности базы знаний прошла успешно.\nЗакройте это окно для дальнейшей работы.";
                OKFormIntegrity.Text = "Проверка целостности базы знаний";
                OKFormIntegrity.ShowDialog();
                TaskSolver TaskSolver = new TaskSolver();
                TaskSolver.ShowDialog();
            }
        }
    }
}
