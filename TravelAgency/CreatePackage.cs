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
    public partial class CreatePackage : Form
    {
        public CreatePackage()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&
                textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" &&
                textBox7.Text != "")
            {
                var conn = Database.ConnectDB();
                conn.Open();
                string query = "insert into Packages (Name,Transport,Meals,Price,Location,Hotel,Room) values" +
                    " ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"
                    + textBox6.Text + "','" + textBox7.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Value Inserted");
                }
                else
                    MessageBox.Show("Value Not Inserted");

            }

            else
                MessageBox.Show("Please provide all the data required to create a package");
        }
    }
}
