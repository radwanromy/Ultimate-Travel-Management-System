using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency
{
    public partial class ForgotPW : Form
    {
        SqlCommand cmd;
        SqlConnection conn = Database.ConnectDB();
        public ForgotPW()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pw1 = textBox3.Text;
            var pw2 = textBox4.Text;
            //var email = textBox2.Text;
            if (pw1 == pw2)
            {
                string query = "UPDATE Agencies SET Password=@password WHERE Username=@username AND Email=@email";
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);
                cmd.Parameters.AddWithValue("@password", textBox3.Text);
                cmd.Parameters.AddWithValue("@pw2", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully!");
                conn.Close();
            }
            else
                MessageBox.Show("Passwords do not match!");
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
