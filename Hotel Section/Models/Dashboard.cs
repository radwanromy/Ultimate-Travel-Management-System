using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomerRegistration_Click(object sender, EventArgs e)
        {
            movingPanel.Left = btnCustomerRegistration.Left+60;
            uC_CustomerRegistration1.Visible = true;
            uC_CustomerRegistration1.BringToFront();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            movingPanel.Left = btnAddRoom.Left + 1;
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            uC_CustomerCheckOut1.Visible = true;
            uC_CustomerCheckOut1.BringToFront();
            movingPanel.Left = btnCheckOut.Left + 7;
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            customerDetails1.Visible = true;
            customerDetails1.BringToFront();
            movingPanel.Left = btnCustomerDetails.Left + 45;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();
            movingPanel.Left = btnEmployee.Left + 12;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_Employee1.Visible = false;
            customerDetails1.Visible = false;
            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            btnAddRoom.PerformClick();
        }
    }
}
