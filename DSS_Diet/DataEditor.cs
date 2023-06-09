using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DietProject
{
    public partial class DataEditor : Form
    {
        public DataEditor()
        {
            InitializeComponent();
        }

        private void KEChoiceButton_Click(object sender, EventArgs e)
        {
            int choice = KLSectionsListBox.SelectedIndex;
            switch (choice)
            {
                case -1:
                    {
                        MessageFormSmall ErrorForm = new MessageFormSmall();
                        ErrorForm.LabelText.Text = "Выберите раздел.";
                        ErrorForm.Text = "Ошибка";
                        ErrorForm.ShowDialog();
                        break;
                    }
                case 0:
                    {
                        Products ProductsNames = new Products();
                        ProductsNames.ShowDialog();
                        break;
                    }
                case 1:
                    {
                        Categories Categories = new Categories();
                        Categories.ShowDialog();
                        break;
                    }
                case 2:
                    {
                        CompatibleCategories CompatibleCategories = new CompatibleCategories();
                        CompatibleCategories.ShowDialog();
                        break;
                    }
                case 3:
                    {
                        ProductsCategories ProductsCategories = new ProductsCategories();
                        ProductsCategories.ShowDialog();
                        break;
                    }
                case 4:
                    {
                        Features Features = new Features();
                        Features.ShowDialog();
                        break;
                    }
                case 5:
                    {
                        PossibleValues PossibleValues = new PossibleValues();
                        PossibleValues.ShowDialog();
                        break;
                    }
                case 6:
                    {
                        FeatureDescription FeatureDescription = new FeatureDescription();
                        FeatureDescription.ShowDialog();
                        break;
                    }
                case 7:
                    {
                        FeatureValue FeatureValue = new FeatureValue();
                        FeatureValue.ShowDialog();
                        break;
                    }
                case 8:
                    {
                        DayNorms DayNorms = new DayNorms();
                        DayNorms.ShowDialog();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
