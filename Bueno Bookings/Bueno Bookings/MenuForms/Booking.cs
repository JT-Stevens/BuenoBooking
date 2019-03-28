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
            try
            {
                ToggleControls(true);

                LoadBookings();
                PopulateField();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void FillHotelDropdown()
        {
            dtHotel = GetSendData.GetData($"SELECT * FROM Hotel");
            DataRow row = dtHotel.NewRow();
            row["hotelId"] = DBNull.Value;
            row["Name"] = "Select an hotel";
            dtHotel.Rows.InsertAt(row, 0);

            cboHotel.DisplayMember = "Name";
            cboHotel.ValueMember = "HotelId";
            cboHotel.DataSource = dtHotel;

            cboHotel.SelectedIndex = currentRecord;
        }

        private void FillGustIdDropdown()
        {
            dtGuest = GetSendData.GetData($"SELECT GuestId, FirstName, LastName, Phone FROM Guest");
            DataRow row = dtGuest.NewRow();
            row["GuestId"] = "No Guest";
            dtGuest.Rows.InsertAt(row, 0);


            cboGuestId.DisplayMember = "GuestID";
            cboGuestId.ValueMember = "GuestID";
            cboGuestId.DataSource = dtGuest;

            cboGuestId.SelectedIndex = currentRecord;
        }

        private void fillRoomNumberDropdown()
        {
            if (cboRoomType.Text == "No Room")
            {
                NoRoomNumber();
                return;
            }

            string sql = string.Empty;

            if (addMode)
            {
                sql = $"SELECT RoomNumber FROM Room LEFT OUTER JOIN Booking " +
                    $"ON Booking.RoomID = Room.RoomID WHERE RoomType = '{cboRoomType.Text}' AND Room.RoomId NOT IN (SELECT RoomID FROM Booking " +
                    $"WHERE StartDate <= '{dtpEndDate.Value.ToShortDateString()}' AND '{dtpStartDate.Value.ToShortDateString()}' <= EndDate);";
            }
            else
            {
                sql = $"SELECT RoomNumber FROM Room LEFT OUTER JOIN Booking " +
                    $"ON Booking.RoomID = Room.RoomID WHERE RoomType = '{cboRoomType.Text}' AND Room.RoomId NOT IN (SELECT RoomID FROM Booking " +
                    $"WHERE StartDate <= '{dtpEndDate.Value.ToShortDateString()}' AND '{dtpStartDate.Value.ToShortDateString()}' <= EndDate) " +
                    $"OR BookingId = {dtBooking.Rows[currentRecord]["BookingId"]};";
            }

            DataTable dtRoomNumDrop = GetSendData.GetData(sql);

            if (dtRoomNumDrop.Rows.Count > 0)
            {
                cboRoomNumber.DisplayMember = "RoomNumber";
                cboRoomNumber.DataSource = dtRoomNumDrop;

                cboRoomNumber.Enabled = true;
            }
            else
            {
                NoRoomNumber();
            }
        }

        private void NoRoomNumber()
        {
            cboRoomNumber.DataSource = null;
            cboRoomNumber.Items.Add("No room");
            cboRoomNumber.SelectedIndex = 0;
            cboRoomNumber.Enabled = false;
        }

        private void fillRoomTypeDropdown()
        {
            if (cboHotel.SelectedValue == DBNull.Value)
            {
                NoRoomType();
                return;
            }

            string sql = string.Empty;
            if (addMode)
            {
                sql = ($"SELECT DISTINCT RoomType FROM Room LEFT OUTER JOIN Booking " +
                    $"ON Booking.RoomID = Room.RoomID WHERE Room.RoomID NOT IN (SELECT RoomID FROM Booking " +
                    $"WHERE StartDate <= '{dtpEndDate.Value.ToShortDateString()}' AND '{dtpStartDate.Value.ToShortDateString()}' <= EndDate) AND Hotel = {cboHotel.SelectedValue};");
            }
            else
            {
                sql = $"SELECT DISTINCT RoomType FROM Room LEFT OUTER JOIN Booking " +
                    $"ON Booking.RoomID = Room.RoomID WHERE Room.RoomID NOT IN (SELECT RoomID FROM Booking " +
                    $"WHERE StartDate <= '{dtpEndDate.Value.ToShortDateString()}' AND '{dtpStartDate.Value.ToShortDateString()}' <= EndDate) " +
                    $"AND Hotel = {cboHotel.SelectedValue} OR BookingId = {dtBooking.Rows[currentRecord]["BookingId"]};";
            }

            DataTable dtRoomTypeDrop = GetSendData.GetData(sql);

            if (dtRoom.Rows.Count > 0)
            {
                cboRoomType.DisplayMember = "RoomType";
                cboRoomType.DataSource = dtRoomTypeDrop;

                cboRoomType.Enabled = true;
            }
            else
            {
                NoRoomType();
            }

            cboRoomType.Enabled = true;
        }

        private void NoRoomType()
        {
            cboRoomType.DataSource = null;
            cboRoomType.Items.Add("No Room");
            cboRoomType.SelectedIndex = 0;
            cboRoomType.Enabled = false;
        }

        private void LoadBookings()
        {
            try
            {
                dtBooking = GetSendData.GetData("SELECT * FROM Booking");
                dtGuest = GetSendData.GetData("SELECT * FROM Guest");
                dtHotel = GetSendData.GetData("SELECT * FROM Hotel");
                dtRoom = GetSendData.GetData("SELECT * FROM Room");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void PopulateField()
        {
            this.dtpStartDate.ValueChanged -= new System.EventHandler(HotelDateChange);
            this.dtpEndDate.ValueChanged -= new System.EventHandler(HotelDateChange);
            this.cboHotel.SelectionChangeCommitted -= new System.EventHandler(HotelDateChange);

            if (dtBooking.Rows.Count > 0)
            {
                FillHotelDropdown();
                int hotelNum = Convert.ToInt16(dtRoom.Select($"RoomID = {dtBooking.Rows[currentRecord]["RoomID"]}")[0]["Hotel"]);
                cboHotel.SelectedValue = hotelNum;

                FillGustIdDropdown();
                int GuestCurrentIndex = dtGuest.Rows.IndexOf(dtGuest.Select($"GuestID = '{dtBooking.Rows[currentRecord]["GuestID"]}'")[0]);
                cboGuestId.SelectedValue = dtBooking.Rows[currentRecord]["GuestID"];
                txtFirstName.Text = dtGuest.Rows[GuestCurrentIndex]["FirstName"].ToString();
                txtLastName.Text = dtGuest.Rows[GuestCurrentIndex]["LastName"].ToString();
                txtPhone.Text = dtGuest.Rows[GuestCurrentIndex]["Phone"].ToString();

                fillRoomTypeDropdown();
                var roomTypeItem = dtRoom.Select($"RoomId= {dtBooking.Rows[currentRecord]["RoomID"]}")[0]["RoomType"].ToString();
                cboRoomType.SelectedIndex = cboRoomType.FindStringExact(roomTypeItem);

                fillRoomNumberDropdown();
                string roomNumItem = dtRoom.Select($"RoomId = {dtBooking.Rows[currentRecord]["RoomID"]}")[0]["RoomNumber"].ToString();
                cboRoomNumber.SelectedIndex = cboRoomNumber.FindStringExact(roomNumItem);


                dtpStartDate.Value = Convert.ToDateTime(dtBooking.Rows[currentRecord]["StartDate"]);
                dtpEndDate.Value = Convert.ToDateTime(dtBooking.Rows[currentRecord]["EndDate"]);

                lblTotalCharges.Text = dtBooking.Rows[currentRecord]["TotalCharge"].ToString();

                parentForm.toolStripStatusLabel3.Text = $"Position: {currentRecord + 1} of {dtBooking.Rows.Count}";
            }
            this.dtpStartDate.ValueChanged += new System.EventHandler(HotelDateChange);
            this.dtpEndDate.ValueChanged += new System.EventHandler(HotelDateChange);
            this.cboHotel.SelectionChangeCommitted += new System.EventHandler(HotelDateChange);

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

        #region CRUD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addMode = true;
            ToggleControls(false);

            ClearForm();

            fillRoomTypeDropdown();
            fillRoomNumberDropdown();

            parentForm.toolStripStatusLabel3.Text = $"Position: {dtBooking.Rows.Count + 1} of {dtGuest.Rows.Count + 1}";
            parentForm.toolStripStatusLabel4.Text = "Add Record in progress...";
        }

        private void ClearForm()
        {
            foreach (Control gb in this.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control ctrl in gb.Controls)
                    {
                        if (ctrl is TextBox || ctrl is MaskedTextBox)
                        {
                            ctrl.Text = string.Empty;
                        }
                        else if (ctrl is ComboBox cbo)
                        {
                            cbo.SelectedIndex = 0;
                        }
                        else if (ctrl is CheckBox chk)
                        {
                            chk.Enabled = false;
                        }
                        else if (ctrl is DateTimePicker dtp)
                        {
                            dtp.Value = DateTime.Today;
                        }
                    }
                }
            }
            cboRoomType.DataSource = null;
            cboRoomType.Enabled = false;

            cboRoomNumber.DataSource = null;
            cboRoomNumber.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ToggleControls(true);
            addMode = false;

            parentForm.toolStripStatusLabel4.Text = "OK";

            errorProvider1.Clear();

            PopulateField();
        }
        
        #endregion

        private void HotelDateChange(object sender, EventArgs e)
        {
            fillRoomTypeDropdown();
            fillRoomNumberDropdown();
        }

        private void cboRoomType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillRoomNumberDropdown();
        }
    }
}
