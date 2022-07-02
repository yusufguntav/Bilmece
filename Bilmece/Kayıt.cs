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
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }

        public double Skor { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {

                    MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=bilmeceler");
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO skor(Isim, Skor) VALUES ('" + textBox1.Text + "'," + Skor + ")", connection);
                    command.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Kayıt_Load(object sender, EventArgs e)
        {

        }
    }
}
