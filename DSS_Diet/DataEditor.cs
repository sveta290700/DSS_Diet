using System;
using System.Windows.Forms;

namespace DietProject
{
    public partial class DataEditor : Form
    {
        public DataEditor()
        {
            InitializeComponent();
        }

        private void DEChoiceButton_Click(object sender, EventArgs e)
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
                        Categories Categories = new Categories();
                        Categories.ShowDialog();
                        break;
                    }
                case 1:
                    {
                        CompatibleCategories CompatibleCategories = new CompatibleCategories();
                        CompatibleCategories.ShowDialog();
                        break;
                    }
                case 2:
                    {
                        Products Products = new Products();
                        Products.ShowDialog();
                        break;
                    }
                case 3:
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
