using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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

                FillGuestSuggestions();
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
            txtPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string sql = string.Empty;
            if (addMode)
            {
                sql = $"SELECT GuestId FROM Guest " +
                    $"WHERE FirstName {(string.IsNullOrWhiteSpace(txtFirstName.Text) ? " IS NOT NULL" : " = '" + txtFirstName.Text + "'" )} " +
                    $"AND LastName {(string.IsNullOrWhiteSpace(txtLastName.Text) ? " IS NOT NULL" : " = '" + txtLastName.Text + "'")} " +
                    $"AND Phone {(string.IsNullOrWhiteSpace(txtPhone.Text) ? " IS NOT NULL" : " = '" + txtPhone.Text + "'")} ";
            }
            else
            {
                sql = "SELECT GuestId FROM Guest";
            }

            txtPhone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            DataTable dtGuestDrop = GetSendData.GetData(sql);

            DataRow row = dtGuestDrop.NewRow();
            row["GuestId"] = "No Guest";
            dtGuestDrop.Rows.InsertAt(row, 0);

            cboGuestId.DisplayMember = "GuestID";
            cboGuestId.ValueMember = "GuestID";
            cboGuestId.DataSource = dtGuestDrop;

            cboGuestId.SelectedIndex = currentRecord;

        }

        private void FillGuestSuggestions()
        {
            AutoCompleteStringCollection FNamesource = new AutoCompleteStringCollection();
            FNamesource.AddRange(dtGuest.AsEnumerable().Select(r => r.Field<string>("FirstName")).ToArray());
            //Remove null value
            FNamesource.RemoveAt(0);
            txtFirstName.AutoCompleteCustomSource = FNamesource;

            AutoCompleteStringCollection LNameSource = new AutoCompleteStringCollection();
            LNameSource.AddRange(dtGuest.AsEnumerable().Select(r => r.Field<string>("LastName")).ToArray());
            //Remove null value
            LNameSource.RemoveAt(0);
            txtLastName.AutoCompleteCustomSource = LNameSource;
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
                    $"WHERE StartDate <= '{dtpEndDate.Value.ToShortDateString()}' AND '{dtpStartDate.Value.ToShortDateString()}' <= EndDate) " +
                    $"AND Hotel = {cboHotel.SelectedValue}" +
                    $"ORDER BY RoomNumber;";
            }
            else
            {
                sql = $"SELECT RoomNumber FROM Room LEFT OUTER JOIN Booking " +
                    $"ON Booking.RoomID = Room.RoomID WHERE RoomType = '{cboRoomType.Text}' AND Room.RoomId NOT IN (SELECT RoomID FROM Booking " +
                    $"WHERE StartDate <= '{dtpEndDate.Value.ToShortDateString()}' AND '{dtpStartDate.Value.ToShortDateString()}' <= EndDate) " +
                    $"AND Hotel = {cboHotel.SelectedValue}" +
                    $"OR BookingId = {dtBooking.Rows[currentRecord]["BookingId"]} " +
                    $"ORDER BY RoomNumber;";
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

                int GuestCurrentIndex = dtGuest.Rows.IndexOf(dtGuest.Select($"GuestID = '{dtBooking.Rows[currentRecord]["GuestID"]}'")[0]);
                txtFirstName.Text = dtGuest.Rows[GuestCurrentIndex]["FirstName"].ToString();
                txtLastName.Text = dtGuest.Rows[GuestCurrentIndex]["LastName"].ToString();
                txtPhone.Text = dtGuest.Rows[GuestCurrentIndex]["Phone"].ToString();
                FillGustIdDropdown();
                cboGuestId.SelectedValue = dtBooking.Rows[currentRecord]["GuestID"];

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

            txtFirstName.Enabled = !state;
            txtLastName.Enabled = !state;
            txtPhone.Enabled = !state;
            
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

            FillGustIdDropdown();

            parentForm.toolStripStatusLabel3.Text = $"Position: {dtBooking.Rows.Count + 1} of {dtBooking.Rows.Count + 1}";
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
                        if (ctrl is TextBox || ctrl is MaskedTextBox || ctrl is Label)
                        {
                            ctrl.Text = string.Empty;
                        }
                        else if (ctrl is ComboBox cbo)
                        {
                            cbo.SelectedIndex = 0;
                        }
                        else if (ctrl is CheckBox chk)
                        {
                            chk.Checked = false;
                        }
                        else if (ctrl is DateTimePicker dtp)
                        {
                            dtp.Value = DateTime.Today;
                        }
                    }
                }
            }

            lblTotalCharges.Text = string.Empty;

            cboRoomType.DataSource = null;
            cboRoomType.Enabled = false;

            cboRoomNumber.DataSource = null;
            cboRoomNumber.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    ToggleControls(true);
                    string sql = string.Empty;

                    int roomId = Convert.ToInt16(dtRoom.Select($"roomNumber = {cboRoomNumber.Text} AND roomType = '{cboRoomType.Text}' AND hotel = {cboHotel.SelectedValue}")[0]["RoomId"]);

                    if (addMode)
                    {
                        sql = $"INSERT INTO booking VALUES (" +
                            $"'{dtpStartDate.Value.ToShortDateString()}', " +       //Startdate
                            $"'{dtpEndDate.Value.ToShortDateString()}'," +          //Enddate
                            $"{roomId}, " +                                         //RoomId
                            $"'{cboGuestId.Text}'," +                               //GuestId
                            $"{Convert.ToByte(chkRequiredParking.Checked)}, " +     //RequiredParking
                            $"{(lblTotalCharges.Text)});";                          //Total Charge
                    }
                    else //Update
                    {
                        sql = $"UPDATE Booking SET " +
                            $"StartDate = '{dtpStartDate.Value.ToShortDateString()}', " +
                            $"EndDate  = '{dtpEndDate.Value.ToShortDateString()}', " +
                            $"RoomId = {roomId}, " +
                            $"GuestID = '{cboGuestId.Text}', " +
                            $"RequiredParking = {Convert.ToByte(chkRequiredParking.Checked)}, " +
                            $"TotalCharge = {lblTotalCharges.Text} " +
                            $"WHERE BookingID = {dtBooking.Rows[currentRecord]["GuestID"]};";
                    }

                    Debug.WriteLine($"Rows affected: {GetSendData.SendData(sql)}");

                    parentForm.toolStripStatusLabel4.Text = "OK";

                    LoadBookings();
                    PopulateField();

                    addMode = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this booking? " + Environment.NewLine +
                    $"Starting:   {dtpStartDate.Value.ToLongDateString()}" + Environment.NewLine +
                    $"Ending:    {dtpEndDate.Value.ToLongDateString()}" + Environment.NewLine +
                    $"for hotel:  {cboHotel.Text}", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Yes)
                {
                    if (GetSendData.SendData($"DELETE FROM Booking WHERE BookingId = {dtBooking.Rows[currentRecord]["BookingID"]}") > 0)
                    {
                        MessageBox.Show("Record Deleted");

                        currentRecord = 0;

                        LoadBookings();
                        PopulateField();
                    }
                    else
                    {
                        MessageBox.Show("An error occured while saving the data.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ToggleControls(true);
            addMode = false;

            parentForm.toolStripStatusLabel4.Text = "OK";

            errorProvider1.Clear();

            PopulateField();
        }

        private string replaceApostrophes(string text)
        {
            return text.Replace("'", "''").Trim();
        }

        private void TableUpdate()
        {
            ToggleControls(false);
            addMode = false;

            parentForm.toolStripStatusLabel4.Text = "Edit in progress...";
        }

        #endregion

        private void HotelDateChange(object sender, EventArgs e)
        {
            fillRoomTypeDropdown();
            fillRoomNumberDropdown();
            CalcTotal();

            if (!addMode)
            {
                TableUpdate();
            }
        }

        private void cboRoomType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillRoomNumberDropdown();
            CalcTotal();

            if (!addMode)
            {
                TableUpdate();
            }
        }

        private void cboGuestId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboGuestId.SelectedIndex == 0)
            {
                txtLastName.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                btnAddGuest.Visible = true;
            }
            else
            {
                txtLastName.Text = dtGuest.Select($"GuestId = '{cboGuestId.Text}'")[0]["LastName"].ToString();
                txtFirstName.Text = dtGuest.Select($"GuestId = '{cboGuestId.Text}'")[0]["FirstName"].ToString();
                txtPhone.Text = dtGuest.Select($"GuestID = '{cboGuestId.Text}'")[0]["Phone"].ToString();
                btnAddGuest.Visible = false;
            }

            CalcTotal();

            if (!addMode)
            {
                TableUpdate();
            }
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            FillGustIdDropdown();
        }

        private void chkRequiredParking_Click(object sender, EventArgs e)
        {
            CalcTotal();
            if (!addMode)
            {
                TableUpdate();
            }
        }

        private void CalcTotal()
        {
            if (cboRoomNumber.Text.ToLower() != "no room" && cboRoomType.Text.ToLower() != "no room" && cboHotel.SelectedIndex > 0 && cboGuestId.Text.ToLower() != "no guest")
            {
                int roomId = Convert.ToInt16(dtRoom.Select($"roomNumber = {cboRoomNumber.Text} AND roomType = '{cboRoomType.Text}' AND hotel = {cboHotel.SelectedValue}")[0]["RoomId"]);
                int rate = Convert.ToInt16(dtRoom.Select($"roomId = {roomId}")[0]["Rate"]);
                double parking;

                //If Guest is not a prefered guest
                if (!(bool)dtGuest.Select($"GuestId = '{cboGuestId.Text}'")[0]["Preferred"]) 
                {
                    //Full Price parking
                    parking = Convert.ToInt16(dtRoom.Select($"roomId = {roomId}")[0]["ParkingRate"]); 
                }
                else
                {
                    //20% discount due to prefereed status
                    parking = (Convert.ToInt16(dtRoom.Select($"roomId = {roomId}")[0]["ParkingRate"])) * .8; 
                }

                //If parking required charge current parking price, else nothing
                lblTotalCharges.Text = (chkRequiredParking.Checked ? parking + rate : rate).ToString("c"); 
            }
        }

        #region Entery Validation
        private void ControlValidation(object sender, CancelEventArgs e)
        {
            //Loop through all the controls 
            //Check TextBox is not null or whitespace
            //Check ComboBox has a valid option selected.
            foreach (Control gp in this.Controls)
            {
                //The controls are in a groupbox so a nested loop is required
                if (gp is GroupBox)
                {
                    foreach (Control ctrl in gp.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            if (string.IsNullOrWhiteSpace(ctrl.Text))
                            {
                                e.Cancel = true;
                                errorProvider1.SetError(ctrl, "This field is required");
                            }
                            else
                            {
                                errorProvider1.SetError(ctrl, "");
                            }
                        }
                    }
                }
            }

            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                e.Cancel = true;
                errorProvider1.SetError(dtpEndDate, "End date can not be before the start date.");
            }
            else
            {
                errorProvider1.SetError(dtpEndDate, "");
            }

            if (cboRoomType.Text.ToLower() == "no room")
            {
                e.Cancel = true;
                errorProvider1.SetError(cboRoomType, "This field is required");
            }
            else
            {
                errorProvider1.SetError(cboRoomType, "");
            }

            if (cboRoomNumber.Text.ToLower() == "no room")
            {
                e.Cancel = true;
                errorProvider1.SetError(cboRoomNumber, "This field is required");
            }
            else
            {
                errorProvider1.SetError(cboRoomNumber, "");
            }

            if (cboGuestId.Text.ToLower() == "no guest")
            {
                e.Cancel = true;
                errorProvider1.SetError(cboGuestId, "This field is required");
            }
            else
            {
                errorProvider1.SetError(cboGuestId, "");
            }

            //Business Rule:
            //A booking cannot be created for the penthouse suite for a guest that has not booked with the
            //hotel at least 2 times in the past.
            if (cboRoomNumber.Text.ToLower() != "no room" && cboRoomType.Text.ToLower() == "penthouse suite" && cboHotel.SelectedIndex > 0 && cboGuestId.Text.ToLower() != "no guest")
            {
                if (Convert.ToInt16(GetSendData.GetScalarValue($"SELECT COUNT(*) FROM Booking INNER JOIN Room ON Booking.RoomID = Room.RoomID WHERE GuestID = '{cboGuestId.Text}' AND Hotel = {cboHotel.SelectedValue};")) < 2)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(cboRoomType, "Guest must have booked with us twice in the past to get Penthouse option");
                }
            }
        }

        #endregion
    }
}
