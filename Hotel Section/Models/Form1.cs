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
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "select username , pass from employee where username = '"+txtUsername.Text+"' and pass ='"+txtPassword.Text+"' ";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count !=0)
            {
                btnForgetPassword.Visible = false;
                labelError.Visible = false;
                Dashboard das = new Dashboard();
                this.Hide();
                das.Show();
            }
            else
            {
                btnForgetPassword.Visible = true;
                labelError.Visible = true;
                txtPassword.Clear();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            guna2DataGridView1.Visible = true;
            setEmployee(guna2DataGridView1);

            /*
            query = "select username from employee where username = '" + txtUsername.Text + "'  ";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                btnForgetPassword.Visible = false;
                labelError.Visible = false;
                
            }
            else
            {
                btnForgetPassword.Visible = true;
                labelError.Visible = true;
                txtPassword.Clear();
            } */
        }
        public void setEmployee(DataGridView data)
        {
            query = "select pass from employee where username = '" + txtUsername.Text + "' ";
            DataSet dss = fn.getData(query);
            data.DataSource = dss.Tables[0];
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }
    }
}
