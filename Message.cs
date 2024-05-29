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
    public partial class Message : Form
    {
        private Timer timer;
        public Message()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval =3000; 
            timer.Tick += timer1_Tick;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
        int X, Y;

        private void Message_Load(object sender, EventArgs e)
        {
            Position();
            timer.Start();
        }

        private void Position()
        {
            int latime = Screen.PrimaryScreen.WorkingArea.Width;
            int inaltime = Screen.PrimaryScreen.WorkingArea.Height;
            X = latime - this.Width;
            Y = inaltime - this.Height;
            this.Location = new Point(X, Y);
        }
    }
}
