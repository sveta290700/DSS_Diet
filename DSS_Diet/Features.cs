using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class Features : Form
    {
        private SqlDataAdapter adapter;
        private DataTable FeaturesTable = new DataTable();

        public Features()
        {
            InitializeComponent();
        }

        private void FAddButton_Click(object sender, EventArgs e)
        {
            if (FeatureTextBox.Text == "")
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Название признака не может быть пустым.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
            else
            {
                Program.sqlConnection.Open();
                SqlCommand checkIsUnique = new SqlCommand("SELECT COUNT(*) FROM Features WHERE Name = N'" + FeatureTextBox.Text.ToString() + "';", Program.sqlConnection);
                int res = (int)checkIsUnique.ExecuteScalar();
                if (res == 0)
                {
                    SqlCommand addProductName = new SqlCommand("INSERT INTO Features VALUES (N'" + FeatureTextBox.Text.ToString() + "');", Program.sqlConnection);
                    addProductName.ExecuteNonQuery();
                    FeatureTextBox.Clear();
                    FeaturesTable = new DataTable();
                    FFeaturesListBox.DataSource = FeaturesTable;
                    adapter = new SqlDataAdapter("SELECT * FROM Features", Program.sqlConnection);
                    adapter.Fill(FeaturesTable);
                    FFeaturesListBox.DataSource = FeaturesTable;
                    FFeaturesListBox.DisplayMember = "Name";
                    FFeaturesListBox.ValueMember = "Id";
                }
                else
                {
                    MessageFormSmall ErrorForm = new MessageFormSmall();
                    ErrorForm.LabelText.Text = "Признак продуктов с таким названием уже существует.";
                    ErrorForm.Text = "Ошибка";
                    ErrorForm.ShowDialog();
                }
                Program.sqlConnection.Close();
            }
        }

        private void FDeleteButton_Click(object sender, EventArgs e)
        {
            int choice = FFeaturesListBox.SelectedIndex;
            if (choice == -1)
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Выберите признак продукта.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
            else
            {
                DataRowView item = (DataRowView)FFeaturesListBox.SelectedItem;
                string nameToDelete = item.Row[1].ToString();
                if (nameToDelete == "стоимость за 1 кг продукта")
                {
                    MessageFormSmall ErrorForm = new MessageFormSmall();
                    ErrorForm.LabelText.Text = "Признак стоимости является зафиксированным.\nЕго удаление невозможно.";
                    ErrorForm.Text = "Ошибка";
                    ErrorForm.ShowDialog();
                }
                else
                {
                    Program.sqlConnection.Open();
                    SqlCommand deleteFeature = new SqlCommand("DELETE FROM Features WHERE Name = N'" + nameToDelete + "';", Program.sqlConnection);
                    deleteFeature.ExecuteNonQuery();
                    FeaturesTable = new DataTable();
                    FFeaturesListBox.DataSource = FeaturesTable;
                    adapter = new SqlDataAdapter("SELECT * FROM Features", Program.sqlConnection);
                    adapter.Fill(FeaturesTable);
                    FFeaturesListBox.DataSource = FeaturesTable;
                    FFeaturesListBox.DisplayMember = "Name";
                    FFeaturesListBox.ValueMember = "Id";
                    Program.sqlConnection.Close();
                }
            }
        }

        private void Features_Load(object sender, EventArgs e)
        {
            Program.sqlConnection.Open();
            SqlCommand countFeatures = new SqlCommand("SELECT COUNT(*) FROM Features WHERE Name = N'стоимость за 1 кг продукта';", Program.sqlConnection);
            int res = (int)countFeatures.ExecuteScalar();
            if (res == 0)
            {
                SqlCommand addPriceFeature = new SqlCommand("INSERT INTO Features VALUES (N'стоимость за 1 кг продукта');", Program.sqlConnection);
                addPriceFeature.ExecuteNonQuery();
            }
            adapter = new SqlDataAdapter("SELECT * FROM Features", Program.sqlConnection);
            adapter.Fill(FeaturesTable);
            FFeaturesListBox.DataSource = FeaturesTable;
            FFeaturesListBox.DisplayMember = "Name";
            FFeaturesListBox.ValueMember = "Id";
            Program.sqlConnection.Close();
        }
    }
}
