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

namespace Bilmece
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ErrorProvider ep = new ErrorProvider();
        Random rnd = new Random();
        int Bilinen_Bilmece = 0;
        int Soru_Adet = 0;
        int Pas_Hak = 3;
        Dictionary<string, string> Bilmeceler = new Dictionary<string, string>() {
                {"İçime koydukların anı olur, duvardayken şık durur. Çiviyi görünce yaklaştır, ikimiz bir bütün olur.","Çerçeve" },
                {"Gece çıkar göğe, sabah saklanır bir yere. Gelirse aydınlatır, tam olursa toparlanır.","Ay" },
                {"Havlayamaz köpek değil, zıplayamaz tavşan değil. Kanadı var kuş değil, denizi sever balık değil.","Ördek" },
                {"İçi dolu pamuk. Arkanı yaslan, onu doldurduk.","Yastık" },
                {"Tarlada yeşil, markette siyah, evde kırmızı.","Çay"},
                {"Kara tavuk dalda yatar, dal kırılır yerde yatar.","Zeytin" }
            };
        List<int> Karisik_Sayi = new List<int>();

        private void Sifirla(DialogResult DR)
        {
            if (DR == DialogResult.No)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                Bilinen_Bilmece = 0;
                
                Soru_Adet = 0;
                Pas_Hak = 3;
                label4.Text = "Pas Hakkı: " + Pas_Hak;
                dk = 1;
                sn = 60;
                gecen_sure = 0;
                timer1.Start();
                Karisik_Sayi.Clear();
                for (int i = 0; i < Bilmeceler.Count();)
                {
                    int rast_sayi = rnd.Next(0, Bilmeceler.Count());
                    if (!Karisik_Sayi.Contains(rast_sayi))
                    {
                        Karisik_Sayi.Add(rast_sayi);
                        i++;
                    }
                }
                label1.Text = Bilmeceler.ElementAt(Karisik_Sayi[Soru_Adet]).Key;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            // Karışık Sayı Dizisi Oluşturma
            for (int i = 0; i < Bilmeceler.Count();)
            {
                int rast_sayi = rnd.Next(0, Bilmeceler.Count());
                if (!Karisik_Sayi.Contains(rast_sayi))
                {
                    Karisik_Sayi.Add(rast_sayi);
                    i++;
                }
            }

            // Bilmece Yazdırma
            label1.Text = Bilmeceler.ElementAt(Karisik_Sayi[Soru_Adet]).Key;

            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Doğru/Yanlış Kontrol
            if ((textBox1.Text == Bilmeceler.ElementAt(Karisik_Sayi[Soru_Adet]).Value) && Soru_Adet < (Bilmeceler.Count() - 1))
            {
                Bilinen_Bilmece++;
                Soru_Adet++;
                Debug.Print("Tebrikler!");
                label3.Text = "Bilinen Bilmece: " + Bilinen_Bilmece;
                label1.Text = Bilmeceler.ElementAt(Karisik_Sayi[Soru_Adet]).Key;
            }
            // Son Bilmeceyse
            else if ((textBox1.Text == Bilmeceler.ElementAt(Karisik_Sayi[Soru_Adet]).Value) && Soru_Adet == Bilmeceler.Count() - 1)
            {
                Bilinen_Bilmece++;
                Debug.Print("Tebrikler!");
                label3.Text = "Bilinen Bilmece: " + Bilinen_Bilmece;
                timer1.Stop();
                DialogResult DR = MessageBox.Show("Bütün Bilmeceler Bitti.\nBilinen Bilmece:" + Bilinen_Bilmece + "  Geçen Süre:" + gecen_sure + "sn\nTekrar Oynamak İstiyor musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                Sifirla(DR);
            }

            textBox1.Clear();
        }

        int gecen_sure = 0;
        int dk = 1;
        int sn = 60;
        string Strdk;
        string Strsn;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Geçen Süre
            gecen_sure++;


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

                DialogResult DR = MessageBox.Show("Süreniz Bitti.\nBilinen Bilmece:" + Bilinen_Bilmece + "  Geçen Süre:" + gecen_sure + "sn\nTekrar Oynamak İstiyor musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                Sifirla(DR);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Soru_Adet == Bilmeceler.Count() - 1)
            {
                timer1.Stop();
                DialogResult DR = MessageBox.Show("Bütün Bilmeceler Bitti.\nBilinen Bilmece:" + Bilinen_Bilmece + "  Geçen Süre:" + gecen_sure + "sn\nTekrar Oynamak İstiyor musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                Sifirla(DR);
            }
            else if (Pas_Hak == 0)
            {
                ep.SetError(label4, "Pas Hakkınız Kalmadı!");
            }
            else
            {
                Soru_Adet++;
                Pas_Hak--;
                label1.Text = Bilmeceler.ElementAt(Karisik_Sayi[Soru_Adet]).Key;
                label4.Text = "Pas Hakkı: " + Pas_Hak;
            }

        }
    }
}
