namespace Bueno_Bookings
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRooms = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBookingReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuestReport = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuest = new System.Windows.Forms.ToolStripButton();
            this.tsbRooms = new System.Windows.Forms.ToolStripButton();
            this.tsbBooking = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBookingReport = new System.Windows.Forms.ToolStripButton();
            this.tsbGuestReport = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new MdiTabControl.TabControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.maintenanceToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1278, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::Bueno_Bookings.Properties.Resources.ExitIcon;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(108, 26);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGuest,
            this.mnuRooms,
            this.mnuBooking});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.maintenanceToolStripMenuItem.Text = "&Maintenance";
            // 
            // mnuGuest
            // 
            this.mnuGuest.Image = global::Bueno_Bookings.Properties.Resources.GuestIcon;
            this.mnuGuest.Name = "mnuGuest";
            this.mnuGuest.Size = new System.Drawing.Size(145, 26);
            this.mnuGuest.Text = "&Guests";
            this.mnuGuest.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // mnuRooms
            // 
            this.mnuRooms.Image = global::Bueno_Bookings.Properties.Resources.RoomsIcon;
            this.mnuRooms.Name = "mnuRooms";
            this.mnuRooms.Size = new System.Drawing.Size(145, 26);
            this.mnuRooms.Text = "&Rooms";
            this.mnuRooms.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // mnuBooking
            // 
            this.mnuBooking.Image = ((System.Drawing.Image)(resources.GetObject("mnuBooking.Image")));
            this.mnuBooking.Name = "mnuBooking";
            this.mnuBooking.Size = new System.Drawing.Size(145, 26);
            this.mnuBooking.Text = "&Bookings";
            this.mnuBooking.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBookingReport,
            this.mnuGuestReport});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // mnuBookingReport
            // 
            this.mnuBookingReport.Image = global::Bueno_Bookings.Properties.Resources.BookingReportIcon;
            this.mnuBookingReport.Name = "mnuBookingReport";
            this.mnuBookingReport.Size = new System.Drawing.Size(239, 26);
            this.mnuBookingReport.Text = "Show &Bookings by date";
            this.mnuBookingReport.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // mnuGuestReport
            // 
            this.mnuGuestReport.Image = global::Bueno_Bookings.Properties.Resources.GuesChargesReportIcon;
            this.mnuGuestReport.Name = "mnuGuestReport";
            this.mnuGuestReport.Size = new System.Drawing.Size(239, 26);
            this.mnuGuestReport.Text = "Show &Guest charges";
            this.mnuGuestReport.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 589);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1278, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuest,
            this.tsbRooms,
            this.tsbBooking,
            this.toolStripSeparator1,
            this.tsbBookingReport,
            this.tsbGuestReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1278, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuest
            // 
            this.tsbGuest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuest.Image = global::Bueno_Bookings.Properties.Resources.GuestIcon;
            this.tsbGuest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuest.Name = "tsbGuest";
            this.tsbGuest.Size = new System.Drawing.Size(24, 24);
            this.tsbGuest.Text = "toolStripButton1";
            this.tsbGuest.ToolTipText = "Guest";
            this.tsbGuest.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // tsbRooms
            // 
            this.tsbRooms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRooms.Image = global::Bueno_Bookings.Properties.Resources.RoomsIcon;
            this.tsbRooms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRooms.Name = "tsbRooms";
            this.tsbRooms.Size = new System.Drawing.Size(24, 24);
            this.tsbRooms.Text = "toolStripButton2";
            this.tsbRooms.ToolTipText = "Room";
            this.tsbRooms.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // tsbBooking
            // 
            this.tsbBooking.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBooking.Image = global::Bueno_Bookings.Properties.Resources.BookingIcon1;
            this.tsbBooking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBooking.Name = "tsbBooking";
            this.tsbBooking.Size = new System.Drawing.Size(24, 24);
            this.tsbBooking.Text = "toolStripButton3";
            this.tsbBooking.ToolTipText = "Booking";
            this.tsbBooking.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbBookingReport
            // 
            this.tsbBookingReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBookingReport.Image = global::Bueno_Bookings.Properties.Resources.BookingReportIcon;
            this.tsbBookingReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBookingReport.Name = "tsbBookingReport";
            this.tsbBookingReport.Size = new System.Drawing.Size(24, 24);
            this.tsbBookingReport.Text = "toolStripButton4";
            this.tsbBookingReport.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // tsbGuestReport
            // 
            this.tsbGuestReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuestReport.Image = global::Bueno_Bookings.Properties.Resources.GuesChargesReportIcon;
            this.tsbGuestReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuestReport.Name = "tsbGuestReport";
            this.tsbGuestReport.Size = new System.Drawing.Size(24, 24);
            this.tsbGuestReport.Text = "toolStripButton5";
            this.tsbGuestReport.Click += new System.EventHandler(this.MenuToolStripButton);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 55);
            this.tabControl1.MenuRenderer = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(1278, 534);
            this.tabControl1.TabCloseButtonImage = null;
            this.tabControl1.TabCloseButtonImageDisabled = null;
            this.tabControl1.TabCloseButtonImageHot = null;
            this.tabControl1.TabIndex = 3;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 614);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuGuest;
        private System.Windows.Forms.ToolStripMenuItem mnuRooms;
        private System.Windows.Forms.ToolStripMenuItem mnuBooking;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBookingReport;
        private System.Windows.Forms.ToolStripMenuItem mnuGuestReport;
        private System.Windows.Forms.ToolStripButton tsbGuest;
        private System.Windows.Forms.ToolStripButton tsbRooms;
        private System.Windows.Forms.ToolStripButton tsbBooking;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbBookingReport;
        private System.Windows.Forms.ToolStripButton tsbGuestReport;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        public MdiTabControl.TabControl tabControl1;
    }
}

