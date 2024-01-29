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
        private DataTable CategoriesTable = new DataTable();

        public Products()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter("SELECT * FROM [КАТЕГОРИЯ_ПРОДУКТОВ]", Program.sqlConnection);
            adapter.Fill(CategoriesTable);
            PCategoriesComboBox.DataSource = CategoriesTable;
            PCategoriesComboBox.DisplayMember = "Название_категории_продуктов";
            PCategoriesComboBox.ValueMember = "ID_категории_продуктов";
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
                if (Program.sqlConnection.State == ConnectionState.Open)
                    Program.sqlConnection.Close();
                Program.sqlConnection.Open();
                SqlCommand checkIsUnique = new SqlCommand("SELECT COUNT(*) FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + ProductTextBox.Text.ToString() + "';", Program.sqlConnection);
                int res = (int)checkIsUnique.ExecuteScalar();
                if (res == 0)
                {
                    string proteins = PProteinsNumericUpDown.Value.ToString();
                    proteins = proteins.Replace(',', '.');
                    string fats = PFatsNumericUpDown.Value.ToString();
                    fats = fats.Replace(',', '.');
                    string carhyd = PCarhydNumericUpDown.Value.ToString();
                    carhyd = carhyd.Replace(',', '.');
                    string vitA = PVitANumericUpDown.Value.ToString();
                    vitA = vitA.Replace(',', '.');
                    string vitB1 = PVitB1NumericUpDown.Value.ToString();
                    vitB1 = vitB1.Replace(',', '.');
                    string vitC = PVitCNumericUpDown.Value.ToString();
                    vitC = vitC.Replace(',', '.');
                    string cellss = PCellNumericUpDown.Value.ToString();
                    cellss = cellss.Replace(',', '.');
                    string energy = PEnergyNumericUpDown.Value.ToString();
                    string idCat = PCategoriesComboBox.SelectedValue.ToString();
                    string price = PPriceNumericUpDown.Value.ToString();
                    price = price.Replace(',', '.');
                    byte noGastritis = Convert.ToByte(PPGastritisCheckbox.Checked);
                    byte noDiabetes = Convert.ToByte(PPDiabetesCheckbox.Checked);
                    SqlCommand addProduct = new SqlCommand("INSERT INTO [ПРОДУКТ] VALUES (N'" + ProductTextBox.Text.ToString() + "', CONVERT(DECIMAL(6, 3), " + proteins + "), CONVERT(DECIMAL(6, 3), " + fats + "), CONVERT(DECIMAL(6, 3), " + carhyd + "), CONVERT(DECIMAL(7, 3), " + vitA + "), CONVERT(DECIMAL(6, 3), " + vitB1 + "), CONVERT(DECIMAL(6, 3), " + vitC + "), CONVERT(DECIMAL(6, 3), " + cellss + "), " + energy + ", " + idCat + ", CONVERT(DECIMAL(6, 2), " + price + "), " + noGastritis + ", " + noDiabetes + ");", Program.sqlConnection);
                    addProduct.ExecuteNonQuery();
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
                if (ProductTextBox.Text == "")
                {
                    MessageFormSmall ErrorForm = new MessageFormSmall();
                    ErrorForm.LabelText.Text = "Название продукта не может быть пустым.";
                    ErrorForm.Text = "Ошибка";
                    ErrorForm.ShowDialog();
                }
                else
                {
                    if (Program.sqlConnection.State == ConnectionState.Open)
                        Program.sqlConnection.Close();
                    Program.sqlConnection.Open();
                    SqlCommand checkIsUnique = new SqlCommand("SELECT COUNT(*) FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + ProductTextBox.Text.ToString() + "';", Program.sqlConnection);
                    int res = (int)checkIsUnique.ExecuteScalar();
                    if (res == 0)
                    {
                        DataRowView itemProd = (DataRowView)PProductsListBox.SelectedItem;
                        string nameToEdit = itemProd.Row[1].ToString();
                        string newProductName = nameToEdit;
                        if (ProductTextBox.Text.ToString() != "")
                            newProductName = ProductTextBox.Text.ToString();
                        string proteins = PProteinsNumericUpDown.Value.ToString();
                        proteins = proteins.Replace(',', '.');
                        string fats = PFatsNumericUpDown.Value.ToString();
                        fats = fats.Replace(',', '.');
                        string carhyd = PCarhydNumericUpDown.Value.ToString();
                        carhyd = carhyd.Replace(',', '.');
                        string vitA = PVitANumericUpDown.Value.ToString();
                        vitA = vitA.Replace(',', '.');
                        string vitB1 = PVitB1NumericUpDown.Value.ToString();
                        vitB1 = vitB1.Replace(',', '.');
                        string vitC = PVitCNumericUpDown.Value.ToString();
                        vitC = vitC.Replace(',', '.');
                        string cellss = PCellNumericUpDown.Value.ToString();
                        cellss = cellss.Replace(',', '.');
                        string energy = PEnergyNumericUpDown.Value.ToString();
                        string idCat = PCategoriesComboBox.SelectedValue.ToString();
                        string price = PPriceNumericUpDown.Value.ToString();
                        price = price.Replace(',', '.');
                        byte gastritis = Convert.ToByte(PPGastritisCheckbox.Checked);
                        byte diabetes = Convert.ToByte(PPDiabetesCheckbox.Checked);
                        SqlCommand editProduct = new SqlCommand("UPDATE [ПРОДУКТ] SET [Название_продукта] = N'" + newProductName + "', [Содержание_белков_на_100_г_продукта] = CONVERT(DECIMAL(6, 3), " + proteins + "), [Содержание_жиров_на_100_г_продукта] = CONVERT(DECIMAL(6, 3), " + fats + "), [Содержание_углеводов_на_100_г_продукта] = CONVERT(DECIMAL(6, 3), " + carhyd + "), [Содержание_витамина_A_на_100_г_продукта] = CONVERT(DECIMAL(7, 3), " + vitA + "), [Содержание_витамина_B1_на_100_г_продукта] = CONVERT(DECIMAL(6, 3), " + vitB1 + "), [Содержание_витамина_C_на_100_г_продукта] = CONVERT(DECIMAL(6, 3), " + vitC + "), [Содержание_клетчатки_на_100_г_продукта] = CONVERT(DECIMAL(6, 3), " + cellss + "), [Калорийность_на_100_г_продукта] = " + energy + ", [ID_категории_продуктов] = " + idCat + ", [Стоимость_100_г_продукта] =  CONVERT(DECIMAL(6, 2), " + price + ", [Запрет_при_гастрите] = " + gastritis + ", [Запрет_при_диабете] = " + diabetes + ") WHERE [Название_продукта] = N'" + nameToEdit + "'; ", Program.sqlConnection);
                        editProduct.ExecuteNonQuery();
                        ProductTextBox.Clear();
                        ProductsTable = new DataTable();
                        PProductsListBox.DataSource = ProductsTable;
                        adapter = new SqlDataAdapter("SELECT * FROM [ПРОДУКТ]", Program.sqlConnection);
                        adapter.Fill(ProductsTable);
                        PProductsListBox.DataSource = ProductsTable;
                        PProductsListBox.DisplayMember = "Название_продукта";
                        PProductsListBox.ValueMember = "ID_продукта";
                        PProductsListBox.SelectedIndex = choice;
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
                if (Program.sqlConnection.State == ConnectionState.Open)
                    Program.sqlConnection.Close();
                Program.sqlConnection.Open();
                DataRowView item = (DataRowView) PProductsListBox.SelectedItem;
                int idToDelete = (int)item.Row[0];
                string nameToDelete = item.Row[1].ToString();
                SqlCommand checkIsOkToDelete = new SqlCommand("SELECT COUNT(*) FROM [ЭЛЕМЕНТ_РАЦИОНА] WHERE [ID_продукта] = " + idToDelete + ";", Program.sqlConnection);
                int res = (int)checkIsOkToDelete.ExecuteScalar();
                if (res == 0)
                {
                    SqlCommand deleteProduct = new SqlCommand("DELETE FROM [ПРОДУКТ] WHERE [Название_продукта] = N'" + nameToDelete + "';", Program.sqlConnection);
                    deleteProduct.ExecuteNonQuery();
                    ProductTextBox.Clear();
                    ProductsTable = new DataTable();
                    PProductsListBox.DataSource = ProductsTable;
                    adapter = new SqlDataAdapter("SELECT * FROM [ПРОДУКТ]", Program.sqlConnection);
                    adapter.Fill(ProductsTable);
                    PProductsListBox.DataSource = ProductsTable;
                    PProductsListBox.DisplayMember = "Название_продукта";
                    PProductsListBox.ValueMember = "ID_продукта";
                    PProductsListBox.SelectedIndex = choice - 1;
                }
                else
                {
                    MessageFormSmall ErrorForm = new MessageFormSmall();
                    ErrorForm.LabelText.Text = "Удаление продукта невозможно ввиду его использования как минимум в одном составленном ранее рационе.";
                    ErrorForm.Text = "Ошибка";
                    ErrorForm.ShowDialog();
                }
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

        private void PProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView itemProd = (DataRowView)PProductsListBox.SelectedItem;
            int selectedProductId = (int)itemProd.Row[0];
            if (Program.sqlConnection.State == ConnectionState.Open)
                Program.sqlConnection.Close();
            Program.sqlConnection.Open();
            SqlCommand getValue = new SqlCommand("SELECT [Содержание_белков_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            object value = getValue.ExecuteScalar();
            PProteinsNumericUpDown.Value = (decimal)value;
            getValue = new SqlCommand("SELECT [Содержание_жиров_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            PFatsNumericUpDown.Value = (decimal)value;
            getValue = new SqlCommand("SELECT [Содержание_углеводов_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            PCarhydNumericUpDown.Value = (decimal)value;
            getValue = new SqlCommand("SELECT [Содержание_витамина_A_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            PVitANumericUpDown.Value = (decimal)value;
            getValue = new SqlCommand("SELECT [Содержание_витамина_B1_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            PVitB1NumericUpDown.Value = (decimal)value;
            getValue = new SqlCommand("SELECT [Содержание_витамина_C_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            PVitCNumericUpDown.Value = (decimal)value;
            getValue = new SqlCommand("SELECT [Содержание_клетчатки_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            PCellNumericUpDown.Value = (decimal)value;
            getValue = new SqlCommand("SELECT [Калорийность_на_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            PEnergyNumericUpDown.Value = (int)value;
            getValue = new SqlCommand("SELECT [ПРОДУКТ].[ID_категории_продуктов] FROM [ПРОДУКТ] JOIN [КАТЕГОРИЯ_ПРОДУКТОВ] ON [ПРОДУКТ].[ID_категории_продуктов] = [КАТЕГОРИЯ_ПРОДУКТОВ].[ID_категории_продуктов] WHERE [ПРОДУКТ].[ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            PCategoriesComboBox.SelectedValue = value;
            getValue = new SqlCommand("SELECT [Стоимость_100_г_продукта] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            PPriceNumericUpDown.Value = (decimal)value;
            getValue = new SqlCommand("SELECT [Запрет_при_гастрите] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            if (value.ToString() == "1")
                PPGastritisCheckbox.Checked = true;
            else
                PPGastritisCheckbox.Checked = false;
            getValue = new SqlCommand("SELECT [Запрет_при_диабете] FROM [ПРОДУКТ] WHERE [ID_продукта] = " + selectedProductId + ";", Program.sqlConnection);
            value = getValue.ExecuteScalar();
            if (value.ToString() == "1")
                PPDiabetesCheckbox.Checked = true;
            else
                PPDiabetesCheckbox.Checked = false;
            Program.sqlConnection.Close();
        }
    }
}