using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Bilmece
{
    public partial class Oyun : Form
    {
        public Oyun()
        {
            InitializeComponent();
        }

        double skor;
        ErrorProvider ep = new ErrorProvider();
        Random rnd = new Random();
        int Bilmece_Sayisi;
        double Bilinen_Bilmece = 0;
        int Soru_Adet = 0;
        string cevap = "";
        int Pas_Hak = 3;
        List<int> Karisik_Sayi = new List<int>();

        private void YeniBilmece()
        {
            MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=bilmeceler");
            MSConnection.Open();

            // Bilmece Berlirleme
            MySqlCommand MSC = new MySqlCommand("SELECT `Bilmece` FROM `bilmece_ve_cevap` WHERE BilmeceNumara=" + Karisik_Sayi[Soru_Adet], MSConnection);
            var secili_bilmece = MSC.ExecuteReader();
            secili_bilmece.Read();

            // Bilmece Yazdırma
            label1.Text = secili_bilmece[0].ToString();
            MSConnection.Close();

            // Cevap tutma
            MSConnection.Open();
            MSC = new MySqlCommand("SELECT `Cevap` FROM `bilmece_ve_cevap` WHERE BilmeceNumara=" + Karisik_Sayi[Soru_Adet], MSConnection);
            var secili_bilmece_cevap = MSC.ExecuteReader();
            secili_bilmece_cevap.Read();
            cevap = secili_bilmece_cevap[0].ToString().ToLower();
            MSConnection.Close();
            Soru_Adet++;
        }
        private void Sifirla(DialogResult DR)
        {

            try
            {
                if (DR == DialogResult.No)
                {
                    DialogResult dr = MessageBox.Show("Skorunuz Kaydedilsin mi ?", "Dikkat", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Kayıt kyt = new Kayıt();
                        kyt.Skor = skor;
                        kyt.ShowDialog();
                    }



                    Menü mnu = new Menü();
                    this.Hide();
                    mnu.ShowDialog();
                    this.Close();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Skorunuz Kaydedilsin mi ?", "Dikkat", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Kayıt kyt = new Kayıt();
                        kyt.Skor = skor;
                        kyt.ShowDialog();
                    }
                    Bilinen_Bilmece = 0;
                    Soru_Adet = 0;
                    Pas_Hak = 3;
                    label4.Text = "Pas Hakkı: " + Pas_Hak;
                    dk = 1;
                    sn = 60;
                    timer1.Start();
                    Karisik_Sayi.Clear();
                    for (int i = 0; i < Bilmece_Sayisi;)
                    {
                        int rast_sayi = rnd.Next(1, Bilmece_Sayisi + 1);
                        if (!Karisik_Sayi.Contains(rast_sayi))
                        {
                            Karisik_Sayi.Add(rast_sayi);
                            i++;
                        }
                    }
                    YeniBilmece();
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {


            try
            {
                // Veri tabanından bilmece çekme
                MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=bilmeceler");
                MSConnection.Open();

                MySqlCommand MSC = new MySqlCommand("SELECT COUNT(BilmeceNumara)FROM bilmece_ve_cevap", MSConnection);
                var bilmece_adet = MSC.ExecuteReader();
                bilmece_adet.Read();

                // Bilmece Sayısı Belirleme
                Bilmece_Sayisi = Convert.ToInt32(bilmece_adet[0]);
                MSConnection.Close();

                // Karışık Sayı Dizisi Oluşturma
                for (int i = 0; i < Bilmece_Sayisi;)
                {
                    int rast_sayi = rnd.Next(1, Bilmece_Sayisi + 1);
                    if (!Karisik_Sayi.Contains(rast_sayi))
                    {
                        Karisik_Sayi.Add(rast_sayi);
                        i++;
                    }
                }

                YeniBilmece();



                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Doğru/Yanlış Kontrol
                if (textBox1.Text.ToLower() == cevap)
                {
                    Bilinen_Bilmece++;
                    Debug.Print("Tebrikler!");
                    label3.Text = "Bilinen Bilmece: " + Bilinen_Bilmece;
                    YeniBilmece();
                }

                // Yakınlık Kontrol
                else if ((cevap.Count() > 3) && (textBox1.Text.Count() >= 3))
                {
                    for (int i = 0; i < (textBox1.Text.Count() - 2); i++)
                    {

                        if (cevap.Contains(textBox1.Text.ToLower().Substring(i, 3)))
                        {
                            MessageBox.Show("Yakın!");
                            break;
                        }
                    }
                }

                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int dk = 1;
        int sn = 60;
        string Strdk;
        string Strsn;
        private void timer1_Tick(object sender, EventArgs e)
        {


            try
            {
                // Zamanlayıcı
                sn--;

                if (sn == 0 && dk != 0)
                {
                    dk--;
                    sn = 60;
                }


                // Görünüş
                if (sn < 10)
                {
                    Strsn = "0" + sn;
                }
                else
                {
                    Strsn = sn.ToString();
                }

                if (dk < 10)
                {
                    Strdk = "0" + dk;
                }
                else
                {
                    Strdk = dk.ToString();
                }

                label2.Text = "Süre: " + Strdk + ":" + Strsn;

                // Süre doldu mu (Kontrol)
                if (sn == 0 && dk == 0)
                {
                    timer1.Stop();
                    skor = SkorHesap.Skor_Hesap(Bilinen_Bilmece, 3 - Pas_Hak);
                    DialogResult DR = MessageBox.Show("Süreniz Bitti.\nBilinen Bilmece:" + Bilinen_Bilmece + " Skor:" + skor + "\nTekrar Oynamak İstiyor musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    Sifirla(DR);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (Pas_Hak == 0)
                {
                    ep.SetError(label4, "Pas Hakkınız Kalmadı!");
                }
                else
                {
                    Pas_Hak--;
                    YeniBilmece();
                    label4.Text = "Pas Hakkı: " + Pas_Hak;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
