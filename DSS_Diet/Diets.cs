using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    public partial class Diets : Form
    {
        private SqlDataAdapter adapter;
        private DataTable ProductsTable = new DataTable();
        private DataTable CategoriesTable = new DataTable();

        public Diets()
        {
            InitializeComponent();
        }

        private void DSearchButton_Click(object sender, EventArgs e)
        {

        }

        private void DCancelButton_Click(object sender, EventArgs e)
        {

        }

        private void PDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {

        }
    }
}