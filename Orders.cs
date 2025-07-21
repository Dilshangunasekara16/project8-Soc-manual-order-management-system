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
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"INSERT INTO [inventrydb].dbo.[ordertab] ([OrderId],[CustomerId],[Quantity],[Price])
            VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";

            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Order Successfully Accepted", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        public void ShowData()
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventrydb].dbo.[ordertab]", con);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in table.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["orid"].Value = item["OrderId"].ToString();
                dataGridView1.Rows[n].Cells["cid"].Value = item["CustomerId"].ToString();
                dataGridView1.Rows[n].Cells["cquantity"].Value = item["Quantity"].ToString();
                dataGridView1.Rows[n].Cells["cprice"].Value = item["Price"].ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"UPDATE [ordertab] SET CustomerId = '" + textBox2.Text + "',[Quantity] = '" + textBox3.Text + "',[Price] = '" + textBox4.Text + "' WHERE [OrderId] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Order Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"DELETE FROM [ordertab] WHERE [OrderId] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Order Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
