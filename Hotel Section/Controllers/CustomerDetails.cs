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
    public partial class CustomerDetails : UserControl
    {
        function fn = new function();
        String query;
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtSearchBy.SelectedIndex==0)
            {
                query = "select customer.cid, customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,room.roomNo,room.roomType,room.bed,room.price from customer inner join room on customer.roomid = room.roomid ";
                getRecord(query);
            }
            else if (txtSearchBy.SelectedIndex == 1)
            {
                query = "select customer.cid, customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,room.roomNo,room.roomType,room.bed,room.price from customer inner join room on customer.roomid = room.roomid where chekout  = 'No' ";
                getRecord(query);

            }
            else if (txtSearchBy.SelectedIndex == 2)
            {
                query = "select customer.cid, customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,room.roomNo,room.roomType,room.bed,room.price from customer inner join room on customer.roomid = room.roomid where chekout  = 'Yes' ";
                getRecord(query);
            }
        }
        private void getRecord(String query)
        {
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
