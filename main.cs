using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
namespace cazare
{
    public partial class main : UserControl
    {
        private GMapOverlay Overlay;
        public main()
        {
            InitializeComponent();
            Overlay = new GMapOverlay();
        }

        private void bunifuHSlider1_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            bunifuHSlider1.Minimum = 1;
            bunifuHSlider1.Maximum = 2000;

            if (bunifuHSlider1.Value <= 2000)
            {

                label6.Text = bunifuHSlider1.Value.ToString();
            }
        }


        private void gMapControl1_Load_1(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 16;
            gMapControl1.Zoom = 12;
            gMapControl1.Position = new GMap.NET.PointLatLng(47.0105, 28.8638);
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            gMapControl1.CanDragMap = true;
            gMapControl1.ShowCenter = false;
            gMapControl1.ShowTileGridLines = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void room11_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
