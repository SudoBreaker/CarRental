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
    public partial class New_Employee : UserControl
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user-pc\Desktop\CarRental\CarRental\CarRentalDatabase.mdf;Integrated Security=True");
        public New_Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void New_Employee_Load(object sender, EventArgs e)
        {

        }

        public void display_data()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Employee]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM [dbo].[Employee] WHERE RegNo = ('" + textBox8.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            textBox8.Text = "";
            display_data();
            MessageBox.Show("Employee Deleted");
        }
    }
}
