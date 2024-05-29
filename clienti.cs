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
    public partial class clienti : UserControl
    {
        public clienti()
        {
            InitializeComponent();
        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = bunifuDataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string selectedValue = selectedCell.Value.ToString();

                // Deschide fereastra dorită și setează valoarea Label-ului
                AddBooking forma = new AddBooking();
                forma.NumePersoana = selectedValue;
                forma.Show();
            }
        }

        private void clienti_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "SELECT * FROM clienti"; // Înlocuiește cu numele tabelului tău

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

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string searchName = bunifuTextBox3.Text.Trim();
            int rowIndex = -1; // Indexul rândului în care se găsește persoana căutată

            foreach (DataGridViewRow row in bunifuDataGridView2.Rows)
            {
                string cellValue = row.Cells["numeDataGridViewTextBoxColumn"].Value.ToString();

                if (cellValue.Contains(searchName))
                {
                    rowIndex = row.Index; // Salvează indexul rândului
                    row.Selected = true; // Selectează rândul găsit
                    break; // Ieși din buclă după găsirea primei corespondențe
                }
            }

            // Dacă s-a găsit un rând cu persoana căutată, defilează DataGridView-ul către acest rând
            if (rowIndex != -1)
            {
                bunifuDataGridView2.FirstDisplayedScrollingRowIndex = rowIndex;
            }
            LoadData();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.Show();
            addClient.BringToFront();
        }
        public void LoadData()
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "SELECT * FROM clienti"; // Înlocuiește cu numele tabelului tău

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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            if (bunifuDataGridView2.SelectedRows.Count > 0)
            {
                // Obține ID-ul clientului selectat
                int clientId = Convert.ToInt32(bunifuDataGridView2.SelectedRows[0].Cells["iDDataGridViewTextBoxColumn"].Value);
                string query = "DELETE FROM clienti WHERE ID = @ID";

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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la ștergerea clientului: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectează un client pentru a-l șterge.");
            }
        }
    }
}
