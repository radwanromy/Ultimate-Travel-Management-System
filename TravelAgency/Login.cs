using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TravelAgency
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                var conn = Database.ConnectDB();
                conn.Open();
                string query = "SELECT * FROM Agencies WHERE Username = " + "'" + textBox1.Text + "'" + "AND Password = " + "'" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login sucess Welcome to Homepage");
                    this.Hide();
                    AgencyDashboard r = new AgencyDashboard();
                    r.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username and password combination");
                }
                conn.Close();
            }
            else
                MessageBox.Show("Please enter Username & Password");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register r = new Register();
            r.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotPW r = new ForgotPW();
            r.ShowDialog();
        }
    }
}
