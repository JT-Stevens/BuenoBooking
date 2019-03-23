﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Bueno_Bookings
{
    public partial class Rooms : Form
    {
        MainMenuForm parentForm;

        int currentRecord = 0;
        DataTable dtRoom;
        bool addMode = false;

        public Rooms(MainMenuForm p)
        {
            parentForm = p;
            InitializeComponent();
        }

        #region Load Form
        private void Form1_Load(object sender, EventArgs e)
        {
            ToggleControls(true);
            string[] roomType = { "Select a room type", "Penthouse suite", "king", "2 queen", "2 double", "queen", "double" };

            cboRoomType.Items.AddRange(roomType);

            cboRoomType.SelectedIndex = 0;
            dtRoom = GetSendData.GetData("SELECT * FROM room ORDER BY roomNumber ASC");
            LoadComboHotel();
            PopulateField();
        }

        private void LoadComboHotel()
        {
            try
            {
                DataTable dtHotel = GetSendData.GetData("SELECT * FROM hotel ORDER BY name ASC");

                DataRow row = dtHotel.NewRow();
                row["hotelId"] = DBNull.Value;
                row["Name"] = "Select an hotel";
                dtHotel.Rows.InsertAt(row, 0);

                cboHotel.ValueMember = "HotelId";
                cboHotel.DisplayMember = "Name";
                cboHotel.DataSource = dtHotel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void PopulateField()
        {
            //gpBoxNavButton.Enabled = false;

            if (dtRoom.Rows.Count > 0)
            {
                //currentRoomId = Convert.ToInt32(dtRoom.Rows[selectedRoomId]["roomId"].ToString());

                cboHotel.SelectedValue = dtRoom.Rows[currentRecord]["hotel"].ToString();
                txtRoomNumber.Text = dtRoom.Rows[currentRecord]["roomNumber"].ToString();
                cboRoomType.Text = dtRoom.Rows[currentRecord]["roomType"].ToString();
                txtRate.Text = dtRoom.Rows[currentRecord]["rate"].ToString();
                txtParkingRate.Text = dtRoom.Rows[currentRecord]["parkingRate"].ToString();

                parentForm.toolStripStatusLabel3.Text = $"Position: {currentRecord + 1} of {dtRoom.Rows.Count}";
                //gpBoxNavButton.Enabled = true;
                //AddMode = false;
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

        #region Navigation
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
            if (currentRecord < dtRoom.Rows.Count - 1)
            {
                currentRecord++;
                PopulateField();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (currentRecord != dtRoom.Rows.Count - 1)
            {
                currentRecord = dtRoom.Rows.Count - 1;
                PopulateField();
            }
        }
        #endregion

        #region CRUD
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            addMode = true;
            ToggleControls(false);

            parentForm.toolStripStatusLabel3.Text = $"Position: {dtRoom.Rows.Count + 1} of {dtRoom.Rows.Count + 1}";
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
                        else if (ctrl is ComboBox)
                        {
                            ComboBox cbo = (ComboBox)ctrl;
                            cbo.SelectedIndex = 0;
                        }
                        else if (ctrl is CheckBox)
                        {
                            CheckBox chk = (CheckBox)ctrl;
                            chk.Enabled = false;
                        }
                    }
                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string sql = "";
                    if (addMode)
                    {
                        sql = "INSERT INTO Room VALUES(" +
                            $"'{replaceApostrophes(txtRoomNumber.Text)}', " +
                            $"'{replaceApostrophes(cboRoomType.Text)}', " +
                            $"{replaceApostrophes(txtRate.Text)}, " +
                            $"{replaceApostrophes(txtParkingRate.Text)}, " +
                            $"{cboHotel.SelectedValue});";
                    }
                    else //update
                    {
                        sql = $"UPDATE Room SET" +
                            $"RoomNumber='{replaceApostrophes(txtRoomNumber.Text)}' ," +
                            $"RoomType='{replaceApostrophes(cboRoomType.Text)}', " +
                            $"Rate={replaceApostrophes(txtRate.Text)}, " +
                            $"ParkingRate={replaceApostrophes(txtParkingRate.Text)}, " +
                            $"Hotel={cboHotel.SelectedValue} " +
                            $"WHERE roomId={dtRoom.Rows[currentRecord]["RoomID"]}";
                    }

                    Debug.WriteLine($"Rows affected: {GetSendData.SendData(sql)}");

                    LoadComboHotel();
                    PopulateField();

                    addMode = false;
                }
                else
                {
                    parentForm.toolStripStatusLabel4.Text = "Invalid data. Please fix all errors";
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
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete: " + Environment.NewLine +
                $"Room number: {txtRoomNumber.Text}?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Yes)
                {
                    if (GetSendData.SendData($"DELTE FROM Room WHERE RoomId = {dtRoom.Rows[currentRecord]["RoomID"]}") > 0)
                    {
                        MessageBox.Show("Record Deleted");

                        currentRecord = 0;

                        LoadComboHotel();
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

        private void Update_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!addMode)
            {
                TableUpdate();
            }
        }

        private void Update_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!addMode)
            {
                TableUpdate();
            }
        }

        #endregion

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
                        else if (ctrl is ComboBox)
                        {
                            ComboBox cbo = (ComboBox)ctrl;
                            if (cbo.SelectedIndex == 0)
                            {
                                e.Cancel = true;
                                errorProvider1.SetError(ctrl, "Please select an item in the list");
                            }
                            else
                            {
                                errorProvider1.SetError(ctrl, "");
                            }
                        }
                    }
                }
            }
            //Insure that the currency text fields are put in currency format
            if (!Regex.IsMatch(txtParkingRate.Text, "^([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$)"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtParkingRate, "Please put in currency format");
            }
            else
            {
                errorProvider1.SetError(txtParkingRate, "");
            }

            if (!Regex.IsMatch(txtRate.Text, "^([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$)"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRate, "Please put in currency format");
            }
            else
            {
                errorProvider1.SetError(txtParkingRate, "");
            }
        }

        private void Rooms_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        #region GustId Generator
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

            DataTable dt = GetSendData.GetData("SELECT IDENT_CURRENT('hotel')");
            string lastInsertedUid = dt.Rows[0][0].ToString();

            if (lastInsertedUid == "" || lastInsertedUid.Length < 10)
            {
                lastInsertedUid = "AAA00000000";
            }
            string lastGuestStringID = lastInsertedUid.Substring(0, 3);
            int lastGuestNumberId = Convert.ToInt32(lastInsertedUid.Substring(3, 7));
            if (lastGuestNumberId == 9999999)
            {
                lastGuestNumberId = 0;
                lastGuestStringID = GuestStringID(lastGuestStringID);
            }
            string newGuestId = (lastGuestNumberId + 1).ToString();
            while (newGuestId.Length < 7)
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


        #endregion

    }
}
