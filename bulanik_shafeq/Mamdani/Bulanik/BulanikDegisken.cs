using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class BulanikDegisken
    {
        private string _label;
        private List<double> _aralik;
        private List<UyelikFonksiyonu> _fonks;
        private GirisCikisTipi _tip;

        #region Constructor
        public BulanikDegisken(string isim, GirisCikisTipi tip)
        {
            _label = isim;
            _aralik = new List<double>(2);
            _fonks = new List<UyelikFonksiyonu>();
            _tip = tip;
        }
        #endregion

        #region Setter & Getter
        public string Isim
        {
            get { return _label; }
            set { _label = value; }
        }

        public List<double> Aralik
        {
            get { return _aralik; }
            set { _aralik = value; }
        }

        public GirisCikisTipi Tip
        {
            get { return _tip; }
        }

        public List<UyelikFonksiyonu> UFler
        {
            get { return _fonks; }
        }
        #endregion

        #region Metotlar
        public void araligiAyarla(double baslangic, double bitis)
        {
            Aralik.Add(baslangic);
            Aralik.Add(bitis);
        }

        public UyelikFonksiyonu UyelikFonksiyonunuGetir(string isim)
        {
            return _fonks.Find(delegate(UyelikFonksiyonu uf) { return uf.Isim == isim; });
        }

        public void UfEkle(UyelikFonksiyonu uf)
        {
            if (uf != null)
            {
                _fonks.Add(uf);
            }
        }
        #endregion
    }

    public enum GirisCikisTipi
    {
        Giris = 0,
        Cikis = 1
    };

}
