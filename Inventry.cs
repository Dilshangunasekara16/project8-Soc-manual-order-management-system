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
    public partial class Inventry : Form
    {
        public Inventry()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"INSERT INTO [inventrydb].dbo.[invtab] ([ProductId],[ProductName],[CustomerName],[Quantity],[Price],[Date])
            VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "')";

            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Stock Successfully Added", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        public void ShowData()
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventrydb].dbo.[invtab]", con);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in table.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["pid"].Value = item["ProductId"].ToString();
                dataGridView1.Rows[n].Cells["pname"].Value = item["ProductName"].ToString();
                dataGridView1.Rows[n].Cells["cname"].Value = item["CustomerName"].ToString();
                dataGridView1.Rows[n].Cells["cquantity"].Value = item["Quantity"].ToString();
                dataGridView1.Rows[n].Cells["cprice"].Value = item["Price"].ToString();
                dataGridView1.Rows[n].Cells["cdate"].Value = Convert.ToDateTime(item["Date"].ToString()).ToString("dd/MM/yyyy");
            }

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"UPDATE [invtab] SET ProductName = '" + textBox2.Text + "',[CustomerName] = '" + textBox3.Text + "',[Quantity] = '" + textBox4.Text + "',[Price] = '" + textBox5.Text + "' WHERE [ProductId] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Stock Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = MSI; Initial Catalog = inventrydb; Integrated Security = True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"DELETE FROM [invtab] WHERE [ProductId] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Stock Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        private void Inventry_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
