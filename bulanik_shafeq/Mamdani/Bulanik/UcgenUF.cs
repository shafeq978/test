using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class UcgenUF:UyelikFonksiyonu
    {
        public UcgenUF(string isim, double a, double b, double c)
            : base()
        {
            this.Isim = isim;
            Parametreler.Add(a); Parametreler.Add(b); Parametreler.Add(c);
            aralik.Add(Parametreler[0]);
            aralik.Add(Parametreler[Parametreler.Count - 1]);

            this.AgirlikMerkeziniHesapla();
            this.alaniHesapla();
        }

        public override double CikisiAl(double xDegeri)
        {
            if (xDegeri >= Parametreler[0] && xDegeri <= Parametreler[1])
            {
                return (xDegeri - Parametreler[0]) / (Parametreler[1] - Parametreler[0]);
            }
            else if (xDegeri >= Parametreler[1] && xDegeri <= Parametreler[2])
            {
                return (Parametreler[2] - xDegeri) / (Parametreler[2] - Parametreler[1]);
            }
            return -1;
        }
    }
}
