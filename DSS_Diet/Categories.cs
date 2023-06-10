using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class Categories : Form
    {
        private SqlDataAdapter adapter;
        private DataTable CategoriesTable = new DataTable();

        public Categories()
        {
            InitializeComponent();
        }

        private void CAddButton_Click(object sender, EventArgs e)
        {
            if (CategoryTextBox.Text == "")
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Название категории не может быть пустым.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
            else
            {
                Program.sqlConnection.Open();
                SqlCommand checkIsUnique = new SqlCommand("SELECT COUNT(*) FROM [КАТЕГОРИЯ_ПРОДУКТОВ] WHERE [Название_категории_продуктов] = N'" + CategoryTextBox.Text.ToString() + "';", Program.sqlConnection);
                int res = (int)checkIsUnique.ExecuteScalar();
                if (res == 0)
                {
                    SqlCommand addProductName = new SqlCommand("INSERT INTO [КАТЕГОРИЯ_ПРОДУКТОВ] VALUES (N'" + CategoryTextBox.Text.ToString() + "');", Program.sqlConnection);
                    addProductName.ExecuteNonQuery();
                    CategoryTextBox.Clear();
                    CategoriesTable = new DataTable();
                    CCategoriesListBox.DataSource = CategoriesTable;
                    adapter = new SqlDataAdapter("SELECT * FROM [КАТЕГОРИЯ_ПРОДУКТОВ]", Program.sqlConnection);
                    adapter.Fill(CategoriesTable);
                    CCategoriesListBox.DataSource = CategoriesTable;
                    CCategoriesListBox.DisplayMember = "Название_категории_продуктов";
                    CCategoriesListBox.ValueMember = "ID_категории_продуктов";
                }
                else
                {
                    MessageFormSmall ErrorForm = new MessageFormSmall();
                    ErrorForm.LabelText.Text = "Категория с таким названием уже существует.";
                    ErrorForm.Text = "Ошибка";
                    ErrorForm.ShowDialog();
                }
                Program.sqlConnection.Close();
            }
        }

        private void CEditButton_Click(object sender, EventArgs e)
        {
            int choice = CCategoriesListBox.SelectedIndex;
            if (choice == -1)
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Выберите название категории.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
            else
            {
                Program.sqlConnection.Open();
                DataRowView item = (DataRowView)CCategoriesListBox.SelectedItem;
                string nameToEdit = item.Row[1].ToString();
                SqlCommand editCategory = new SqlCommand("UPDATE [КАТЕГОРИЯ_ПРОДУКТОВ] SET [Название_категории_продуктов] = N'" + CategoryTextBox.Text.ToString() + "' WHERE [Название_категории_продуктов] = N'" + nameToEdit + "'; ", Program.sqlConnection);
                editCategory.ExecuteNonQuery();
                CategoriesTable = new DataTable();
                CCategoriesListBox.DataSource = CategoriesTable;
                adapter = new SqlDataAdapter("SELECT * FROM [КАТЕГОРИЯ_ПРОДУКТОВ]", Program.sqlConnection);
                adapter.Fill(CategoriesTable);
                CCategoriesListBox.DataSource = CategoriesTable;
                CCategoriesListBox.DisplayMember = "Название_категории_продуктов";
                CCategoriesListBox.ValueMember = "ID_категории_продуктов";
                Program.sqlConnection.Close();
            }
        }

        private void CDeleteButton_Click(object sender, EventArgs e)
        {
            int choice = CCategoriesListBox.SelectedIndex;
            if (choice == -1)
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Выберите название категории.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
            else
            {
                Program.sqlConnection.Open();
                DataRowView item = (DataRowView)CCategoriesListBox.SelectedItem;
                string nameToDelete = item.Row[1].ToString();
                SqlCommand deleteCategory = new SqlCommand("DELETE FROM [КАТЕГОРИЯ_ПРОДУКТОВ] WHERE [Название_категории_продуктов] = N'" + nameToDelete + "';", Program.sqlConnection);
                deleteCategory.ExecuteNonQuery();
                CategoriesTable = new DataTable();
                CCategoriesListBox.DataSource = CategoriesTable;
                adapter = new SqlDataAdapter("SELECT * FROM [КАТЕГОРИЯ_ПРОДУКТОВ]", Program.sqlConnection);
                adapter.Fill(CategoriesTable);
                CCategoriesListBox.DataSource = CategoriesTable;
                CCategoriesListBox.DisplayMember = "Название_категории_продуктов";
                CCategoriesListBox.ValueMember = "ID_категории_продуктов";
                Program.sqlConnection.Close();
            }
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM [КАТЕГОРИЯ_ПРОДУКТОВ]", Program.sqlConnection);
            adapter.Fill(CategoriesTable);
            CCategoriesListBox.DataSource = CategoriesTable;
            CCategoriesListBox.DisplayMember = "Название_категории_продуктов";
            CCategoriesListBox.ValueMember = "ID_категории_продуктов";
        }
    }
}
