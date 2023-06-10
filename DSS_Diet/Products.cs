using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class Products : Form
    {
        private SqlDataAdapter adapter;
        private DataTable ProductsTable = new DataTable();

        public Products()
        {
            InitializeComponent();
        }

        private void PAddButton_Click(object sender, EventArgs e)
        {
            if (ProductTextBox.Text == "")
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Название продукта не может быть пустым.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
            else
            {
                Program.sqlConnection.Open();
                SqlCommand checkIsUnique = new SqlCommand("SELECT COUNT(*) FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + ProductTextBox.Text.ToString() + "';", Program.sqlConnection);
                int res = (int)checkIsUnique.ExecuteScalar();
                if (res == 0)
                {
                    SqlCommand addProductName = new SqlCommand("INSERT INTO [ПРОДУКТ] VALUES (N'" + ProductTextBox.Text.ToString() + "');", Program.sqlConnection);
                    addProductName.ExecuteNonQuery();
                    ProductTextBox.Clear();
                    ProductsTable = new DataTable();
                    PProductsListBox.DataSource = ProductsTable;
                    adapter = new SqlDataAdapter("SELECT * FROM [ПРОДУКТ]", Program.sqlConnection);
                    adapter.Fill(ProductsTable);
                    PProductsListBox.DataSource = ProductsTable;
                    PProductsListBox.DisplayMember = "Название_продукта";
                    PProductsListBox.ValueMember = "ID_продукта";
                    PProductsListBox.SelectedIndex = PProductsListBox.Items.Count - 1;
                }
                else
                {
                    MessageFormSmall ErrorForm = new MessageFormSmall();
                    ErrorForm.LabelText.Text = "Продукт с таким названием уже существует.";
                    ErrorForm.Text = "Ошибка";
                    ErrorForm.ShowDialog();
                }
                Program.sqlConnection.Close();
            }
        }

        private void CEditButton_Click(object sender, EventArgs e)
        {
            int choice = PProductsListBox.SelectedIndex;
            if (choice == -1)
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Выберите название продукта.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
            else
            {
                Program.sqlConnection.Open();
                DataRowView item = (DataRowView)PProductsListBox.SelectedItem;
                string nameToEdit = item.Row[1].ToString();
                SqlCommand editCategory = new SqlCommand("UPDATE [ПРОДУКТ] SET [Название_продукта] = N'" + ProductTextBox.Text.ToString() + "' WHERE [Название_продукта] = N'" + nameToEdit + "'; ", Program.sqlConnection);
                editCategory.ExecuteNonQuery();
                ProductTextBox.Clear();
                ProductsTable = new DataTable();
                PProductsListBox.DataSource = ProductsTable;
                adapter = new SqlDataAdapter("SELECT * FROM [ПРОДУКТ]", Program.sqlConnection);
                adapter.Fill(ProductsTable);
                PProductsListBox.DataSource = ProductsTable;
                PProductsListBox.DisplayMember = "Название_продукта";
                PProductsListBox.ValueMember = "ID_продукта";
                PProductsListBox.SelectedIndex = choice;
                Program.sqlConnection.Close();
            }
        }

        private void PDeleteButton_Click(object sender, EventArgs e)
        {
            int choice = PProductsListBox.SelectedIndex;
            if (choice == -1)
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Выберите название продукта.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
            else
            {
                Program.sqlConnection.Open();
                DataRowView item = (DataRowView) PProductsListBox.SelectedItem;
                string nameToDelete = item.Row[1].ToString();
                SqlCommand deleteProductName = new SqlCommand("DELETE FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + nameToDelete + "';", Program.sqlConnection);
                deleteProductName.ExecuteNonQuery();
                ProductTextBox.Clear();
                ProductsTable = new DataTable();
                PProductsListBox.DataSource = ProductsTable;
                adapter = new SqlDataAdapter("SELECT * FROM [ПРОДУКТ]", Program.sqlConnection);
                adapter.Fill(ProductsTable);
                PProductsListBox.DataSource = ProductsTable;
                PProductsListBox.DisplayMember = "Название_продукта";
                PProductsListBox.ValueMember = "ID_продукта";
                PProductsListBox.SelectedIndex = choice - 1;
                Program.sqlConnection.Close();
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM [ПРОДУКТ]", Program.sqlConnection);
            adapter.Fill(ProductsTable);
            PProductsListBox.DataSource = ProductsTable;
            PProductsListBox.DisplayMember = "Название_продукта";
            PProductsListBox.ValueMember = "ID_продукта";
        }
    }
}
