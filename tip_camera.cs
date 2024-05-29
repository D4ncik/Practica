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
    public partial class tip_camera : UserControl
    {
        public tip_camera()
        {
            InitializeComponent();
        }
        public void LoadData() {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "SELECT * FROM camera_tip"; // Înlocuiește cu numele tabelului tău

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    bunifuDataGridView4.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
                }
            }
        }
        private void tip_camera_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WINDOWS-V0NULKA\\SQLEXPRESS;Initial Catalog=Cazare_Hotel;Integrated Security=True";
            string query = "SELECT * FROM camera_tip"; // Înlocuiește cu numele tabelului tău

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    bunifuDataGridView4.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
                }
            }
        }

        private void bunifuDataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            string searchName = bunifuTextBox5.Text.Trim();
            int rowIndex = -1; // Indexul rândului în care se găsește persoana căutată

            foreach (DataGridViewRow row in bunifuDataGridView4.Rows)
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
                bunifuDataGridView4.FirstDisplayedScrollingRowIndex = rowIndex;
            }
            LoadData();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuDataGridView4.SelectAll();
            DataObject copydata = bunifuDataGridView4.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application con = new Microsoft.Office.Interop.Excel.Application();
            con.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            object miseddata = System.Reflection.Missing.Value;
            workbook = con.Workbooks.Add(miseddata);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
            xlr.Select();
            worksheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
    }
}
