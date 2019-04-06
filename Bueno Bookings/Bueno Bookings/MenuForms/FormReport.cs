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

namespace Bueno_Bookings
{
    public partial class FormReport : Form
    {
        MainMenuForm parentForm;

        string preferredStatus = "";
        string searchHotel = "";

        public FormReport(MainMenuForm p)
        {
            parentForm = p;
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            cboPreferredStatus.Items.Add("Select a status");
            cboPreferredStatus.Items.Add("Guests with Preferred Status");
            cboPreferredStatus.Items.Add("Guests without Preferred Status");
            cboPreferredStatus.SelectedIndex = 0;

            cboReportType.Items.Add("Bookings Report");
            cboReportType.Items.Add("Guest Report");
            cboReportType.SelectedIndex = 0;

            if (parentForm.formType == "Bookings Report")
            {
                cboReportType.SelectedItem = "Bookings Report";
            }
            else if (parentForm.formType == "Guest Report")
            {
                cboReportType.SelectedItem = "Guest Report";
            }
            cboReportType_SelectionChangeCommitted(sender, e);
            LoadComboHotel();
        }

        private void LoadComboHotel()
        {
            string sqlQuery = "SELECT HotelId, Name FROM hotel ORDER BY Name";
            DataTable dt = GetSendData.GetData(sqlQuery);
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
            " FROM Booking INNER JOIN Room ON Booking.RoomID = Room.RoomID INNER JOIN Guest ON Guest.GuestID = Booking.GuestID INNER JOIN Hotel ON Hotel.HotelID = Room.Hotel WHERE startDate >='{0}' and endDate <='{1}' {2} ORDER BY StartDate, FirstName ", dtpStartDate.Value.ToShortDateString(), dtPEndDate.Value.ToShortDateString(), preferredStatus);
            DataTable dtBooking = new DataTable();
            dtBooking = GetSendData.GetData(sqlQuery);
            dgvReport.DataSource = dtBooking;
        }
        private void DisplayGuests()
        {
            grpBox.Text = "";
            dgvReport.DataSource = null;
            grpBox.Text = " Guests's total booking" + " " + cboHotel.Text;
            string sqlQuery = String.Format("SELECT guest.guestId, FirstName, LastName, total FROM Guest INNER JOIN " +
           "(SELECT GuestID, RoomId, SUM(TotalCharge) AS total FROM booking GROUP BY GuestID, RoomId) guestBooking ON guestBooking.GuestID = Guest.GuestID INNER JOIN Room ON Room.RoomID = guestBooking.RoomID {0}", searchHotel);
            DataTable dtGuest = new DataTable();
            dtGuest = GetSendData.GetData(sqlQuery);
            dgvReport.DataSource = dtGuest;
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
            if (cboReportType.Text == "Bookings Report")
            {
                DisplayBookings();
            }
            else if (cboReportType.Text == "Guest Report")
            {
                DisplayGuests();
            }
        }

        private void cboHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHotel.SelectedIndex > 0)
            {
                searchHotel = " where hotel = " + Convert.ToInt32(cboHotel.SelectedValue);
            }
        }

        private void cboReportType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboReportType.Text == "Bookings Report")
            {
                grpBooking.Visible = true;
                grpGuest.Visible = false;
            }
            else if (cboReportType.Text == "Guest Report")
            {
                grpBooking.Visible = false;
                grpGuest.Visible = true;
            }
        }
    }
}
