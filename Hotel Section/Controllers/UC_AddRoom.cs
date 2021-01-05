using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HMS.All_User_Control
{
    public partial class UC_AddRoom : UserControl
    {
        function fn = new function();
        String query;
        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "select * from room";
            DataSet ds= fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if(txtRoomNo.Text!="" && txtType.Text!="" && txtBed.Text!="" && txtPrice.Text != "")
            {
                String location = txtLocation.Text;
                String quality = txtQuality.Text;
                String roomno = txtRoomNo.Text;
                String type = txtType.Text;
                String bed = txtBed.Text;
                String booked = txtBooked.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                query = "insert into room (roomNo,roomType,bed,price, booked, location, quality) values ('" + roomno+"','"+type+"','"+bed+"',"+price+ ", '"+booked+ "' ,'" + location + "','" + quality + "')";
                fn.setData(query, "Room Added.");

                UC_AddRoom_Load(this,null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Fill All Firlds.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clearAll()
        {
            txtRoomNo.Clear();
            txtType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void DataGridView1_Enter(object sender, EventArgs e)
        {

        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
