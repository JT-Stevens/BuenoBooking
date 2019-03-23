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

namespace BuenoBooking
{
    public partial class Form1 : Form
    {
        int hotelId;
        int currentRoomId;
        int selectRoom;
        DataTable dtRoom;
        bool AddNewDataMode = false;
        public Form1()
        {
            InitializeComponent();
        }
        private DataTable GetData(string sqlQuery)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);
            DataTable dt = new DataTable();
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        private void LoadComboHotel()
        {
            DataTable dtHotel = GetData("Select * from hotel order by name asc");
            DataRow row = dtHotel.NewRow();
            row["hotelId"] = DBNull.Value;
            row["Name"] = "Select an hotel";
            dtHotel.Rows.InsertAt(row, 0);
            cboHotel.ValueMember = "HotelId";
            cboHotel.DisplayMember = "Name";
            cboHotel.DataSource = dtHotel;
        }
        private void FillForm(int selectedRoomId)
        {
             gpBoxNavButton.Enabled = false;
            if (dtRoom.Rows.Count > 0)
            {
                    currentRoomId = Convert.ToInt32(dtRoom.Rows[selectedRoomId]["roomId"].ToString());
                    cboHotel.SelectedValue = dtRoom.Rows[selectedRoomId]["hotel"].ToString();
                    txtRoomNumber.Text = dtRoom.Rows[selectedRoomId]["roomNumber"].ToString();
                    cboRoomType.Text = dtRoom.Rows[selectedRoomId]["roomType"].ToString();
                    txtRate.Text = dtRoom.Rows[selectedRoomId]["rate"].ToString();
                    txtParkingRate.Text = dtRoom.Rows[selectedRoomId]["parkingRate"].ToString();
                    gpBoxNavButton.Enabled = true;
                    AddNewDataMode = false;
                //btnSave.Text = "Save";
            }
           
        }
        private void ClearForm(object sender,EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox cbo = (ComboBox)ctrl;
                    cbo.SelectedIndex = 0;
                }
                errorProvider1.SetError(ctrl, "");
            }
            //AddNewDataMode = false;
            //btnAddNew.Text = "Add New";
            //gpBoxNavButton.Enabled = true;
            cboHotel.Focus();

        }
        private void ResetForm()
        {
            FillForm(0);

        }
        private bool IsValidEntry(object sender, EventArgs e)
        {
            bool isValid = true;
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is TextBox)
                {
                    if (ctrl.Text == string.Empty)
                    {
                        errorProvider1.SetError(ctrl, "This field is required");
                        isValid = false;
                    }
                    else
                    {
                        errorProvider1.SetError(ctrl, "");
                    }
                }
                else if(ctrl is ComboBox)
                {
                    ComboBox cbo = (ComboBox)ctrl;
                    if(cbo.SelectedIndex==0)
                    {
                        errorProvider1.SetError(ctrl, "Please select an item in the list");
                        isValid = false;
                    }
                    else
                    {
                        errorProvider1.SetError(ctrl, "");
                    }
                }

            }
            return isValid;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboRoomType.Items.Add("Select a room type");
            cboRoomType.Items.Add("Penthouse suite");
            cboRoomType.Items.Add("king");
            cboRoomType.Items.Add("2 queen");
            cboRoomType.Items.Add("2 double");
            cboRoomType.Items.Add("queen");
            cboRoomType.Items.Add("double");
            cboRoomType.SelectedIndex = 0;
            dtRoom = GetData("select * from room order by roomNumber asc");
            LoadComboHotel();
            FillForm(0);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if(IsValidEntry(sender, e))
            {
                string roomNumber = SqlFix(txtRoomNumber.Text);
                string roomType = SqlFix(cboRoomType.Text);
                Decimal rate = Convert.ToDecimal(txtRate.Text);
                Decimal parkingRate = Convert.ToDecimal(txtParkingRate.Text);
                hotelId =Convert.ToInt32(cboHotel.SelectedValue) ;
                try
                {
                    string sqlQuery = "";
                if (AddNewDataMode)
                {
                    sqlQuery = string.Format("insert into room (roomNumber,roomtype,rate,parkingRate,Hotel)values('{0}','{1}',{2},{3},{4})", roomNumber, roomType, rate, parkingRate, hotelId);
                }
                else
                {
                    sqlQuery = string.Format("update room set roomNumber='{0}',roomtype='{1}',rate={2},parkingRate={3},Hotel={4} where roomId={5}", roomNumber, roomType, rate, parkingRate, hotelId, currentRoomId);
                }
                if (SendData(sqlQuery) > 0)
                    {
                        MessageBox.Show("Data saved successfully.");
                        ClearForm(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("An error occured while saving the data.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }
        private int SendData(string sqlStmt)
        {
            int numRecordsAffected = 0;
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sqlStmt, conn);
                conn.Open();
                numRecordsAffected = cmd.ExecuteNonQuery();
                conn.Close();
            }

            return numRecordsAffected;
        }

        private string SqlFix(string str)
        {
            return str.Replace("'", "''");
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm(sender, e);
        }

        private void cboHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNewDataMode = (!AddNewDataMode);
            btnAddNewMode.Text = "&Add new";
            gpBoxNavButton.Enabled = true;
            if (AddNewDataMode)
            {
                ClearForm(sender, e);
                btnAddNewMode.Text = "&Update";
                gpBoxNavButton.Enabled = false;
               
            }

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
             selectRoom = 0;
             FillForm(selectRoom);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            selectRoom = dtRoom.Rows.Count-1;
            FillForm(selectRoom);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (selectRoom < dtRoom.Rows.Count-1)
            {
                selectRoom = selectRoom + 1;
                FillForm(selectRoom);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (selectRoom > 0)
            {
                selectRoom = selectRoom - 1;
                FillForm(selectRoom);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SendData("delete from room where roomId=" + currentRoomId) > 0)
            {
                MessageBox.Show("Data deleted successfully.");
                ClearForm(sender, e);
                dtRoom = GetData("select * from room order by roomNumber asc");
            }
            else
            {
                MessageBox.Show("An error occured while saving the data.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string str = RandomString(3, false);
            //label2.Text = str;
            //label2.Text = Convert.ToInt32("0000000000010002").ToString();

         //  label2.Text = GuestIdGenerator("HBV0000123");

            label2.Text = GuestIdGenerator();
        }
        private string GuestIdGenerator()
        {

          DataTable dt = GetData("SELECT IDENT_CURRENT('hotel')");
          string  lastInsertedUid = dt.Rows[0][0].ToString();

            if (lastInsertedUid == ""|| lastInsertedUid.Length<10)
            {
                lastInsertedUid = "AAA00000000";
            }
            string lastGuestStringID = lastInsertedUid.Substring(0, 3);
            int lastGuestNumberId = Convert.ToInt32(lastInsertedUid.Substring(3, 7));
            if(lastGuestNumberId==9999999)
            {
                lastGuestNumberId = 0;
                lastGuestStringID = GuestStringID(lastGuestStringID);
            }
            string newGuestId = (lastGuestNumberId + 1).ToString();
            while(newGuestId.Length <7)
            {
                newGuestId = '0' + newGuestId;
            }
            newGuestId = lastGuestStringID + newGuestId;
            return newGuestId.ToUpper();
        }
        private string GuestStringID(string s)
        {
            if (s == string.Empty)
            {
                s = "aaa";
            }
            s = s.ToLower();
            char lastChar = s[s.Length - 1];
            string fragment = s.Substring(0, s.Length - 1);
            if (lastChar < 'z')
            {
                ++lastChar;
                return fragment + lastChar;
            }
            return GuestStringID(fragment) + 'a';
        }
        //public string RandomString(int size, bool lowerCase)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    Random random = new Random();
        //    char ch;
        //    for (int i = 0; i < size; i++)
        //    {
        //        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        //        builder.Append(ch);
        //    }
        //    if (lowerCase)
        //        return builder.ToString().ToLower();
        //    return builder.ToString();
        //}


        //private string GuestStringID(string s)
        //{
        //    if (s == string.Empty)
        //    {
        //        s = "aaa";
        //    }
        //    s = s.ToLower();
        //    char lastChar = s[s.Length - 1];
        //    string fragment = s.Substring(0, s.Length - 1);
        //    if (lastChar < 'z')
        //    {
        //        ++lastChar;
        //        return fragment + lastChar;
        //    }
        //    return GuestStringID(fragment) + 'a';
        //}



    }
}
