using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class BulanikDizi
    {
        private List<BulanikSayi> _sayilar;
        private string _bulanikDegisken;

        #region Constructor
        public BulanikDizi(List<BulanikSayi> Sayi, string BulanikDegisken)
        {
            _sayilar = Sayi;
            _bulanikDegisken = BulanikDegisken;
        }

        public BulanikDizi(string BulanikDegisken)
        {
            _bulanikDegisken = BulanikDegisken;
            _sayilar = new List<BulanikSayi>();
        }

        #endregion

        #region Setter & Getter
        public List<BulanikSayi> Dizi
        {
            get { return _sayilar; }
            set { _sayilar = value; }
        }

        public string Degisken
        {
            get { return _bulanikDegisken; }
            set { _bulanikDegisken = value; }
        }
        #endregion

        #region Metotlar
        public BulanikSayi UyelikDegeriyleAra(string Deger)
        {
            return _sayilar.Find(delegate(BulanikSayi e) { return e.UyeAdi == Deger; });
        }
        #endregion
    }
}
