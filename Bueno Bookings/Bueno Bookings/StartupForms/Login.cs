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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string username;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                

                DataTable dt = GetSendData.GetData("SELECT * FROM UserAccounts");

                if (!(dt.Rows[0]["UserName"].ToString().ToLower() == txtUserName.Text.Trim().ToLower()) || !(dt.Rows[0]["password"].ToString() == txtPassword.Text.Trim()))
                {
                    txtPassword.Clear();
                    MessageBox.Show("Username or password does not exist");
                }
                else
                {
                    username = txtUserName.Text;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "Jeremy.Stevens";
            txtPassword.Text = "password";
        }
    }
}
