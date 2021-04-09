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
    public partial class CarType : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user-pc\Desktop\CarRental\CarRental\CarRentalDatabase.mdf;Integrated Security=True");
        public CarType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [dbo].[CarType] (CTCode,Make,Model,EngineSize,RentalTariff,Aircon,Automatic,FuelType) VALUES ('" + textBox8.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox1.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
           
            textBox8.Text = "";
            //dateTimePicker1.Text = "";
            MessageBox.Show("CarType Added");
            display_data();
        }
        public void display_data()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [CarType]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE [dbo].[CarType] SET Make = ('" + textBox1.Text + "'), Model = ('" + textBox3.Text + "'), EngineSize = ('" + textBox2.Text + "'), RentalTariff = ('" + textBox5.Text + "'),Aircon = ('" + comboBox1.Text + "'), Automatic = ('" + comboBox2.Text + "'), FuelType = ('" + comboBox3.Text + "') WHERE CTCode = ('" + textBox8.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox8.Text = "";
            display_data();
            MessageBox.Show("CarType Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM [dbo].[CarType] WHERE CTCode = ('" + textBox8.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox8.Text = "";
            display_data();
            MessageBox.Show("CarType Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display_data();
        }
    }
}
