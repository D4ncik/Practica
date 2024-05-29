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
    public partial class camere : UserControl
    {
        public camere()
        {
            InitializeComponent();
        }
        public Bunifu.UI.WinForms.BunifuDataGridView DataGridView
        {
            get { return bunifuDataGridView2; }
        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadData()
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "SELECT * FROM camera"; // Înlocuiește cu numele tabelului tău

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
        private void camere_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "SELECT * FROM camera"; // Înlocuiește cu numele tabelului tău

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
            AddCamera addCamera = new AddCamera();
            addCamera.BringToFront();
            addCamera.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            if (bunifuDataGridView2.SelectedRows.Count > 0)
            {
                // Obține ID-ul clientului selectat
                int clientId = Convert.ToInt32(bunifuDataGridView2.SelectedRows[0].Cells["iDDataGridViewTextBoxColumn"].Value);
                string query = "DELETE FROM camera WHERE ID = @ID";

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
                                MessageBox.Show("Camera a fost stearsa cu succes !.");
                                LoadData();
                                bunifuDataGridView2.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("Nu sa putut sterge camera.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la ștergerea camerei: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecteaza o camera pentru a o șterge.");
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuDataGridView2.SelectAll();
            DataObject copydata = bunifuDataGridView2.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application con = new Microsoft.Office.Interop.Excel.Application();
            con.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            object miseddata = System.Reflection.Missing.Value;
            workbook = con.Workbooks.Add(miseddata);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1,1];
            xlr.Select();
            worksheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
    }
}
