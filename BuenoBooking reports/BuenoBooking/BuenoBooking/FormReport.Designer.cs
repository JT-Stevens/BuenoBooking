namespace BuenoBooking
{
    partial class FormReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisplayBooking = new System.Windows.Forms.Button();
            this.cboPreferredStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDisplayGuests = new System.Windows.Forms.Button();
            this.cboHotel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisplayBooking);
            this.groupBox1.Controls.Add(this.cboPreferredStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtPEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bookings";
            // 
            // btnDisplayBooking
            // 
            this.btnDisplayBooking.Location = new System.Drawing.Point(155, 166);
            this.btnDisplayBooking.Name = "btnDisplayBooking";
            this.btnDisplayBooking.Size = new System.Drawing.Size(150, 38);
            this.btnDisplayBooking.TabIndex = 9;
            this.btnDisplayBooking.Text = "Display";
            this.btnDisplayBooking.UseVisualStyleBackColor = true;
            this.btnDisplayBooking.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboPreferredStatus
            // 
            this.cboPreferredStatus.FormattingEnabled = true;
            this.cboPreferredStatus.Location = new System.Drawing.Point(105, 121);
            this.cboPreferredStatus.Name = "cboPreferredStatus";
            this.cboPreferredStatus.Size = new System.Drawing.Size(200, 24);
            this.cboPreferredStatus.TabIndex = 8;
            this.cboPreferredStatus.SelectedIndexChanged += new System.EventHandler(this.cboPreferredStatus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Filter :";
            // 
            // dtPEndDate
            // 
            this.dtPEndDate.Location = new System.Drawing.Point(105, 78);
            this.dtPEndDate.Name = "dtPEndDate";
            this.dtPEndDate.Size = new System.Drawing.Size(200, 22);
            this.dtPEndDate.TabIndex = 7;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(105, 30);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtpStartDate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Start date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "End date :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDisplayGuests);
            this.groupBox2.Controls.Add(this.cboHotel);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(370, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(445, 210);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Guests";
            // 
            // btnDisplayGuests
            // 
            this.btnDisplayGuests.Location = new System.Drawing.Point(151, 78);
            this.btnDisplayGuests.Name = "btnDisplayGuests";
            this.btnDisplayGuests.Size = new System.Drawing.Size(150, 38);
            this.btnDisplayGuests.TabIndex = 11;
            this.btnDisplayGuests.Text = "Display";
            this.btnDisplayGuests.UseVisualStyleBackColor = true;
            this.btnDisplayGuests.Click += new System.EventHandler(this.btnDisplayGuests_Click);
            // 
            // cboHotel
            // 
            this.cboHotel.FormattingEnabled = true;
            this.cboHotel.Location = new System.Drawing.Point(81, 35);
            this.cboHotel.Name = "cboHotel";
            this.cboHotel.Size = new System.Drawing.Size(220, 24);
            this.cboHotel.TabIndex = 10;
            this.cboHotel.SelectedIndexChanged += new System.EventHandler(this.cboHotel_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Hotel :";
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(23, 32);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.Size = new System.Drawing.Size(1139, 373);
            this.dgvReport.TabIndex = 2;
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.dgvReport);
            this.grpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox.Location = new System.Drawing.Point(12, 240);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(1179, 422);
            this.grpBox.TabIndex = 3;
            this.grpBox.TabStop = false;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 699);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.Load += new System.EventHandler(this.FormReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.grpBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisplayBooking;
        private System.Windows.Forms.ComboBox cboPreferredStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDisplayGuests;
        private System.Windows.Forms.ComboBox cboHotel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.GroupBox grpBox;
    }
}