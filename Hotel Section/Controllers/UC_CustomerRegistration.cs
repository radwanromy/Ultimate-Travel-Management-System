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
    public partial class UC_CustomerRegistration : UserControl
    {
        function fn = new function();
        String query;
        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }
        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while(sdr.Read())
            {
                for(int i=0; i<sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }
        

        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
            query = "select roomNo from room where bed = '" + txtBed.Text + "' and roomType ='" + txtRoom.Text + "'and location ='" + txtLocation.Text + "' and quality ='" + txtQuality.Text + "' and booked = 'NO' ";
            setComboBox(query, txtRoomNo);
        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
          // txtPrice.Items.Clear();
        }
        int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select price,roomid from room where roomNo = '" + txtRoomNo.Text + "' ";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid =int.Parse( ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnAlloteRoom_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtContact.Text != "" && txtNationality.Text != "" && txtGender.Text != "" && txtDob.Text != "" && txtIdProof.Text != "" && txtAddress.Text != "" && txtCheckIn.Text != "" && txtPrice.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                String national = txtNationality.Text;
                String gender = txtGender.Text;
                String dob = txtDob.Text;
                String idproof = txtIdProof.Text;
                String address = txtAddress.Text;
                String checkin = txtCheckIn.Text;
                //String booked = txtBooked.Text;


                query = " insert into customer (cname, mobile,nationality,gender,dob,idproof,addres,checkin,roomid) values ('" + name+"',"+mobile+",'"+national+"','"+gender+"','"+dob+"','"+idproof+"','"+address+"','"+checkin+"',"+rid+ ") update room SET booked = 'YES'  WHERE roomNo = '" + txtRoomNo.Text + "'  ";
                //query = "insert into rooms booked value 'YES'";
                fn.setData(query, "Room No "+ txtRoomNo.Text +" Allocation Successful.");
                /* UPDATE rooms SET booked = 'YES'  WHERE roomNo = '" + txtRoomNo.Text +"' */
                clearAll();
            }
            else
            {
                MessageBox.Show("All Fields Are Madetory. ", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void clearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtDob.ResetText();
            txtIdProof.Clear();
            txtAddress.Clear();
            txtCheckIn.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_CustomerRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
