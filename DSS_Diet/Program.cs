using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietProject
{
    static class Program
    {
        public static SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-0E3AC9U\SQLEXPRESS;Initial Catalog=DietDB;Integrated Security=True");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
    }
}
