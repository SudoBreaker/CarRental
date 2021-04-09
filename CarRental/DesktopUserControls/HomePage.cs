using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.UserControls
{
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private int imageNumber = 1;

        private void LoadNextImage()
        {
            if(imageNumber == 10)
            {
                imageNumber = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"Images\{0}.jpg",imageNumber);
            imageNumber++;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }
    }
}
