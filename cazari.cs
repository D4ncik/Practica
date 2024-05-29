using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static cazare.DataPret;

namespace cazare
{
    public partial class cazari : UserControl
    {
        public cazari()
        {
            InitializeComponent();
        }
        public Bunifu.UI.WinForms.BunifuDataGridView DataGridView
        {
            get { return bunifuDataGridView2; }
        }

        public void LoadData()
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "SELECT * FROM cazari"; // Înlocuiește cu numele tabelului tău

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    bunifuDataGridView2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
                }
            }
        }
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            if (bunifuDataGridView2.SelectedRows.Count > 0)
            {
                // Obține ID-ul clientului selectat
                int clientId = Convert.ToInt32(bunifuDataGridView2.SelectedRows[0].Cells["iDDataGridViewTextBoxColumn"].Value);
                string query = "DELETE FROM cazari WHERE ID = @ID";

                string nume1 = Convert.ToString(bunifuDataGridView2.SelectedRows[0].Cells["cameraDataGridViewTextBoxColumn"].Value);
                string query1 = "UPDATE camera\r\nSET starea = 'disponibil'\r\nWHERE nume = @camera";

                string query2 = "UPDATE camera_tip\r\nSET Ocupata = '1',Disponibila = '1'\r\nWHERE Nume = 'Familie'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Adaugă parametrul pentru interogare
                            command.Parameters.AddWithValue("@ID", clientId);

                            // Execută interogarea de ștergere
                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Clientul a fost șters cu succes.");
                                LoadData();
                                bunifuDataGridView2.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("Nu s-a putut șterge clientul.");
                            }
                        }
                        using (SqlCommand command = new SqlCommand(query1, connection))
                        {
                            // Adaugă parametrul pentru interogare
                            command.Parameters.AddWithValue("@camera", nume1);

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
                        using (SqlCommand command = new SqlCommand(query2, connection))
                        {


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
            }
            else
            {
                MessageBox.Show("Selectează o camera pentru a o șterge.");
            }
        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cazari_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "SELECT * FROM cazari"; // Înlocuiește cu numele tabelului tău

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    bunifuDataGridView2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
                }
            }
        }

        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            DateTime data2 = bunifuDatePicker2.Value.Date;

            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "SELECT * FROM cazari WHERE  Data_out=@data2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@data2", SqlDbType.Date).Value = data2;
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        bunifuDataGridView2.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la cautarea datelor: " + ex.Message);
                }
            }
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string nr_zile = bunifuTextBox1.Text.ToString();
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";

            if (bunifuDataGridView2.SelectedRows.Count > 0)
            {
                // Obțineți rândul selectat
                DataGridViewRow selectedRow = bunifuDataGridView2.SelectedRows[0];
                string client = Convert.ToString(selectedRow.Cells["clientDataGridViewTextBoxColumn"].Value);
                DateTime dataIn = Convert.ToDateTime(selectedRow.Cells["datainDataGridViewTextBoxColumn"].Value);
                string Pret = Convert.ToString(selectedRow.Cells["pretDataGridViewTextBoxColumn"].Value); ;
                int numarZile;

                // Verificați dacă TextBox-ul conține un număr valid de zile
                if (int.TryParse(nr_zile, out numarZile))
                {
                    // Calculați noul data_out
                    DateTime dataOut = dataIn.AddDays(numarZile).Date;

                    // Construiți interogarea de actualizare
                    string query = "UPDATE cazari " +
                                   "SET zile = @NumarZile, Data_out = @DataOut ,Pret = @Pret + 100 " +
                                   "WHERE client = @Client"; // Schimbați "numar_zile" și "ClientID" cu numele coloanelor dvs.

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Adăugați parametrii interogării
                                command.Parameters.AddWithValue("@NumarZile", numarZile);
                                command.Parameters.AddWithValue("@DataOut", dataOut);
                                command.Parameters.AddWithValue("@Client", client);
                                command.Parameters.AddWithValue("@Pret", Pret);
                                // Executați interogarea de actualizare
                                int result = command.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    MessageBox.Show("Datele au fost actualizate cu succes.");
                                    LoadData();
                                    bunifuDataGridView2.Refresh();
                                }
                                else
                                {
                                    MessageBox.Show("Nu s-a putut actualiza înregistrarea.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Eroare: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Introduceți un număr valid de zile.");
                }
            }
            else
            {
                MessageBox.Show("Selectați un rând din tabel.");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CalculeazaPreturi();
            DataPret pret = new DataPret();
            pret.setData(this);
            pret.Show();
            pret.BringToFront();

        }
 
       public decimal PretMin { get; private set; }
        public decimal PretMax { get; private set; }
        public decimal PretAvg { get; private set; }
        private void CalculeazaPreturi() {
            if (bunifuDataGridView2.Rows.Count > 0)
            {
                try
                {
                    var preturi = bunifuDataGridView2.Rows.Cast<DataGridViewRow>().Where(row => row.Cells["pretDataGridViewTextBoxColumn"].Value != null)
                        .Select(row => Convert.ToDecimal(row.Cells["pretDataGridViewTextBoxColumn"].Value)).ToList();

                    if (preturi.Any())
                    {

                        PretMin = preturi.Min();
                        PretMax = preturi.Max();
                        PretAvg = preturi.Average();
                      
                        
                    }
                    else
                    {
                        throw new InvalidOperationException("Nu există prețuri disponibile.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la calcularea prețurilor: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Nu există date în tabel.");
            }
        }
    }
    }
