using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cazare
{
    public partial class AdminRegister : Form
    {
        public AdminRegister()
        {
            InitializeComponent();
        }
        private System.Drawing.Image originalImage;
        private System.Drawing.Image changedImage;
        private void AdminRegister_Load(object sender, EventArgs e)
        {
            originalImage = bunifuPictureBox1.Image;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)

        {
            if (bunifuPictureBox1.Image != originalImage)
            {
                if (!string.IsNullOrWhiteSpace(bunifuTextBox1.Text) && !string.IsNullOrEmpty(bunifuTextBox2.Text) && !string.IsNullOrEmpty(bunifuTextBox3.Text) && !string.IsNullOrEmpty(bunifuTextBox4.Text))
                {

                    if (bunifuTextBox3.Text == bunifuTextBox4.Text)
                    {
                        this.Close();
                       
                        Form1 form = new Form1();
                    
                        changedImage = bunifuPictureBox1.Image;
                        form.UpdatePictureBoxImage(changedImage);
                        form.username1(bunifuTextBox1.Text);
                        form.Show();
                        form.BringToFront();
                        string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
                        string query = "INSERT INTO admin (Username,Email,Pasword,ImageUser) VALUES (@Username,@Email,@Pasword,@ImageUser)";
                        byte[] imageData;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bunifuPictureBox1.Image.Save(ms, bunifuPictureBox1.Image.RawFormat);
                            imageData = ms.ToArray();
                        }
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    // Adaugă parametrii pentru interogare
                                    command.Parameters.AddWithValue("@Username", bunifuTextBox1.Text.Trim());
                                    command.Parameters.AddWithValue("@Email", bunifuTextBox2.Text.Trim());
                                    command.Parameters.AddWithValue("@Pasword", bunifuTextBox3.Text.Trim());
                                    command.Parameters.AddWithValue("@ImageUser", imageData);
                                    int result = command.ExecuteNonQuery();

                                    if (result > 0)
                                    {
                                        MessageBox.Show("Adminul a fost adaugat cu succes !");
                                   
                                        this.Close();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Nu s-a putut adăuga adminul.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Eroare la adăugarea adminului: " + ex.Message);
                            }
                        }
                        bunifuTextBox1.Clear(); bunifuTextBox2.Clear(); bunifuTextBox3.Clear();


                    }
                    else
                        MessageBox.Show("Parolele nu coincid !");
                }
            
                else
                    MessageBox.Show("Introduceti toate datele necesare !");
            }
            else
                MessageBox.Show("Selectati o poza de a dumneavoastra !");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                bunifuPictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            AdminLogin login = new AdminLogin();
            login.Show();
            login.BringToFront();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
