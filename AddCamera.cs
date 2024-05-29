using Bunifu.UI.WinForms;
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
    public partial class AddCamera : Form
    {
        public AddCamera()
        {
            InitializeComponent();
        }

        private void AddCamera_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "INSERT INTO camera (Nume, Tip_Camera, Statut, Starea,Pret) VALUES (@Nume, @Tip_Camera, @Statut, @Starea,@Pret)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adaugă parametrii pentru interogare
                        command.Parameters.AddWithValue("@Nume", bunifuTextBox1.Text.Trim());
                        command.Parameters.AddWithValue("@Tip_Camera", comboBox1.Text.Trim());
                        command.Parameters.AddWithValue("@Statut", comboBox3.Text.Trim());
                        command.Parameters.AddWithValue("@Starea", comboBox2.Text.Trim());
                        command.Parameters.AddWithValue("@Pret", bunifuTextBox2.Text.Trim());
                        // Execută interogarea de inserare
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Camera a fost adaugata cu succes.");
                            
                        }
                        else
                        {
                            MessageBox.Show("Nu s-a putut adăuga camera.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la adăugarea camerei: " + ex.Message);
                }
            }
            bunifuTextBox1.Clear(); bunifuTextBox2.Clear(); bunifuTextBox3.Clear();
        }
    }
}
