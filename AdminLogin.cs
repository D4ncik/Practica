using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cazare
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            AdminRegister register = new AdminRegister();
            register.Show();
            register.BringToFront();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";

            string username = bunifuTextBox3.Text.ToString();
            string password = bunifuTextBox1.Text.ToString();

            string query = "SELECT COUNT(*) FROM admin WHERE Username = @Username AND Pasword = @Password";
            int count = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    count = (int)command.ExecuteScalar(); // Obține numărul de rânduri care corespund condițiilor

                    if (count > 0)
                    {
                        Form1 form = new Form1();
                        form.Show();
                        form.BringToFront();
                        this.Close();
                    }
                    else
                    {

                        MessageBox.Show("Autentificare eșuată! Username sau parolă incorectă.");
                    }
                }
            }
        }
    }
}
