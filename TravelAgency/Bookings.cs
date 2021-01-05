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
using System.Collections;


namespace TravelAgency
{
    public partial class Bookings : Form
    {
        SqlCommand cmd;
        SqlConnection conn = Database.ConnectDB();

        public Bookings()
        {
            InitializeComponent();
            DisplayBookings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string query = "UPDATE Bookings SET Confirmation = 1 WHERE Name=@name";
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully!");
                conn.Close();
                DisplayBookings();
            }

            else
                MessageBox.Show("Please enter the Customer's name to confirm booking");

        }


        private void DisplayBookings()
        {
            var conn = Database.ConnectDB();
            conn.Open();
            DataTable dt = new DataTable();
            var sda = new SqlDataAdapter("SELECT * FROM Bookings", conn);
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var conn = Database.ConnectDB();
            conn.Open();
            DataTable dt = new DataTable();
            var sda = new SqlDataAdapter("SELECT * FROM Bookings WHERE Confirmation = 1", conn);
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var conn = Database.ConnectDB();
            conn.Open();
            DataTable dt = new DataTable();
            var sda = new SqlDataAdapter("SELECT * FROM Bookings", conn);
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgencyDashboard r = new AgencyDashboard();
            r.ShowDialog();
        }
    }
}
