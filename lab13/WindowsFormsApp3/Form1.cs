using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MENU.mdf;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Menu", ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string query = "INSERT INTO Menu (Name,Time,Price,Category)";
            query += " VALUES (@Name,@Time,@Price,@Category)";

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("@Name", textBox1.Text);
            myCommand.Parameters.AddWithValue("@Time", Convert.ToInt32(textBox2.Text));
            myCommand.Parameters.AddWithValue("@Price", Convert.ToInt32(textBox3.Text));
            myCommand.Parameters.AddWithValue("@Category", textBox4.Text);
            // ... other parameters
            myCommand.ExecuteNonQuery();


            //command.ExecuteNonQuery();
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentCell.Value);
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from Menu where Id=@Id", connection);
            command.Parameters.Add("@Id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Update Menu Set Name=@Name,Time=@Time," +
                    "Price=@Price,Category=@Category where Id=@Id", connection);
                command.Parameters.Add("@Id", Convert.ToInt32(dataGridView1[0, i].Value));
                //string s = dataGridView1[1, i].Value.ToString();
                command.Parameters.Add("@Name", Convert.ToString(dataGridView1[1, i].Value));
                command.Parameters.Add("@Time", Convert.ToInt32(dataGridView1[2, i].Value));
                command.Parameters.Add("@Price", Convert.ToInt32(dataGridView1[3, i].Value));
                command.Parameters.Add("@Category", Convert.ToString(dataGridView1[4, i].Value));
                
                connection.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "SELECT * " +
                "FROM[Menu]" +
                "Where[Menu].Price<10";

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, connection);
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "SELECT * " +
                "FROM[Menu]" +
                "Where[Menu].Price<5 AND Menu.Time<30" ;

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, connection);
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "SELECT * " +
                "FROM[Menu]" +
                "Where Menu.Time = 30";

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, connection);
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "SELECT * FROM Menu ORDER BY Price ";

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, connection);
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }
    }
}
