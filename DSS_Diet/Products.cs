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
                SqlCommand checkIsUnique = new SqlCommand("SELECT COUNT(*) FROM ProductsNames WHERE Name = N'" + ProductTextBox.Text.ToString() + "';", Program.sqlConnection);
                int res = (int)checkIsUnique.ExecuteScalar();
                if (res == 0)
                {
                    SqlCommand addProductName = new SqlCommand("INSERT INTO ProductsNames VALUES (N'" + ProductTextBox.Text.ToString() + "');", Program.sqlConnection);
                    addProductName.ExecuteNonQuery();
                    ProductTextBox.Clear();
                    ProductsTable = new DataTable();
                    PProductsListBox.DataSource = ProductsTable;
                    adapter = new SqlDataAdapter("SELECT * FROM ProductsNames", Program.sqlConnection);
                    adapter.Fill(ProductsTable);
                    PProductsListBox.DataSource = ProductsTable;
                    PProductsListBox.DisplayMember = "Name";
                    PProductsListBox.ValueMember = "Id";
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
                SqlCommand deleteProductName = new SqlCommand("DELETE FROM ProductsNames WHERE Name = N'" + nameToDelete + "';", Program.sqlConnection);
                deleteProductName.ExecuteNonQuery();
                ProductsTable = new DataTable();
                PProductsListBox.DataSource = ProductsTable;
                adapter = new SqlDataAdapter("SELECT * FROM ProductsNames", Program.sqlConnection);
                adapter.Fill(ProductsTable);
                PProductsListBox.DataSource = ProductsTable;
                PProductsListBox.DisplayMember = "Name";
                PProductsListBox.ValueMember = "Id";
                Program.sqlConnection.Close();
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM ProductsNames", Program.sqlConnection);
            adapter.Fill(ProductsTable);
            PProductsListBox.DataSource = ProductsTable;
            PProductsListBox.DisplayMember = "Name";
            PProductsListBox.ValueMember = "Id";
        }
    }
}
