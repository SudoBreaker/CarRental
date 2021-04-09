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

namespace CarRental.UserControls
{
    public partial class Password : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user-pc\Desktop\CarRental\CarRental\CarRentalDatabase.mdf;Integrated Security=True");
        public Password()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Employee],[dbo].[Job] WHERE Surname = '" + textBox4.Text + "' AND Password = '" + textBox1.Text + "' AND Job.JobCode = Employee.JobCode", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           
            if(dt.Rows[0][0].ToString() == "1")
            {
                if(textBox2.Text == textBox3.Text)
                {
                    SqlCommand cc = new SqlCommand("UPDATE [dbo].[Employee],[dbo].[Job] set Password = '" + textBox2.Text + "' WHERE Surname = '" + textBox4.Text + "' AND Password = '" + textBox1.Text + "' AND Job.JobCode = Employee.JobCode");
                    MessageBox.Show("Password changed");
                }
                else
                {
                    MessageBox.Show("Password don't match");
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }


            
        }
    }
}
