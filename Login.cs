using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechFix
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text=="CozyAdmin" && txtpassword.Text=="Cozycomfort123")
            {
                new Main().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("The Username or Password is incorrect, Please try agian");
                txtUserName.Clear();
                txtpassword.Clear();
                txtUserName.Focus();

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
