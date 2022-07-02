using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilmece
{
    public partial class Menü : Form
    {
        public Menü()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Oyun oyn = new Oyun();
            this.Hide();
            oyn.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SkorTablosu ST = new SkorTablosu();
            ST.ShowDialog();

        }

        private void Menü_Load(object sender, EventArgs e)
        {

        }
    }
}
