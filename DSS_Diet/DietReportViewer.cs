using System.Windows.Forms;

namespace DietProject
{
    public partial class DietReportViewer : Form
    {
        int DietID;
        public DietReportViewer(int DietID)
        {
            InitializeComponent();
            this.DietID = DietID;
        }
    }
}
