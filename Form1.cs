using GMap.NET.WindowsForms;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.BunifuCheckBox.Transitions;

namespace cazare
{
    public partial class Form1 : Form
    {
        private GMapOverlay Overlay;
        public Form1()
        {
            InitializeComponent();
            Overlay  = new GMapOverlay();
        }

        public void ShowCamere1()
        {
            camere1.Visible = true;
            camere1.Show();
            camere1.BringToFront();
            
        }
        public void UpdatePictureBoxImage(System.Drawing.Image image)
        {
            bunifuPictureBox3.Image = image;
        }
        public void username1(string name)
        {
            
        }
        public void Refresh()
        {
            clienti1.Refresh();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cazare_HotelDataSet8.cazari' table. You can move, or remove it, as needed.
            this.cazariTableAdapter1.Fill(this.cazare_HotelDataSet8.cazari);
        
            // TODO: This line of code loads data into the 'cazare_HotelDataSet3.camera' table. You can move, or remove it, as needed.
            this.cameraTableAdapter2.Fill(this.cazare_HotelDataSet3.camera);
            // TODO: This line of code loads data into the 'cazare_HotelDataSet2.camera' table. You can move, or remove it, as needed.
            this.cameraTableAdapter1.Fill(this.cazare_HotelDataSet2.camera);
            // TODO: This line of code loads data into the 'cazare_HotelDataSet1.camera' table. You can move, or remove it, as needed.
            this.cameraTableAdapter.Fill(this.cazare_HotelDataSet1.camera);
            // TODO: This line of code loads data into the 'cazare_HotelDataSet.clienti' table. You can move, or remove it, as needed.
            this.clientiTableAdapter.Fill(this.cazare_HotelDataSet.clienti);
            timer1.Start();
          
            
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

      

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
            camere1.Show();
            camere1.BringToFront();
      
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            cazari1.Show();
            cazari1.BringToFront();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

            main1.Show();
            main1.BringToFront();
              
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

  
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            clienti1.Show();
            clienti1.BringToFront();
       }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            
            tip_camera1.Show();
            tip_camera1.BringToFront();
        
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

