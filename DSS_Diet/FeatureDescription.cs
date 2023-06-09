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
    public partial class FeatureDescription : Form
    {
        private SqlDataAdapter adapter;
        private DataTable ProductsNamesTable = new DataTable();
        private DataTable FeaturesTable = new DataTable();
        private DataTable SelectedFeaturesTable = new DataTable();
        private List<int> ProductsNamesIdList = new List<int>();
        private List<string> FeaturesList = new List<string>();
        private List<string> leftList = new List<string>();
        private List<string> rightList = new List<string>();

        public FeatureDescription()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter("SELECT * FROM ProductsNames", Program.sqlConnection);
            adapter.Fill(ProductsNamesTable);
            ProductsNamesIdList = ProductsNamesTable.AsEnumerable().Select(n => n.Field<int>(0)).ToList();
            Program.sqlConnection.Open();
            SqlCommand countFeatures = new SqlCommand("SELECT COUNT(*) FROM Features;", Program.sqlConnection);
            int resCountFeatures = (int)countFeatures.ExecuteScalar();
            if (resCountFeatures != 0)
            {
                SqlCommand countPriceFeature = new SqlCommand("SELECT COUNT(*) FROM FeatureDescriptions WHERE FeatureId = 1;", Program.sqlConnection);
                int resCountPriceFeature = (int)countPriceFeature.ExecuteScalar();
                if (resCountPriceFeature != ProductsNamesIdList.Count)
                {
                    foreach (var productId in ProductsNamesIdList)
                    {
                        SqlCommand hasPriceFeature = new SqlCommand("SELECT COUNT(*) FROM FeatureDescriptions WHERE ProductId = " + productId + ";", Program.sqlConnection);
                        int resHasPriceFeature = (int)hasPriceFeature.ExecuteScalar();
                        if (resHasPriceFeature == 0)
                        {
                            SqlCommand initPriceFeature = new SqlCommand("INSERT INTO FeatureDescriptions VALUES (" + productId + ", 1);", Program.sqlConnection);
                            initPriceFeature.ExecuteNonQuery();
                        }
                    }
                }
            }
            Program.sqlConnection.Close();
            adapter = new SqlDataAdapter("SELECT * FROM Features", Program.sqlConnection);
            adapter.Fill(FeaturesTable);
            FeaturesList = FeaturesTable.AsEnumerable().Select(n => n.Field<string>(1)).ToList();
            FDProductsComboBox.DataSource = ProductsNamesTable;
            FDProductsComboBox.DisplayMember = "Name";
            FDProductsComboBox.ValueMember = "Id";
        }

        private void FDProductsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FDProductsComboBox.SelectedIndex != -1)
            {
                FDFeaturesListBox.Items.Clear();
                FDSelectedFeaturesListBox.Items.Clear();
                DataRowView item = (DataRowView)FDProductsComboBox.SelectedItem;
                int selectedProductId = (int)item.Row[0];
                leftList = new List<string>(FeaturesList);
                SelectedFeaturesTable = new DataTable();
                adapter = new SqlDataAdapter("SELECT Name FROM Features JOIN FeatureDescriptions ON Features.Id = FeatureDescriptions.FeatureId WHERE ProductId = " + selectedProductId + ";", Program.sqlConnection);
                adapter.Fill(SelectedFeaturesTable);
                rightList = SelectedFeaturesTable.AsEnumerable().Select(n => n.Field<string>(0)).ToList();
                leftList = leftList.Except(rightList).ToList();
                foreach (var itemLeft in leftList)
                {
                    FDFeaturesListBox.Items.Add(itemLeft);
                }
                foreach (var itemRight in rightList)
                {
                    FDSelectedFeaturesListBox.Items.Add(itemRight);
                }
            }
        }

        private void MoveSelectedItems(ListBox lstFrom, ListBox lstTo)
        {
            bool priceUnselectedFlag = false;
            while (lstFrom.SelectedItems.Count > 0)
            {
                string item = (string)lstFrom.SelectedItems[0];
                lstTo.Items.Add(item);
                lstFrom.Items.Remove(item);
                if (item == "стоимость за 1 кг продукта")
                {
                    priceUnselectedFlag = true;
                }
            }
            if (priceUnselectedFlag == true)
            {
                lstTo.Items.Remove("стоимость за 1 кг продукта");
                lstFrom.Items.Add("стоимость за 1 кг продукта");
            }
        }

        private void FDSelectButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(FDFeaturesListBox, FDSelectedFeaturesListBox);
        }

        private void FDUnselectButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(FDSelectedFeaturesListBox, FDFeaturesListBox);
        }

        private void FDSaveButton_Click(object sender, EventArgs e)
        {
            if (FDProductsComboBox.SelectedIndex != -1)
            {
                Program.sqlConnection.Open();
                DataRowView item = (DataRowView)FDProductsComboBox.SelectedItem;
                int selectedProductId = (int)item.Row[0];
                SqlCommand deleteOldRecords = new SqlCommand("DELETE FROM FeatureDescriptions WHERE ProductId = " + selectedProductId + ";", Program.sqlConnection);
                deleteOldRecords.ExecuteNonQuery();
                foreach (var itemToAdd in FDSelectedFeaturesListBox.Items)
                {
                    SqlCommand getFeatId = new SqlCommand("SELECT Id FROM Features WHERE Name = N'" + itemToAdd + "';", Program.sqlConnection);
                    int featId = (int)getFeatId.ExecuteScalar();
                    SqlCommand insertNewRecord = new SqlCommand("INSERT INTO FeatureDescriptions VALUES (" + selectedProductId + ", " + featId + ");", Program.sqlConnection);
                    insertNewRecord.ExecuteNonQuery();
                }
                int selectedIndex = FDProductsComboBox.SelectedIndex;
                FDProductsComboBox.SelectedIndex = -1;
                FDProductsComboBox.SelectedIndex = selectedIndex;
                Program.sqlConnection.Close();
            }
            else
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Выберите название продукта.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
        }
    }
}
