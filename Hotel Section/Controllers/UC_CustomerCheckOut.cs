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
    public partial class UC_CustomerCheckOut : UserControl
    {
        function fn = new function();
        String query;
        int id;
        public UC_CustomerCheckOut()
        {
            InitializeComponent();
        }

        

        private void UC_CustomerCheckOut_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,room.roomNo,room.roomType,room.bed,room.price from customer inner join room on customer.roomid = room.roomid where chekout = 'NO' ";
            DataSet ds = fn.getData(query);
            DataGridView2.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,room.roomNo,room.roomType,room.bed,room.price from customer inner join room on customer.roomid = room.roomid where cname like '"+txtName.Text+"%'and chekout = 'NO' ";
            DataSet ds = fn.getData(query);
            DataGridView2.DataSource = ds.Tables[0];
        }
        
        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(DataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCName.Text = DataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomNo.Text = DataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCName.Text != "")
            {
                if (MessageBox.Show("Are You Sure?", " Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    String cdate = txtCheckOutDate.Text;
                    query = "update customer set chekout = 'YES', checkout='" + cdate + "' where cid = " + id + " update room set booked = 'NO' where roomNo = '" + txtRoomNo.Text + "'";
                    fn.setData(query, "Check Out Successfull.");
                    UC_CustomerCheckOut_Load(this, null);
                    clearALL();
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearALL()
        {
            txtCName.Clear();
            txtName.Clear();
            txtRoomNo.Clear();
            txtCheckOutDate.ResetText();
        }

        private void UC_CustomerCheckOut_Leave(object sender, EventArgs e)
        {
            clearALL();
        }
    }
}
