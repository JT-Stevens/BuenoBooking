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
using System.Text.RegularExpressions;

namespace Bueno_Bookings
{
    public partial class Guests : Form
    {
        MainMenuForm parentForm;
        DataTable dtGuest;

        int currentRecord = 0;
        bool addMode;

        public Guests(MainMenuForm p)
        {
            parentForm = p;
            InitializeComponent();
        }

        #region Load Form
        private void Guests_Load(object sender, EventArgs e)
        {
            ToggleControls(true);

            Dictionary<string, string> provinces = new Dictionary<string, string>
            {
                {"Please Select a Province", ""},
                {"Alberta", "AB"}, { "British Columbia", "BC" },  {"Manitoba","MB" }, {"New Brunswick", "NB"}, {"Newfoundland and Labrador", "NL"},
                { "Northwest Territories", "NT"}, { "Nova Scotia", "NS"}, {"Nunavut","NU" }, { "Ontario", "ON" }, {"Prince Edward Island","PE" }, 
                { "Quebec", "QC" }, {"Saskatchewan", "SK"}, {"Yukon", "YT"}
            };
            
            cboProvince.DisplayMember = "key";
            cboProvince.ValueMember = "value";
            cboProvince.DataSource = new BindingSource(provinces, null);

            cboProvince.SelectedIndex = 0;

            LoadGuest();
            PopulateField();
        }

        private void LoadGuest()
        {
            try
            {
                dtGuest = GetSendData.GetData("SELECT * FROM Guest");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void PopulateField()
        {
            if (dtGuest.Rows.Count > 0)
            {
                txtFirstName.Text = dtGuest.Rows[currentRecord]["FirstName"].ToString();
                txtLastName.Text = dtGuest.Rows[currentRecord]["LastName"].ToString();
                txtEmail.Text = dtGuest.Rows[currentRecord]["Email"].ToString();
                txtPhone.Text = dtGuest.Rows[currentRecord]["Phone"].ToString();
                txtCity.Text = dtGuest.Rows[currentRecord]["City"].ToString();
                txtStreetAddress.Text = dtGuest.Rows[currentRecord]["StreetAddress"].ToString();
                cboProvince.SelectedValue = dtGuest.Rows[currentRecord]["Province"];
                txtPostalCode.Text = dtGuest.Rows[currentRecord]["PostalCode"].ToString();
                chkPreferred.Checked = (bool)dtGuest.Rows[currentRecord]["Preferred"];

                parentForm.toolStripStatusLabel3.Text = $"Position: {currentRecord + 1} of {dtGuest.Rows.Count}";
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
            if (currentRecord < dtGuest.Rows.Count - 1)
            {
                currentRecord++;
                PopulateField();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (currentRecord != dtGuest.Rows.Count - 1)
            {
                currentRecord = dtGuest.Rows.Count - 1;
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

            parentForm.toolStripStatusLabel3.Text = $"Position: {dtGuest.Rows.Count + 1} of {dtGuest.Rows.Count + 1}";
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
                    ToggleControls(true);

                    txtPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    if (addMode)
                    {
                        sql = $"INSERT INTO Guest VALUES (" +
                            $"'{generateGuestId()}', " +
                            $"'{replaceApostrophes(txtFirstName.Text)}', " +
                            $"'{replaceApostrophes(txtLastName.Text)}', " +
                            $"'{replaceApostrophes(txtStreetAddress.Text)}', " +
                            $"'{replaceApostrophes(txtCity.Text)}', " +
                            $"'{cboProvince.SelectedValue}', " +
                            $"'{replaceApostrophes(txtPostalCode.Text)}', " +
                            $"{replaceApostrophes(txtPhone.Text)}, " +
                            $"'{replaceApostrophes(txtEmail.Text)}', " +
                            $"{Convert.ToByte(chkPreferred.Checked)})";
                    }
                    else //update
                    {
                        sql = $"UPDATE Guest SET " +
                            $"FirstName = '{replaceApostrophes(txtFirstName.Text)}', " +
                            $"LastName = '{replaceApostrophes(txtLastName.Text)}', " +
                            $"StreetAddress = '{replaceApostrophes(txtStreetAddress.Text)}', " +
                            $"City = '{replaceApostrophes(txtCity.Text)}', " +
                            $"Province = '{cboProvince.SelectedValue}', " +
                            $"PostalCode = '{replaceApostrophes(txtPostalCode.Text)}', " +
                            $"Phone = {replaceApostrophes(txtPhone.Text)}, " +
                            $"Email = '{replaceApostrophes(txtEmail.Text)}', " +
                            $"Preferred = {Convert.ToByte(chkPreferred.Checked)} " +
                            $"WHERE GuestId = '{dtGuest.Rows[currentRecord]["GuestId"]}'";
                    }

                    txtPhone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    Debug.WriteLine($"Rows affected: {GetSendData.SendData(sql)}");

                    LoadGuest();
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
                $"{txtLastName.Text}, {txtFirstName.Text} " + Environment.NewLine +
                $"GuestID: {dtGuest.Rows[currentRecord]["GuestID"]}?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Yes)
                {
                    if (GetSendData.SendData($"DELETE FROM Guest WHERE GuestId = '{dtGuest.Rows[currentRecord]["GuestID"]}'") > 0)
                    {
                        MessageBox.Show("Record Deleted");

                        currentRecord = 0;

                        LoadGuest();
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

        private string generateGuestId()
        {
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder idBuild = new StringBuilder("", 10);
            
            idBuild.Append(alphabet[random.Next(0, alphabet.Length)]);
            idBuild.Append(alphabet[random.Next(0, alphabet.Length)]);
            idBuild.Append(alphabet[random.Next(0, alphabet.Length)]);
            idBuild.Append(random.Next(1000000).ToString("0000000"));
            

            if (Convert.ToInt16(GetSendData.GetScalarValue($"SELECT COUNT(*) FROM Guest WHERE GuestId = '{idBuild}'")) == 0)
            {
                return idBuild.ToString();
            }

            return generateGuestId();
        }

        private string  replaceApostrophes(string text)
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

        private void Update_MouseClick(object sender, MouseEventArgs e)
        {
            if (!addMode)
            {
                TableUpdate();
            }
        }

        #endregion

        #region Entry Validation

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

            //Email is right format
            if (!Regex.IsMatch(txtEmail.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Email does not fit proper format");
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);
            }

            //Phone Number
            if (!txtPhone.MaskCompleted)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Phone must have 10 digits");
            }
            else
            {
                errorProvider1.SetError(txtPhone, string.Empty);
            }

            //Postal Code is right format
            if (!Regex.IsMatch(txtPostalCode.Text, @"^[A-Za-b]\d[A-Za-b] \d[A-Za-b]\d$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPostalCode, "Post code does not fit proper format: E1E 1E1");
            }
            else
            {
                errorProvider1.SetError(txtPostalCode, string.Empty);
            }
        }

        private void Guests_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        #endregion


    }
}
