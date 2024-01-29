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
                if (Program.sqlConnection.State == ConnectionState.Open)
                    Program.sqlConnection.Close();
                Program.sqlConnection.Open();
                SqlCommand checkIsUnique = new SqlCommand("SELECT COUNT(*) FROM [КАТЕГОРИЯ_ПРОДУКТОВ] WHERE [Название_категории_продуктов] = N'" + CategoryTextBox.Text.ToString() + "';", Program.sqlConnection);
                int res = (int)checkIsUnique.ExecuteScalar();
                if (res == 0)
                {
                    SqlCommand addCategoryName = new SqlCommand("INSERT INTO [КАТЕГОРИЯ_ПРОДУКТОВ] VALUES (N'" + CategoryTextBox.Text.ToString() + "');", Program.sqlConnection);
                    addCategoryName.ExecuteNonQuery();
                    SqlCommand getCategoryId = new SqlCommand("SELECT [ID_категории_продуктов] FROM [КАТЕГОРИЯ_ПРОДУКТОВ] WHERE [Название_категории_продуктов] = N'" + CategoryTextBox.Text.ToString() + "';", Program.sqlConnection);
                    int categoryId = (int)getCategoryId.ExecuteScalar();
                    SqlCommand addCategoryCompatibility = new SqlCommand("INSERT INTO [СОВМЕСТИМОСТЬ_КАТЕГОРИЙ_ПРОДУКТОВ] VALUES (" + categoryId + ", " + categoryId + ");", Program.sqlConnection);
                    addCategoryCompatibility.ExecuteNonQuery();
                    CategoryTextBox.Clear();
                    CategoriesTable = new DataTable();
                    CCategoriesListBox.DataSource = CategoriesTable;
                    adapter = new SqlDataAdapter("SELECT * FROM [КАТЕГОРИЯ_ПРОДУКТОВ]", Program.sqlConnection);
                    adapter.Fill(CategoriesTable);
                    CCategoriesListBox.DataSource = CategoriesTable;
                    CCategoriesListBox.DisplayMember = "Название_категории_продуктов";
                    CCategoriesListBox.ValueMember = "ID_категории_продуктов";
                    CCategoriesListBox.SelectedIndex = CCategoriesListBox.Items.Count - 1;
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
                if (CategoryTextBox.Text == "")
                {
                    MessageFormSmall ErrorForm = new MessageFormSmall();
                    ErrorForm.LabelText.Text = "Название категории не может быть пустым.";
                    ErrorForm.Text = "Ошибка";
                    ErrorForm.ShowDialog();
                }
                else
                {
                    if (Program.sqlConnection.State == ConnectionState.Open)
                        Program.sqlConnection.Close();
                    Program.sqlConnection.Open();
                    SqlCommand checkIsUnique = new SqlCommand("SELECT COUNT(*) FROM [КАТЕГОРИЯ_ПРОДУКТОВ] WHERE [Название_категории_продуктов] = N'" + CategoryTextBox.Text.ToString() + "';", Program.sqlConnection);
                    int res = (int)checkIsUnique.ExecuteScalar();
                    if (res == 0)
                    {
                        DataRowView itemCat = (DataRowView)CCategoriesListBox.SelectedItem;
                        string nameToEdit = itemCat.Row[1].ToString();
                        SqlCommand editCategory = new SqlCommand("UPDATE [КАТЕГОРИЯ_ПРОДУКТОВ] SET [Название_категории_продуктов] = N'" + CategoryTextBox.Text.ToString() + "' WHERE [Название_категории_продуктов] = N'" + nameToEdit + "'; ", Program.sqlConnection);
                        editCategory.ExecuteNonQuery();
                        CategoryTextBox.Clear();
                        CategoriesTable = new DataTable();
                        CCategoriesListBox.DataSource = CategoriesTable;
                        adapter = new SqlDataAdapter("SELECT * FROM [КАТЕГОРИЯ_ПРОДУКТОВ]", Program.sqlConnection);
                        adapter.Fill(CategoriesTable);
                        CCategoriesListBox.DataSource = CategoriesTable;
                        CCategoriesListBox.DisplayMember = "Название_категории_продуктов";
                        CCategoriesListBox.ValueMember = "ID_категории_продуктов";
                        CCategoriesListBox.SelectedIndex = choice;
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
                if (Program.sqlConnection.State == ConnectionState.Open)
                    Program.sqlConnection.Close();
                Program.sqlConnection.Open();
                DataRowView item = (DataRowView)CCategoriesListBox.SelectedItem;
                int idToDelete = (int)item.Row[0];
                string nameToDelete = item.Row[1].ToString();
                SqlCommand checkIsOkToDelete1 = new SqlCommand("SELECT COUNT(*) FROM [ПРОДУКТ] WHERE [ID_категории_продуктов] = " + idToDelete + ";", Program.sqlConnection);
                int res1 = (int)checkIsOkToDelete1.ExecuteScalar();
                SqlCommand checkIsOkToDelete2 = new SqlCommand("SELECT COUNT(*) FROM [ЭЛЕМЕНТ_РАЦИОНА] JOIN [ПРОДУКТ] ON [ЭЛЕМЕНТ_РАЦИОНА].[ID_продукта] = [ПРОДУКТ].[ID_продукта] WHERE [ПРОДУКТ].[ID_категории_продуктов] = " + idToDelete + ";", Program.sqlConnection);
                int res2 = (int)checkIsOkToDelete2.ExecuteScalar();
                if ((res1 == 0) && (res2 == 0))
                {
                    SqlCommand deleteCategory = new SqlCommand("DELETE FROM [КАТЕГОРИЯ_ПРОДУКТОВ] WHERE [Название_категории_продуктов] = N'" + nameToDelete + "';", Program.sqlConnection);
                    deleteCategory.ExecuteNonQuery();
                    CategoryTextBox.Clear();
                    CategoriesTable = new DataTable();
                    CCategoriesListBox.DataSource = CategoriesTable;
                    adapter = new SqlDataAdapter("SELECT * FROM [КАТЕГОРИЯ_ПРОДУКТОВ]", Program.sqlConnection);
                    adapter.Fill(CategoriesTable);
                    CCategoriesListBox.DataSource = CategoriesTable;
                    CCategoriesListBox.DisplayMember = "Название_категории_продуктов";
                    CCategoriesListBox.ValueMember = "ID_категории_продуктов";
                    CCategoriesListBox.SelectedIndex = choice - 1;
                }
                else
                {
                    MessageFormSmall ErrorForm = new MessageFormSmall();
                    ErrorForm.LabelText.Text = "Удаление категории невозможно ввиду ее использования для описания как минимум одного продукта.";
                    ErrorForm.Text = "Ошибка";
                    ErrorForm.ShowDialog();
                }
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
