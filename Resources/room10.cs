using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cazare.Resources
{
    public partial class room10 : UserControl
    {
        public room10()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form1 formPrincipal = this.ParentForm as Form1;
            if (formPrincipal != null)
            {
                formPrincipal.ShowCamere1();
            }
        }
    }
}
