using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;



namespace TravelAgency
{
    public partial class AgencyDashboard : Form
    {
        SqlCommand cmd;
        SqlConnection conn = Database.ConnectDB();

        public AgencyDashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bookings b = new Bookings();
            b.ShowDialog();
        }

        private void createP_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&
                textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" &&
                textBox7.Text != "")
            {
                conn.Open();
                string query = "INSERT INTO Packages (Name,Transport,Meals,Price,Location,Hotel,Room) values" +
                    " ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"
                    + textBox6.Text + "','" + textBox7.Text + "')";
                cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Value Inserted");
                }
                else
                    MessageBox.Show("Value Not Inserted");
                ClearData();
                DisplayPackages();
                conn.Close();

            }

            else
                MessageBox.Show("Please provide all the data required to create a package");

            
        }

        private void showP_Click(object sender, EventArgs e)
        {
            DisplayPackages();
        }

        private void DisplayPackages()
        {
            var conn = Database.ConnectDB();
            conn.Open();
            DataTable dt = new DataTable();
            var sda = new SqlDataAdapter("SELECT * FROM Packages", conn);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void deleteP_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            if (Name != "")
            {
                string query = "DELETE Packages WHERE Name = @Name";
                cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Deletion Successful!");
                DisplayPackages();
                ClearData();
            }
            else
                MessageBox.Show("Please enter the package name you want to delete");
            
        }

        private void updateP_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {              
                string query = "UPDATE Packages SET Transport=@transport, Meals=@meals, Price=@price, " +
                                 "Location=@location, Hotel=@hotel, Room=@room WHERE Name=@id";
                conn.Open();                
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@transport", textBox2.Text);
                cmd.Parameters.AddWithValue("@Meals", textBox3.Text);
                cmd.Parameters.AddWithValue("@Price", textBox4.Text);
                cmd.Parameters.AddWithValue("@Location", textBox5.Text);
                cmd.Parameters.AddWithValue("@Hotel", textBox6.Text);
                cmd.Parameters.AddWithValue("@Room", textBox7.Text); 

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully!");
                conn.Close();
                DisplayPackages();
                ClearData();
            }
            else
                MessageBox.Show("Please Enter the Name of Package to update");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
            }

        }


    }
}
