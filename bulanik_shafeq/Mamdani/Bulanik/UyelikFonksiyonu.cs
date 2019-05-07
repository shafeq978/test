using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public abstract class UyelikFonksiyonu
    {
        private string _label;
        private List<double> _noktalar = new List<double>();
        private double _alan;
        private double _maxY = 1;
        private double _agirlikMerkezi;
        protected List<double> aralik = new List<double>();

        #region Setter & Getter
        public string Isim
        {
            get { return _label; }
            set { _label = value; }
        }

        public List<double> Aralik
        {
            get { return aralik; }
        }

        public double AgirlikMerkezi
        {
            get { return _agirlikMerkezi; }
        }

        public double Alan
        {
            get { return _alan; }
        }

        public List<double> Parametreler
        {
            get { return _noktalar; }
            set { _noktalar = value; }
        }

        public double MaxY
        {
            get { return _maxY; }
            set { _maxY = value; }
        }

        #endregion

        #region abstract Metotlar
        public abstract double CikisiAl(double xDegeri);
        #endregion

        #region Yardimci Metotlar
        protected void AgirlikMerkeziniHesapla()
        {
            double adimSayisi = 20;
            double baslangic = this.Aralik[0];
            double bitis = this.Aralik[1];
            double adim = (bitis - baslangic) / (adimSayisi - 1);
            double paytoplami = 0;
            double paydatoplami = 0;

                for (double i = baslangic; i < bitis; i = adim + i)
                {
                    double deger = this.CikisiAl(i);
                    if (deger >= 0)
                    {
                            paytoplami = deger * i + paytoplami;
                            paydatoplami = deger + paydatoplami;
                    }
                }
              _agirlikMerkezi = (paytoplami / paydatoplami);
          }

        protected void alaniHesapla()
        {
            _alan = aralik[1] - aralik[0];
        }

        #endregion
      }
}
