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
    public partial class FormReport : Form
    {
        string preferredStatus = "";
        string searchHotel = "";
        public FormReport()
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
            string sqlQuery = "Select hotelId, name from hotel order by name";
            DataTable dt = GetData(sqlQuery);
            DataRow row = dt.NewRow();
            row["hotelId"] = DBNull.Value;
            row["name"] = "Choose an hotel";
            dt.Rows.InsertAt(row,0);
            cboHotel.ValueMember = "hotelId";
            cboHotel.DisplayMember= "name";
            cboHotel.DataSource = dt;
        }
        private void DisplayBookings()
        {
            grpBox.Text = "";
            dgvReport.DataSource = null;
            grpBox.Text = " Bookings made from "+ dtpStartDate.Value.ToLongDateString() +" to " + dtPEndDate.Value.ToLongDateString() + " " + cboPreferredStatus.Text;
            string sqlQuery = String.Format("select FirstName, LastName, hotel.Name, RoomNumber, startDate, endDate, requireParking, totalcharge "+
            " from Booking inner join Room on Booking.RoomID = Room.RoomID inner join Guest on Guest.GuestID = Booking.GuestID inner join Hotel on Hotel.HotelID = Room.RoomID where startDate >='{0}' and endDate <='{1}' {2} order by StartDate, FirstName ", dtpStartDate.Value.ToShortDateString(), dtPEndDate.Value.ToShortDateString(), preferredStatus);
            DataTable dtBooking = new DataTable();
            dtBooking = GetData(sqlQuery);
            dgvReport.DataSource = dtBooking;
        }
        private void DisplayGuests()
        {
            //            select guest.guestId,FirstName, LastName,total
            //from guest inner join
            //(select GuestID, sum(TotalCharge) as total from booking group by GuestID)guestBooking on guestBooking.GuestID = Guest.GuestID;
            grpBox.Text = "";
            dgvReport.DataSource = null;
            grpBox.Text = " Guests's total booking" + " " + cboHotel.Text;
            string sqlQuery = String.Format(" select guest.guestId,FirstName, LastName,total from guest inner join " +
           " (select GuestID, RoomId, sum(TotalCharge) as total from booking group by GuestID, RoomId)guestBooking on guestBooking.GuestID = Guest.GuestID inner join Room on Room.RoomID = guestBooking.RoomID {0}", searchHotel);
            DataTable dtGuest = new DataTable();
            dtGuest = GetData(sqlQuery);
            dgvReport.DataSource = dtGuest;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayBookings();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            cboPreferredStatus.Items.Add("Select a status");
            cboPreferredStatus.Items.Add("Guests with Preferred Status");
            cboPreferredStatus.Items.Add("Guests without Preferred Status");
            LoadComboHotel();
        }

        private void cboPreferredStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            preferredStatus = "";
            if (cboPreferredStatus.Text== "Guests with Preferred Status")
            {
                preferredStatus = " and preferred='True' ";
            }
            if (cboPreferredStatus.Text == "Guests without Preferred Status")
            {
                preferredStatus = " and preferred='False' ";
            }
        }

        private void btnDisplayGuests_Click(object sender, EventArgs e)
        {
            DisplayGuests();
        }

        private void cboHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHotel.SelectedIndex > 0)
            {
                searchHotel = " where hotel = " + Convert.ToInt32(cboHotel.SelectedValue);
            }

        }
    }
}
