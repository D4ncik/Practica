using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cazare
{
    public partial class DataPret : Form
    {
        private cazari cazari;
        public DataPret()
        {
            InitializeComponent();
          
        }
        public void setData(cazari cazari) {
            this.cazari = cazari;
            actualizeaza();
        }
        private void actualizeaza() {
            if (cazari != null)
            {
                decimal pretMin = cazari.PretMin;
                decimal pretMax = cazari.PretMax;
                decimal pretAvg = cazari.PretAvg;


                label2.Text = pretAvg.ToString();
                label5.Text = pretMax.ToString();
                label6.Text = pretMin.ToString();
            }
        }
        private void label29_Click(object sender, EventArgs e)
        {

        }
   
        private void DataPret_Load(object sender, EventArgs e)
        {
           

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
