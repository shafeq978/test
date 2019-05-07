using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class Kural
    {
        List<KuralItem> _girisKurallari;
        List<KuralItem> _cikisKurallari;
        Baglac _baglac;

        #region Constructor
        public Kural(List<KuralItem> girisler, List<KuralItem> cikislar, Baglac baglac)
        {
            _girisKurallari = girisler;
            _cikisKurallari = cikislar;
            _baglac = baglac;
        }

        public Kural() 
        {
            _girisKurallari = new List<KuralItem>();
            _cikisKurallari = new List<KuralItem>();
            _baglac = Baglac.And;
        }
        #endregion

        #region Getter & Setter
        public List<KuralItem> GirisKurallari
        {
            get { return _girisKurallari; }
        }

        public List<KuralItem> CikisKurallari
        {
            get { return _cikisKurallari; }
        }

        public Baglac Baglac
        {
            get { return _baglac; }
            set { _baglac = value; }
        }
        #endregion

        #region Metotlar

        public override string ToString()
        {
            string kural = "IF ";
            for (int j = 0; j < GirisKurallari.Count; j++)
            {
                kural = kural + GirisKurallari[j].Degisken + " is " + GirisKurallari[j].UyelikDegeri;
                if (j != GirisKurallari.Count - 1)
                {
                    kural = kural + " And ";
                }
            }
            kural = kural + " Then ";
            for (int j = 0; j < CikisKurallari.Count; j++)
            {
                kural = kural + CikisKurallari[j].Degisken + " is " + CikisKurallari[j].UyelikDegeri;
                if (j != CikisKurallari.Count - 1)
                {
                    kural = kural + " And ";
                }
            }
            return kural;
        }

        #endregion

    }

    public enum Baglac
    {
        And = 0,
        Or = 1
    };

}
