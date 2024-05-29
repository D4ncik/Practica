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
    public partial class room1 : UserControl
    {
        public room1()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            Form1 mainForm = this.FindForm() as Form1;
            if (mainForm != null)
            {
                mainForm.ShowCamere1();
            }

            
        }
    }
}
