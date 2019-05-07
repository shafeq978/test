using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class BulanikSayi
    {
        string _uyeAdi;
        double _bulanikCikis;

        public BulanikSayi(string UyeAdi, double deger)
        {
            _uyeAdi = UyeAdi;
            _bulanikCikis = deger;
        }

        public string UyeAdi
        {
            get { return _uyeAdi; }
        }

        public double BulanikDeger
        {
            get { return _bulanikCikis; }
            set { _bulanikCikis = value; }
        }

        public override string ToString()
        {
            return UyeAdi + " ---> " + BulanikDeger.ToString();
        }
      

    }
}
