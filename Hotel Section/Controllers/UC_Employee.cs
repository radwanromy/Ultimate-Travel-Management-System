using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.All_User_Control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        String query;
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }
        public void getMaxID()
        {
            query = " select max(eid) from employee";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labeltoSet.Text = (num + 1).ToString();
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtUsername.Text != "" && txtPassword.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String username = txtUsername.Text;
                String pass = txtPassword.Text;

                query = " insert into employee (ename, mobile,gender,emailid,username,pass) values ('" + name + "'," + mobile + ",'" + gender + "','" +email + "','" + username + "','" +pass + "') ";
               
                fn.setData(query, "Employee Register");
                
                clearAll();
                getMaxID();
            }
            
            else
            {
                MessageBox.Show("All Fields Are Madetory. ", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtGender.SelectedIndex = -1;
            txtMobile.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex==1)
            {
                setEmployee(guna2DataGridView1);
            }
            else if(tabControl1.SelectedIndex == 2)
            {
                setEmployee(guna2DataGridView3);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                if (MessageBox.Show("Are You Sure?", "Confirmation..!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid = " + txtId.Text + "";
                    fn.setData(query, "Record Deleted.");
                    tabControl1_SelectedIndexChanged(this, null);
                }

            }

        }
        public void  setEmployee(DataGridView data)
        {
            query = "select * from employee";
            DataSet ds = fn.getData(query);
           data.DataSource = ds.Tables[0];
        }

        private void tabControl1_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
