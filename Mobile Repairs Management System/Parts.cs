using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Repairs_Management_System
{
    public partial class Parts : Form
    {
        Functions Con;
        public Parts()
        {
            InitializeComponent();
            Con = new Functions();
            showSpares();
        }

        private void showSpares()
        {
            string Query = "Select * from SparTbl";
            PartsGridView.DataSource = Con.GetData(Query);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
