using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cazare
{
    public partial class tipcamera : Form
    {
        public tipcamera()
        {
            InitializeComponent();
        }

        private void bunifuPictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void tipcamera_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cazare_HotelDataSet6.camera_tip' table. You can move, or remove it, as needed.
            this.camera_tipTableAdapter.Fill(this.cazare_HotelDataSet6.camera_tip);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
