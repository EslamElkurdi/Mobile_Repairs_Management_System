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

        private void clear()
        {
            PartName.Text = "";
            PartCost.Text = "";
        }

        private void showSpares()
        {
            string Query = "Select * from SparTbl";
            PartsGridView.DataSource = Con.GetData(Query);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PartCost.Text == "" || PartName.Text == "")
                {
                    MessageBox.Show("Missing data");
                }
                else
                {
                    String PName = PartName.Text;
                    int cost = Convert.ToInt32(PartCost.Text);
                    string Query = "insert into  SparTbl values ('{0}',{1})";
                    Query = string.Format(Query, PName, cost);
                    Con.SetData(Query);
                    MessageBox.Show("Part Added...");
                    showSpares();
                    clear();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


        int key = 0;
        private void PartsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartName.Text = PartsGridView.SelectedRows[0].Cells[1].Value.ToString();
            PartCost.Text = PartsGridView.SelectedRows[0].Cells[2].Value.ToString();
            

            if (PartName.Text == "")
            {
                key = 0; 
            }
            else
            {
                key = Convert.ToInt32(PartsGridView.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Missing data");
                }
                else
                {
                    string Query = "Delete from SparTbl where SpCode={0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    MessageBox.Show("Part Deleted...");
                    showSpares();
                    clear();

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PartCost.Text == "" || PartName.Text == "")
                {
                    MessageBox.Show("Missing data");
                }
                else
                {
                 
                    String PName = PartName.Text;
                    int cost = Convert.ToInt32(PartCost.Text);
                    string Query = "Update SparTbl set SpName ='{0}', SpCost ={1} where SpCode={2}";
                    Query = string.Format(Query, PName, cost, key);
                    Con.SetData(Query);
                    MessageBox.Show("Part Updated...");
                    showSpares();
                    clear();

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
