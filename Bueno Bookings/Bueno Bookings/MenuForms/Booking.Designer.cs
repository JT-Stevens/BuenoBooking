namespace Bueno_Bookings
{
    partial class Booking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpNav = new System.Windows.Forms.GroupBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboRoomNumber = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboHotel = new System.Windows.Forms.ComboBox();
            this.chkPreferred = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cboRoomType = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalCharges = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboGuestId = new System.Windows.Forms.ComboBox();
            this.grpNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNav
            // 
            this.grpNav.Controls.Add(this.btnFirst);
            this.grpNav.Controls.Add(this.btnPrevious);
            this.grpNav.Controls.Add(this.btnLast);
            this.grpNav.Controls.Add(this.btnNext);
            this.grpNav.Location = new System.Drawing.Point(458, 385);
            this.grpNav.Name = "grpNav";
            this.grpNav.Size = new System.Drawing.Size(292, 86);
            this.grpNav.TabIndex = 18;
            this.grpNav.TabStop = false;
            // 
            // btnFirst
            // 
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.btnFirst.Location = new System.Drawing.Point(4, 11);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(64, 64);
            this.btnFirst.TabIndex = 8;
            this.btnFirst.Text = "⏮";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.Location = new System.Drawing.Point(76, 11);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(64, 64);
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "◀";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnLast
            // 
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.btnLast.Location = new System.Drawing.Point(220, 11);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(64, 64);
            this.btnLast.TabIndex = 11;
            this.btnLast.Text = "⏭";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(148, 11);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(64, 64);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "▶";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(331, 319);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(128, 46);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(734, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 46);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(466, 319);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(128, 46);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(600, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 46);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboRoomNumber);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboHotel);
            this.groupBox1.Controls.Add(this.chkPreferred);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.cboRoomType);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Location = new System.Drawing.Point(60, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 213);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(335, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Room Number";
            // 
            // cboRoomNumber
            // 
            this.cboRoomNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomNumber.FormattingEnabled = true;
            this.cboRoomNumber.Location = new System.Drawing.Point(336, 130);
            this.cboRoomNumber.Name = "cboRoomNumber";
            this.cboRoomNumber.Size = new System.Drawing.Size(144, 24);
            this.cboRoomNumber.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(6, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Hotel";
            // 
            // cboHotel
            // 
            this.cboHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHotel.FormattingEnabled = true;
            this.cboHotel.Location = new System.Drawing.Point(10, 129);
            this.cboHotel.Name = "cboHotel";
            this.cboHotel.Size = new System.Drawing.Size(144, 24);
            this.cboHotel.TabIndex = 20;
            // 
            // chkPreferred
            // 
            this.chkPreferred.AutoSize = true;
            this.chkPreferred.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPreferred.Location = new System.Drawing.Point(100, 221);
            this.chkPreferred.Name = "chkPreferred";
            this.chkPreferred.Size = new System.Drawing.Size(194, 24);
            this.chkPreferred.TabIndex = 19;
            this.chkPreferred.Text = "Required Parking";
            this.chkPreferred.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(169, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Room Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(267, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Finish Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "ddd MMM dd, yy ";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(271, 71);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(190, 22);
            this.dtpEndDate.TabIndex = 3;
            // 
            // cboRoomType
            // 
            this.cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomType.FormattingEnabled = true;
            this.cboRoomType.Location = new System.Drawing.Point(173, 130);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.Size = new System.Drawing.Size(144, 24);
            this.cboRoomType.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "ddd MMM dd, yy ";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(10, 71);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(190, 22);
            this.dtpStartDate.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(644, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Total Charges";
            // 
            // lblTotalCharges
            // 
            this.lblTotalCharges.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCharges.Location = new System.Drawing.Point(648, 288);
            this.lblTotalCharges.Name = "lblTotalCharges";
            this.lblTotalCharges.Size = new System.Drawing.Size(184, 22);
            this.lblTotalCharges.TabIndex = 20;
            // 
            // txtLastName
            // 
            this.txtLastName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLastName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLastName.Location = new System.Drawing.Point(30, 132);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(184, 22);
            this.txtLastName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(26, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Last Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(287, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFirstName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFirstName.Location = new System.Drawing.Point(291, 132);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(184, 22);
            this.txtFirstName.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddGuest);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboGuestId);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtLastName);
            this.groupBox2.Controls.Add(this.txtFirstName);
            this.groupBox2.Location = new System.Drawing.Point(618, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 213);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAddGuest.Location = new System.Drawing.Point(291, 36);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(184, 59);
            this.btnAddGuest.TabIndex = 33;
            this.btnAddGuest.Text = "This guest is not in our list. Add to list?";
            this.btnAddGuest.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(30, 185);
            this.txtPhone.Mask = "(000)000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(99, 22);
            this.txtPhone.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Phone Number ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(26, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "GuestID";
            // 
            // cboGuestId
            // 
            this.cboGuestId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGuestId.FormattingEnabled = true;
            this.cboGuestId.Location = new System.Drawing.Point(30, 71);
            this.cboGuestId.Name = "cboGuestId";
            this.cboGuestId.Size = new System.Drawing.Size(184, 24);
            this.cboGuestId.TabIndex = 24;
            // 
            // Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 526);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotalCharges);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpNav);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Name = "Booking";
            this.Text = "Booking";
            this.Load += new System.EventHandler(this.Booking_Load);
            this.grpNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNav;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalCharges;
        private System.Windows.Forms.CheckBox chkPreferred;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboGuestId;
        private System.Windows.Forms.Button btnAddGuest;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboRoomNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboHotel;
    }
}