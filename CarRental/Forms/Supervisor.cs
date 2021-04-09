using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Forms
{
    public partial class Supervisor : Form
    {
        public Supervisor()
        {
            InitializeComponent();
        }

        private void Supervisor_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carType1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            homeS1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new_Employee1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addCar1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            report1.BringToFront();
        }
    }
}
