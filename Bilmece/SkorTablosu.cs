using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bilmece
{
    public partial class SkorTablosu : Form
    {
        public SkorTablosu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SkorTablosu_Load(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Oyuncu Adı";
                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Name = "Oyuncu Skoru";
                dataGridView1.Columns[1].Width = 200;

                MySqlConnection Connection = new MySqlConnection("server=localhost;user id=root;database=bilmeceler");
                Connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT Isim, Skor FROM skor", Connection);
                var skor = command.ExecuteReader();
                while (skor.Read())
                {
                    dataGridView1.Rows.Add(skor[0], skor[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
