﻿using System;
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
    public partial class Customers : Form
    {

        Functions Con;
        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
            showCustomers();

        }

        private void showCustomers() 
        {
            string Query = "Select * from CustomerTbl";
            CustomersGridView.DataSource = Con.GetData(Query);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddressTb.Text == "")
                {
                    MessageBox.Show("Missing data");
                }
                else
                {
                    String CName = CustNameTb.Text;
                    String CPhone = CustPhoneTb.Text;
                    String CAdd = CustAddressTb.Text;
                    string Query = "insert into  CustomerTbl values ('{0}','{1}','{2}')";
                    Query = string.Format(Query, CName, CPhone, CAdd);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Added...");
                    showCustomers();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int key = 0;
        private void CustomersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustNameTb.Text = CustomersGridView.SelectedRows[0].Cells[1].Value.ToString();
            CustPhoneTb.Text = CustomersGridView.SelectedRows[0].Cells[2].Value.ToString();
            CustAddressTb.Text = CustomersGridView.SelectedRows[0].Cells[3].Value.ToString();
            
            if (CustNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CustomersGridView.SelectedRows[0].Cells[0].Value.ToString());
            }


        }
    }
}
