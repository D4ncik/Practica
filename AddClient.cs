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
    public partial class AddClient : Form
    {
   
        public AddClient()
        {
            InitializeComponent();
          
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
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
            string query = "INSERT INTO clienti (Nume, Telefon, Email, Genul,Categorie) VALUES (@Nume, @Telefon, @Email,@Genul,@Categorie)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adaugă parametrii pentru interogare
                        command.Parameters.AddWithValue("@Nume", bunifuTextBox1.Text.Trim());
                        command.Parameters.AddWithValue("@Telefon", bunifuTextBox2.Text.Trim());
                        command.Parameters.AddWithValue("@Email", bunifuTextBox3.Text.Trim());
                        command.Parameters.AddWithValue("@Genul", comboBox1.Text.Trim());
                        command.Parameters.AddWithValue("@Categorie", comboBox2.Text.Trim());
                        // Execută interogarea de inserare
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Message mesaj = new Message();
                            mesaj.Show();
                            mesaj.BringToFront();
                            clienti client = new clienti();
                            client.LoadData();
                            client.Refresh();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nu s-a putut adăuga clientul.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la adăugarea clientului: " + ex.Message);
                }
            }
            bunifuTextBox1.Clear(); bunifuTextBox2.Clear(); bunifuTextBox3.Clear();
            
         }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
