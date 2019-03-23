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
            ToggleControls(true);


        }

        private void ToggleControls(bool v)
        {

        }


        #endregion


    }
}
