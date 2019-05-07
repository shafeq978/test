using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class YamukUF:UyelikFonksiyonu
    {
        public YamukUF(string isim, double a, double b, double c, double d)
            :base()
        {
            this.Isim = isim;
            Parametreler.Add(a); Parametreler.Add(b);
            Parametreler.Add(c); Parametreler.Add(d);

            aralik.Add(Parametreler[0]);
            aralik.Add(Parametreler[Parametreler.Count - 1]);

            this.AgirlikMerkeziniHesapla();
            this.alaniHesapla();
        }

        public override double CikisiAl(double xDegeri)
        {
            if ( (xDegeri >= Parametreler[0]) && (xDegeri <= Parametreler[1]) )
            {
                return (xDegeri - Parametreler[0] ) / ( Parametreler[1] - Parametreler[0] );
            }
            else if ( (xDegeri >= Parametreler[1]) && (xDegeri <= Parametreler[2]) )
            {
                return MaxY;
            }
            else if ( (xDegeri >= Parametreler[2]) && (xDegeri <= Parametreler[3]) )
            {
                return ( Parametreler[3] - xDegeri ) / ( Parametreler[3] - Parametreler[2] );
            }
            return -1;
        }
    }
}
