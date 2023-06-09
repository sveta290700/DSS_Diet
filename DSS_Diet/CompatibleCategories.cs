using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace DietProject
{
    public partial class CompatibleCategories : Form
    {
        private SqlDataAdapter adapter;
        private DataTable CategoriesTable = new DataTable();
        private DataTable CategoriesIdTableCC = new DataTable();
        private DataTable SelectedCategoriesTable = new DataTable();
        private DataTable Category1Table = new DataTable();
        private List<int> CategoriesIdCCList = new List<int>();
        private List<string> CategoriesList = new List<string>();
        private List<string> leftList = new List<string>();
        private List<string> rightList = new List<string>();
        private List<string> Category1List = new List<string>();

        public CompatibleCategories()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter("SELECT * FROM Categories", Program.sqlConnection);
            adapter.Fill(CategoriesTable);
            CategoriesList = CategoriesTable.AsEnumerable().Select(n => n.Field<string>(1)).ToList();
            adapter = new SqlDataAdapter("SELECT CategoryId2 FROM CompatibleCategories", Program.sqlConnection);
            adapter.Fill(CategoriesIdTableCC);
            CategoriesIdCCList = CategoriesIdTableCC.AsEnumerable().Select(n => n.Field<int>(0)).ToList();
            Program.sqlConnection.Open();
            foreach (var categoryIdCC in CategoriesIdCCList)
            {
                SqlCommand checkIfExists2 = new SqlCommand("SELECT COUNT(*) FROM Categories WHERE Id = " + categoryIdCC + ";", Program.sqlConnection);
                int resIfExists = (int)checkIfExists2.ExecuteScalar();
                if (resIfExists == 0)
                {
                    SqlCommand deleteOld = new SqlCommand("DELETE FROM CompatibleCategories WHERE CategoryId2 = " + categoryIdCC + ";", Program.sqlConnection);
                    deleteOld.ExecuteNonQuery();
                }
            }
            Program.sqlConnection.Close();
            CCCategoriesComboBox.DataSource = CategoriesTable;
            CCCategoriesComboBox.DisplayMember = "Name";
            CCCategoriesComboBox.ValueMember = "Id";
        }

        private void CCCategoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CCCategoriesComboBox.SelectedIndex != -1)
            {
                CCCategoriesListBox.Items.Clear();
                CCCompatibleCategoriesListBox.Items.Clear();
                DataRowView item = (DataRowView)CCCategoriesComboBox.SelectedItem;
                int selectedCategoryId = (int)item.Row[0];
                leftList = new List<string>(CategoriesList);
                SelectedCategoriesTable = new DataTable();
                adapter = new SqlDataAdapter("SELECT Name FROM Categories JOIN CompatibleCategories ON Categories.Id = CompatibleCategories.CategoryId2 WHERE CategoryId1 = " + selectedCategoryId + ";", Program.sqlConnection);
                adapter.Fill(SelectedCategoriesTable);
                rightList = SelectedCategoriesTable.AsEnumerable().Select(n => n.Field<string>(0)).ToList();
                Category1Table = new DataTable();
                adapter = new SqlDataAdapter("SELECT Name FROM Categories WHERE Id = " + selectedCategoryId + ";", Program.sqlConnection);
                adapter.Fill(Category1Table);
                Category1List = Category1Table.AsEnumerable().Select(n => n.Field<string>(0)).ToList();
                leftList = leftList.Except(rightList).ToList();
                leftList = leftList.Except(Category1List).ToList();
                foreach (var itemLeft in leftList)
                {
                    CCCategoriesListBox.Items.Add(itemLeft);
                }
                foreach (var itemRight in rightList)
                {
                    CCCompatibleCategoriesListBox.Items.Add(itemRight);
                }
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

        private void CCSelectButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(CCCategoriesListBox, CCCompatibleCategoriesListBox);
        }

        private void CCUnselectButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(CCCompatibleCategoriesListBox, CCCategoriesListBox);
        }

        private void CCSaveButton_Click(object sender, EventArgs e)
        {
            if (CCCategoriesComboBox.SelectedIndex != -1)
            {
                Program.sqlConnection.Open();
                DataRowView item = (DataRowView)CCCategoriesComboBox.SelectedItem;
                int selectedCategoryId = (int)item.Row[0];
                SqlCommand deleteOldRecords1 = new SqlCommand("DELETE FROM CompatibleCategories WHERE CategoryId1 = " + selectedCategoryId + ";", Program.sqlConnection);
                deleteOldRecords1.ExecuteNonQuery();
                SqlCommand deleteOldRecords2 = new SqlCommand("DELETE FROM CompatibleCategories WHERE CategoryId2 = " + selectedCategoryId + ";", Program.sqlConnection);
                deleteOldRecords2.ExecuteNonQuery();
                foreach (var itemToAdd in CCCompatibleCategoriesListBox.Items)
                {
                    SqlCommand getCatId = new SqlCommand("SELECT Id FROM Categories WHERE Name = N'" + itemToAdd + "';", Program.sqlConnection);
                    int catId = (int)getCatId.ExecuteScalar();
                    SqlCommand insertNewRecord1 = new SqlCommand("INSERT INTO CompatibleCategories VALUES (" + selectedCategoryId + ", " + catId + ");", Program.sqlConnection);
                    insertNewRecord1.ExecuteNonQuery();
                    SqlCommand insertNewRecord2 = new SqlCommand("INSERT INTO CompatibleCategories VALUES (" + catId + ", " + selectedCategoryId + ");", Program.sqlConnection);
                    insertNewRecord2.ExecuteNonQuery();
                }
                int selectedIndex = CCCategoriesComboBox.SelectedIndex;
                CCCategoriesComboBox.SelectedIndex = -1;
                CCCategoriesComboBox.SelectedIndex = selectedIndex;
                Program.sqlConnection.Close();
            }
            else
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Выберите категорию продуктов.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
        }
    }
}
