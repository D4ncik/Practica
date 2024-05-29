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
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }

        private void bunifuProgressBar1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuProgressBar.ProgressChangedEventArgs e)
        {

        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }
        int start = 0;


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            start += 10;
            bunifuGradientPanel2.Width = start;
            if (bunifuGradientPanel2.Width == 400)
            {
                bunifuGradientPanel2.Width = 400;
                timer1.Stop();
                timer2.Stop();
                this.Hide();
                
                AdminRegister register = new AdminRegister();
                register.Show();
                register.BringToFront();
                
                /*
                Form1 form = new Form1();
                form.Show();
                form.BringToFront();
                */
               
            }
        }

        private void Load_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            timer2.Interval = 500;
            timer2.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel2_Click(object sender, EventArgs e)
        {

        }

        int start2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            start2++;
            if (start2 > 4) // Resetam numarul punctelor dupa al treilea punct
            {
                start2 = 1;
            }

            label3.Hide();
            label4.Hide();
            label5.Hide();
            switch (start2)
            {
                case 1:
                    label3.Show();
                    break;
                case 2:
                    label3.Show();
                    label4.Show();
                    break;
                case 3:
                    label3.Show();
                    label4.Show();
                    label5.Show();
                    break;
                case 4:
                    label3.Hide();
                    break;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
