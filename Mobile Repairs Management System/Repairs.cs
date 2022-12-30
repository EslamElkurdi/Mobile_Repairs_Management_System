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
    public partial class Repairs : Form
    {
        Functions Con;
        public Repairs()
        {
            InitializeComponent();
            Con = new Functions();
            showRepairs();
            GetCustomer();
            
        }

        private void GetCustomer()
        {
            string Query = "Select * from CustomerTbl";
            CustCb.DisplayMember = Con.GetData(Query).Columns["CustName"].ToString();
            CustCb.ValueMember = Con.GetData(Query).Columns["CustCode"].ToString();
            CustCb.DataSource = Con.GetData(Query);
        }

        private void GetSpare()
        {
            string Query = "Select * from SparTbl";
            SpareCb.DisplayMember = Con.GetData(Query).Columns["SpName"].ToString();
            SpareCb.ValueMember = Con.GetData(Query).Columns["SpCode"].ToString();
            SpareCb.DataSource = Con.GetData(Query);
        }

       

        private void showRepairs()
        {
            string Query = "Select * from RepairTbl";
            RepairDataGridView.DataSource = Con.GetData(Query);
        }

        private void clear()
        {
            CustCb.SelectedIndex = -1;
            PhoneTb.Text = "";
            DeviceNameTb.Text = "";
            DeviceModelTb.Text = "";
            ProblemTb.Text = "";
            SpareCb.SelectedIndex = -1;
            TotalCostTb.Text = "";
            spcostTb.Text = "";

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        //DeviceNameTb.Text = "";
        //DeviceModelTb.Text = "";
        //    ProblemTb.Text = "";
        //    SpareCb.SelectedIndex = -1;
        //    TotalCostTb.Text = "";
        //    spcostTb.Text = "";

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustCb.SelectedIndex == -1 || PhoneTb.Text == "" || DeviceNameTb.Text == "" || DeviceModelTb.Text == "" || ProblemTb.Text == "" || SpareCb.SelectedIndex == -1 || TotalCostTb.Text == "" || spcostTb.Text == "")
                {
                    MessageBox.Show("Missing data");
                }
                else
                {
                    String RDate = RepDate.Value.Date.ToString();
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    String CPhone = PhoneTb.Text;
                    String DeviceName = DeviceNameTb.Text;
                    String DeviceModel = DeviceModelTb.Text;
                    String Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalCostTb.Text);

                    string Query = "insert into  RepairTbl values ('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})";
                    Query = string.Format(Query, RDate, Customer, CPhone, DeviceName, DeviceModel, Problem, Spare, Total);
                    Con.SetData(Query);
                    MessageBox.Show("Repairs Added...");
                    showRepairs();
                    clear();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
