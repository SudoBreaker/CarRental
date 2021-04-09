using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarRental.SupervisorUserControls
{
    public partial class AddCar : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user-pc\Desktop\CarRental\CarRental\CarRentalDatabase.mdf;Integrated Security=True");
        public AddCar()
        {
            InitializeComponent();
        }

        private void CarType_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [dbo].[Car] (RegNo,Availiability,ColourCode,AgencyCode,CTCode) VALUES ('" + textBox1.Text + "','" + comboBox5.Text + "','" + comboBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            //dateTimePicker1.Text = "";
            MessageBox.Show("Car Added");
            display_data();
        }

        public void display_data()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Car]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM [dbo].[Car] WHERE RegNo = ('" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            display_data();
            MessageBox.Show("Car Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE [dbo].[Client] SET Availiability = ('" + comboBox5.Text + "'), ColourCode = ('" + comboBox4.Text + "'), AgencyCode = ('" + comboBox1.Text + "'), CTCode = ('" + comboBox2.Text + "') WHERE RegNo = ('" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            display_data();
            MessageBox.Show("Car Updated");
        }
    }
}
