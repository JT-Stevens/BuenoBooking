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

        public Booking(MainMenuForm p)
        {
            parentForm = p;
            InitializeComponent();
        }
    }
}
