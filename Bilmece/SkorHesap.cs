using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilmece
{
    class SkorHesap
    {
        public static double Skor_Hesap(double Bilinen_Bilmece, int pas_hak)
        {
            double Skor = ((Bilinen_Bilmece * 100) - (pas_hak * 20));
            if (Skor < 0)
            {
                Skor = 0;
            }
            return Math.Round(Skor);
        }
    }
}
