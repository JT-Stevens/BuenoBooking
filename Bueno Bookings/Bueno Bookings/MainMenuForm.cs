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
    public partial class MainMenuForm : Form
    {
        private Guests frmGuests;
        private Rooms frmRooms;
        

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            Splash splashForm = new Splash();
            Login loginForm = new Login();

            splashForm.ShowDialog();

            if (splashForm.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                loginForm.ShowDialog();
            }

            if (loginForm.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                SetUpStatusStrip();
                this.Show();
            }
        }

        #region Setup Status Strip
        private void SetUpStatusStrip()
        {
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.Table;

            toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;

            toolStripStatusLabel2.Text = Login.username;
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Right;

            toolStripStatusLabel3.Text = "Position: 0 of 0";
            toolStripStatusLabel3.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Right;

            toolStripStatusLabel4.Text = "OK";
            toolStripStatusLabel4.TextAlign = ContentAlignment.MiddleRight;

        }
        #endregion

        private void OpenForm(Form form)
        {
            if (tabControl1.Contains(form))
            {
                tabControl1.TabPages[form].Select();
            }
            else
            {
                tabControl1.TabPages.Add(form);
                form.Show();
            }
        }

        private void MenuToolStripButton(object sender, EventArgs e)
        {
            ToolStripItem stripItem = (ToolStripItem)sender;

            if (stripItem.Name == "mnuGuest" || stripItem.Name == "tsbGuest")
            {
                if (frmGuests == null || frmGuests.IsDisposed)
                {
                    frmGuests = new Guests(this);
                }

                OpenForm(frmGuests);
            }

            if (stripItem.Name == "mnuRooms" || stripItem.Name == "tsbRooms")
            {
                if (frmRooms == null || frmRooms.IsDisposed)
                {
                    frmRooms= new Rooms(this);
                }

                OpenForm(frmRooms);
            }
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
