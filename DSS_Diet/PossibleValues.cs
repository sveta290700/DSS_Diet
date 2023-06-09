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
    public partial class PossibleValues : Form
    {
        private SqlDataAdapter adapter;
        private DataTable FeaturesTable = new DataTable();
        private DataTable FeaturesIdTable = new DataTable();
        private DataTable FeaturesIdTable2 = new DataTable();
        private List<int> FeaturesIdList = new List<int>();
        private List<int> FeaturesIdList2 = new List<int>();

        public PossibleValues()
        {
            InitializeComponent();
            Program.sqlConnection.Open();
            SqlCommand countPrice = new SqlCommand("SELECT COUNT(*) FROM Features WHERE Name = N'стоимость за 1 кг продукта';", Program.sqlConnection);
            int resCountPrice = (int)countPrice.ExecuteScalar();
            if (resCountPrice == 0)
            {
                SqlCommand addPriceFeature = new SqlCommand("INSERT INTO Features VALUES (N'стоимость за 1 кг продукта');", Program.sqlConnection);
                addPriceFeature.ExecuteNonQuery();
            }
            adapter = new SqlDataAdapter("SELECT Id FROM Features", Program.sqlConnection);
            adapter.Fill(FeaturesIdTable);
            FeaturesIdList = FeaturesIdTable.AsEnumerable().Select(n => n.Field<int>(0)).ToList();
            SqlCommand countPFV = new SqlCommand("SELECT COUNT(*) FROM PossibleFeaturesValues;", Program.sqlConnection);
            int res = (int)countPFV.ExecuteScalar();
            adapter = new SqlDataAdapter("SELECT FeatureId FROM PossibleFeaturesValues", Program.sqlConnection);
            adapter.Fill(FeaturesIdTable2);
            FeaturesIdList2 = FeaturesIdTable2.AsEnumerable().Select(n => n.Field<int>(0)).ToList();
            SqlCommand countFeatures = new SqlCommand("SELECT COUNT(*) FROM Features;", Program.sqlConnection);
            int resAll = (int)countFeatures.ExecuteScalar();
            if (res == 0)
            {
                foreach (var featureId in FeaturesIdList)
                {
                    SqlCommand initPFV = new SqlCommand("INSERT INTO PossibleFeaturesValues VALUES (" + featureId + ", NULL, NULL, NULL, NULL);", Program.sqlConnection);
                    initPFV.ExecuteNonQuery();
                }
            }
            else if (res != resAll)
            {
                foreach (var featureId in FeaturesIdList)
                {
                    if (!FeaturesIdList2.Contains(featureId))
                    {
                        SqlCommand insNew = new SqlCommand("INSERT INTO PossibleFeaturesValues VALUES (" + featureId + ", NULL, NULL, NULL, NULL);", Program.sqlConnection);
                        insNew.ExecuteNonQuery();
                    }
                }
            }
            Program.sqlConnection.Close();
        }

        private void PossibleValues_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM Features", Program.sqlConnection);
            adapter.Fill(FeaturesTable);
            PVFeaturesListBox.DataSource = FeaturesTable;
            PVFeaturesListBox.DisplayMember = "Name";
            PVFeaturesListBox.ValueMember = "Id";
        }

        private void PVSaveButton_Click(object sender, EventArgs e)
        {
            if (PVFromNumericUpDown.Value <= PVToNumericUpDown.Value)
            {
                Program.sqlConnection.Open();
                DataRowView feature = (DataRowView)PVFeaturesListBox.SelectedItem;
                int featureId = (int)feature.Row[0];
                string a = PVFromNumericUpDown.Value.ToString();
                a = a.Replace(',', '.');
                string b = PVToNumericUpDown.Value.ToString();
                b = b.Replace(',', '.');
                SqlCommand addPossibleValues = new SqlCommand("UPDATE PossibleFeaturesValues SET Low = CONVERT(DECIMAL(9, 5), " + a + "), LowIncl = " + Convert.ToByte(PVFromCheckbox.Checked) + ", High = CONVERT(DECIMAL(9, 5), " + b + "), HighIncl = " + Convert.ToByte(PVToCheckbox.Checked) + " WHERE FeatureId = " + featureId + ";", Program.sqlConnection);
                addPossibleValues.ExecuteNonQuery();
                Program.sqlConnection.Close();
                int selectedIndex = PVFeaturesListBox.SelectedIndex;
                PVFeaturesListBox.SelectedIndex = -1;
                PVFeaturesListBox.SelectedIndex = selectedIndex;
            }
            else
            {
                MessageFormSmall ErrorForm = new MessageFormSmall();
                ErrorForm.LabelText.Text = "Нижняя граница интервала не может быть больше верхней.";
                ErrorForm.Text = "Ошибка";
                ErrorForm.ShowDialog();
            }
        }

        private void PVFeaturesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PVFeaturesListBox.SelectedIndex != -1)
            {
                DataRowView feature = (DataRowView)PVFeaturesListBox.SelectedItem;
                string featureName = feature.Row[1].ToString();
                if (featureName == "стоимость за 1 кг продукта")
                {
                    PVSizeFromLabel.Text = "руб";
                    PVSizeToLabel.Text = "руб";
                }
                else
                {
                    PVSizeFromLabel.Text = "кг";
                    PVSizeToLabel.Text = "кг";
                }
                Program.sqlConnection.Open();
                int featId = (int)feature.Row[0];
                SqlCommand getLow = new SqlCommand("SELECT Low FROM PossibleFeaturesValues WHERE FeatureId = " + featId + ";", Program.sqlConnection);
                object getLowRes = getLow.ExecuteScalar();
                decimal low = (decimal)0.00000;
                if (getLowRes != DBNull.Value)
                {
                    low = (decimal)getLowRes;
                }
                SqlCommand getLowIncl = new SqlCommand("SELECT LowIncl FROM PossibleFeaturesValues WHERE FeatureId = " + featId + ";", Program.sqlConnection);
                object getLowInclRes = getLowIncl.ExecuteScalar();
                bool lowIncl = true;
                if (getLowInclRes != DBNull.Value)
                {
                    lowIncl = (bool)getLowInclRes;
                }
                SqlCommand getHigh = new SqlCommand("SELECT High FROM PossibleFeaturesValues WHERE FeatureId = " + featId + ";", Program.sqlConnection);
                object getHighRes = getHigh.ExecuteScalar();
                decimal high = (decimal)0.00000;
                if (getHighRes != DBNull.Value)
                {
                    high = (decimal)getHighRes;
                }
                SqlCommand getHighIncl = new SqlCommand("SELECT HighIncl FROM PossibleFeaturesValues WHERE FeatureId = " + featId + ";", Program.sqlConnection);
                object getHighInclRes = getHighIncl.ExecuteScalar();
                bool highIncl = true;
                if (getHighInclRes != DBNull.Value)
                {
                    highIncl = (bool)getHighInclRes;
                }
                Program.sqlConnection.Close();
                PVFromNumericUpDown.Value = low;
                PVFromCheckbox.Checked = lowIncl;
                PVToNumericUpDown.Value = high;
                PVToCheckbox.Checked = highIncl;
            }
        }
    }
}
