using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bueno_Bookings
{
    public partial class Booking : Form
    {
        MainMenuForm parentForm;
        DataTable dtBooking;
        DataTable dtGuest;
        DataTable dtHotel;
        DataTable dtRoom;

        int currentRecord = 0;
        bool addMode;

        public Booking(MainMenuForm p)
        {
            parentForm = p;
            InitializeComponent();
        }

        #region Load Form
        private void Booking_Load(object sender, EventArgs e)
        {
            LoadBookings();
            try
            {
                ToggleControls(true);

                //Hotel ComboBox
                dtHotel = GetSendData.GetData("SELECT * FROM Hotel");
                DataRow rowHotel = dtHotel.NewRow();
                rowHotel["hotelId"] = DBNull.Value;
                rowHotel["Name"] = "Select an hotel";
                dtHotel.Rows.InsertAt(rowHotel, 0);

                cboHotel.DisplayMember = "Name";
                cboHotel.ValueMember = "HotelId";
                cboHotel.DataSource = dtHotel;

                cboHotel.SelectedIndex = currentRecord;

                //GuestId ComboBox
                //dtGuest = GetSendData.GetData($"SELECT Guest.GuestId, FirstName, LastName, Phone FROM Guest INNER JOIN booking ON guest.GuestID = Booking.GuestID  WHERE BookingId = {dtBooking.Rows[currentRecord]["BookingID"]}");
                dtGuest = GetSendData.GetData($"SELECT GuestId, FirstName, LastName, Phone FROM Guest");

                cboGuestId.DisplayMember = "GuestID";
                cboGuestId.ValueMember = "GuestID";
                cboGuestId.DataSource = dtGuest;

                cboGuestId.SelectedIndex = currentRecord;

                //Room Comboboxes
                dtRoom = GetSendData.GetData($"SELECT * FROM Room;");

                cboRoomNumber.DisplayMember = "RoomNumber";
                cboRoomNumber.ValueMember = "RoomId";
                cboRoomNumber.DataSource = dtRoom;

                cboRoomNumber.SelectedIndex = currentRecord;

                //cboRoomType
                cboRoomType.DisplayMember = "RoomType";
                cboRoomType.ValueMember = "RoomId";
                cboRoomType.DataSource = dtRoom;

                cboRoomType.SelectedIndex = currentRecord;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            PopulateField();
        }

        private void LoadBookings()
        {
            try
            {
                dtBooking = GetSendData.GetData("SELECT * FROM Booking");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void PopulateField()
        {
            if (dtBooking.Rows.Count > 0)
            {
                //This messy code is here so we can have the index of the current Hotel then Guest to make sure the records are matched.
                int HotelCurrentIndex = dtRoom.Rows.IndexOf(dtRoom.Select($"RoomId = {dtBooking.Rows[currentRecord]["RoomID"]}")[0]) + 1;
                int GuestCurrentIndex = dtGuest.Rows.IndexOf(dtGuest.Select($"GuestID = '{dtBooking.Rows[currentRecord]["GuestID"]}'")[0]);

                dtpStartDate.Value = Convert.ToDateTime(dtBooking.Rows[currentRecord]["StartDate"]);
                dtpEndDate.Value = Convert.ToDateTime(dtBooking.Rows[currentRecord]["EndDate"]);

                cboHotel.SelectedValue = dtHotel.Rows[HotelCurrentIndex]["HotelID"];

                cboRoomType.SelectedValue = dtBooking.Rows[currentRecord]["RoomID"];
                cboRoomNumber.SelectedValue = dtBooking.Rows[currentRecord]["RoomID"];

                cboGuestId.SelectedValue = dtBooking.Rows[currentRecord]["GuestID"];


                txtFirstName.Text = dtGuest.Rows[GuestCurrentIndex]["FirstName"].ToString();
                txtLastName.Text = dtGuest.Rows[GuestCurrentIndex]["LastName"].ToString();
                txtPhone.Text = dtGuest.Rows[GuestCurrentIndex]["Phone"].ToString();

                lblTotalCharges.Text = dtBooking.Rows[currentRecord]["TotalCharge"].ToString();
            }
        }

        private void ToggleControls(bool state)
        {
            btnAdd.Enabled = state;
            btnDelete.Enabled = state;
            btnSave.Enabled = !state;
            btnCancel.Enabled = !state;
            grpNav.Enabled = state;
        }

        #endregion

        #region Navagation

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (currentRecord != 0)
            {
                currentRecord = 0;
                PopulateField();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentRecord != 0)
            {
                currentRecord--;
                PopulateField();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentRecord < dtBooking.Rows.Count - 1)
            {
                currentRecord++;
                PopulateField();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (currentRecord != dtBooking.Rows.Count - 1)
            {
                currentRecord = dtBooking.Rows.Count - 1;
                PopulateField();
            }
        }
        #endregion

    }
}
