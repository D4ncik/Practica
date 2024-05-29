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
    public partial class room2 : UserControl
    {
        public room2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
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
