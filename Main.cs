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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Products ps = new Products();
            ps.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customers cs = new Customers();
            cs.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Orders os = new Orders();
            os.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Inventry iy = new Inventry();
            iy.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            User ur = new User();
            ur.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
