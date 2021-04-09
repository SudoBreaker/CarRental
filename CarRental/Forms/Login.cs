using CarRental.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CarRental
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user-pc\Desktop\Files\CarRental\CarRental\CarRentalDatabase.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user-pc\Desktop\Files\CarRental\CarRental\CarRentalDatabase.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Employee],[dbo].[Job] WHERE Surname ='" + textBox2.Text + "' AND Password ='" + textBox1.Text + "' AND Job.JobCode = Employee.JobCode", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            string cmbItemValue = comboBox1.SelectedItem.ToString();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["JobDesc"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("You are login as " + dt.Rows[i][2]);

                        if (comboBox1.SelectedIndex == 0)
                        {
                            Supervisor obj = new Supervisor();
                            obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            Desktop obj = new Desktop();
                            obj.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong User");
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong password or username");
            }

            if(string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter your surname");
            }
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter your password");
            }
            if(string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please enter your Usertype");
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register obj = new Register();
            obj.Show();
            this.Hide();
        }
    }
}
