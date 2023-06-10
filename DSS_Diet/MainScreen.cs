using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class MainScreen : Form
    {
        private List<DECheck> ErrorsList = new List<DECheck>();

        public MainScreen()
        {
            InitializeComponent();
        }

        private void ButtonToDE_Click(object sender, EventArgs e)
        {
            DataEditor KnowledgeEditor = new DataEditor();
            KnowledgeEditor.ShowDialog();
        }

        private class DECheck
        {
            private bool resultCheck;
            private string messageCheck;
            public bool ResultCheck { get => resultCheck; set => resultCheck = value; }
            public string MessageCheck { get => messageCheck; set => messageCheck = value; }
            public DECheck()
            {
                ResultCheck = true;
                MessageCheck = "";
            }
            public DECheck(bool resultCheck, string messageCheck)
            {
                ResultCheck = resultCheck;
                MessageCheck = messageCheck;
            }
        }

        private DECheck CheckIfHasProductsNames()
        {
            Program.sqlConnection.Open();
            DECheck result = new DECheck();
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

        private DECheck CheckIfHasCategories()
        {
            Program.sqlConnection.Open();
            DECheck result = new DECheck();
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

        private DECheck CheckIfHasCompatibleCategories()
        {
            Program.sqlConnection.Open();
            DECheck result = new DECheck();
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

        private DECheck CheckIfAllHasDayNorms()
        {
            Program.sqlConnection.Open();
            DECheck result = new DECheck();
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
            DayNorms DayNorms = new DayNorms();
            DayNorms.Close();
            CheckIfAllHasDayNorms();
            if (ErrorsList.Count != 0)
            {
                foreach (DECheck item in ErrorsList)
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
