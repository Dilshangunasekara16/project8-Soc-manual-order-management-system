using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TechFix
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"INSERT INTO [inventrydb].dbo.[usertab] ([UserId],[Name],[Phone],[Address])
            VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";

            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("User Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        public void ShowData()
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventrydb].dbo.[usertab]", con);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in table.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["uid"].Value = item["UserId"].ToString();
                dataGridView1.Rows[n].Cells["uname"].Value = item["Name"].ToString();
                dataGridView1.Rows[n].Cells["uphone"].Value = item["Phone"].ToString();
                dataGridView1.Rows[n].Cells["uaddress"].Value = item["Address"].ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"UPDATE [usertab] SET Name = '" + textBox2.Text + "',[Phone] = '" + textBox3.Text + "',[Address] = '" + textBox4.Text + "' WHERE [UserId] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("User Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"DELETE FROM [usertab] WHERE [UserId] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("User Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        private void User_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
