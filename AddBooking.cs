using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cazare
{
    public partial class AddBooking : Form
    {
        public AddBooking()
        {
            InitializeComponent();
        }
        public string NumePersoana
        {
            get { return label4.Text; }
            set { label4.Text = value; }
        }
        private void bunifuPictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBooking_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cazare_HotelDataSet4.disponibil' table. You can move, or remove it, as needed.
            this.disponibilTableAdapter.Fill(this.cazare_HotelDataSet4.disponibil);

        }
        public string denumirecamera;
        public string tipcamera;
        public string statut;
        public string starea;
        public string pret;
        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Asigură-te că un rând valid este selectat
            {
                DataGridViewRow selectedRow = bunifuDataGridView2.Rows[e.RowIndex];

                denumirecamera = selectedRow.Cells["numeDataGridViewTextBoxColumn"].Value.ToString();
                tipcamera = selectedRow.Cells["tipCameraDataGridViewTextBoxColumn"].Value.ToString();
                statut = selectedRow.Cells["statutDataGridViewTextBoxColumn"].Value.ToString();
                starea = selectedRow.Cells["stareaDataGridViewTextBoxColumn"].Value.ToString();
                pret = selectedRow.Cells["pretDataGridViewTextBoxColumn"].Value.ToString();
            }
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            DateTime data1 = bunifuDatePicker4.Value.Date;
            DateTime data2 = bunifuDatePicker3.Value.Date;
            string nr_camera = bunifuTextBox1.Text.ToString();
            string nume = label4.Text.ToString();

            TimeSpan dateDifference = data2 - data1;
            int nrzile = (int)dateDifference.TotalDays;
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "INSERT INTO cazari (Client, Camera, Nr_Camera, Statut,Data_in,Data_out,Pret,Zile) VALUES (@Client, @Camera, @Nr_Camera, @Statut,@Data_in,@Data_out,@Pret,@Zile)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adaugă parametrii pentru interogare
                        command.Parameters.AddWithValue("@Client", nume);
                        command.Parameters.AddWithValue("@Camera", denumirecamera);
                        command.Parameters.AddWithValue("@Nr_Camera", nr_camera);
                        command.Parameters.AddWithValue("@Statut", statut);
                        command.Parameters.AddWithValue("@Data_in", data1.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Data_out", data2.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Pret", pret);
                        command.Parameters.AddWithValue("@Zile", nrzile.ToString());
                        // Execută interogarea de inserare
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Clientul a fost inregistrat cu succes.");
                            clienti client = new clienti();
                            client.LoadData();
                            client.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Nu s-a putut inregistra clientul.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la inregistrarea clientului: " + ex.Message);
                }
            }

            if (bunifuDataGridView2.SelectedRows.Count > 0)
            {
                // Obține ID-ul clientului selectat
                string nume1 = Convert.ToString(bunifuDataGridView2.SelectedRows[0].Cells["numeDataGridViewTextBoxColumn"].Value);
                string query1 = "UPDATE camera\r\nSET starea = 'indisponibil'\r\nWHERE nume = @nume";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query1, connection))
                        {
                            // Adaugă parametrul pentru interogare
                            command.Parameters.AddWithValue("@nume", nume1);

                            // Execută interogarea de ștergere
                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                
                                camere camere = new camere();
                                camere.LoadData();
                               
                                bunifuDataGridView2.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("Nu s-a putut șterge clientul.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la ștergerea clientului: " + ex.Message);
                    }
                }
                if (bunifuDataGridView2.SelectedRows[0].Cells["tipCameraDataGridViewTextBoxColumn"].Value.ToString() == "Familie")
                {
                    string tipcamera = Convert.ToString(bunifuDataGridView2.SelectedRows[0].Cells["tipCameraDataGridViewTextBoxColumn"].Value);
                    string query2 = "UPDATE camera_tip\r\nSET Ocupata = '2',Disponibila = '0'\r\nWHERE Nume = @nume";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query2, connection))
                            {
                                // Adaugă parametrul pentru interogare
                                command.Parameters.AddWithValue("@nume", tipcamera);

                                // Execută interogarea de ștergere
                                int result = command.ExecuteNonQuery();

                                if (result > 0)
                                {
                                   
                                    tip_camera tip_camera = new tip_camera();
                                    tip_camera.LoadData();
                                    bunifuDataGridView2.Refresh();
                                }
                                else
                                {
                                    MessageBox.Show("Nu sa putut modifica tipul camerei.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Eroare la ștergerea clientului: " + ex.Message);
                        }
                    }
                }
                else if (bunifuDataGridView2.SelectedRows[0].Cells["tipCameraDataGridViewTextBoxColumn"].Value == "Familie") { 
                
                }

            }
            else
            {
                MessageBox.Show("Selectează un client pentru a-l șterge.");
            }
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
