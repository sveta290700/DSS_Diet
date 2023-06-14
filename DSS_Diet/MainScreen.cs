using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class MainForm : Form
    {
        private List<DECheck> ErrorsList = new List<DECheck>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonToDE_Click(object sender, EventArgs e)
        {
            DataEditor DataEditor = new DataEditor();
            DataEditor.ShowDialog();
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
            if (Program.sqlConnection.State == ConnectionState.Open)
                Program.sqlConnection.Close();
            Program.sqlConnection.Open();
            DECheck result = new DECheck();
            SqlCommand countProductsNames = new SqlCommand("SELECT COUNT(*) FROM [ПРОДУКТ];", Program.sqlConnection);
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
            if (Program.sqlConnection.State == ConnectionState.Open)
                Program.sqlConnection.Close();
            Program.sqlConnection.Open();
            DECheck result = new DECheck();
            SqlCommand countCategories = new SqlCommand("SELECT COUNT(*) FROM [КАТЕГОРИЯ_ПРОДУКТОВ];", Program.sqlConnection);
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
            if (Program.sqlConnection.State == ConnectionState.Open)
                Program.sqlConnection.Close();
            Program.sqlConnection.Open();
            DECheck result = new DECheck();
            SqlCommand countCompatibleCategories = new SqlCommand("SELECT COUNT(*) FROM [СОВМЕСТИМОСТЬ_КАТЕГОРИЙ_ПРОДУКТОВ];", Program.sqlConnection);
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
            if (Program.sqlConnection.State == ConnectionState.Open)
                Program.sqlConnection.Close();
            Program.sqlConnection.Open();
            DECheck result = new DECheck();
            SqlCommand countPS = new SqlCommand("SELECT COUNT(*) FROM [НАБОР_ПАРАМЕТРОВ_ПАЦИЕНТА];", Program.sqlConnection);
            int countPSRes = (int)countPS.ExecuteScalar();
            SqlCommand countDN = new SqlCommand("SELECT COUNT(*) FROM [СУТОЧНАЯ_НОРМА_ВЕЩЕСТВ];", Program.sqlConnection);
            int countDNRes = (int)countDN.ExecuteScalar();
            if (countPSRes != countDNRes)
            {
                result.ResultCheck = false;
                result.MessageCheck = "Не все суточные нормы веществ были заданы.\n\n";
                ErrorsList.Add(result);
            }
            Program.sqlConnection.Close();
            return result;
        }

        private string CheckIntegrity()
        {
            string errorsText = "";
            ErrorsList.Clear();
            CheckIfHasProductsNames();
            CheckIfHasCategories();
            CheckIfHasCompatibleCategories();
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
            string integrityErrors = CheckIntegrity();
            if (integrityErrors != "")
            {
                MessageFormLarge ErrorFormIntegrity = new MessageFormLarge();
                ErrorFormIntegrity.LabelText.Text = integrityErrors;
                ErrorFormIntegrity.Text = "Проверка целостности базы данных";
                ErrorFormIntegrity.ShowDialog();
            }
            else 
            {
                MessageFormSmall OKFormIntegrity = new MessageFormSmall();
                OKFormIntegrity.LabelText.Text = "Проверка целостности базы данных прошла успешно.\nЗакройте это окно для дальнейшей работы.";
                OKFormIntegrity.Text = "Проверка целостности базы данных";
                OKFormIntegrity.ShowDialog();
                TaskSolver TaskSolver = new TaskSolver();
                TaskSolver.ShowDialog();
            }
        }
    }
}
