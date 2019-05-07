using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class KuralIslemi
    {
        List<Kural> _kurallar;
        List<BulanikDizi> _diziler;
        Ayarlar _ayarlar;
        List<int> tetiklenenKurallar;

        #region Constructor
        public KuralIslemi(Ayarlar ayar, List<Kural> kurallar, List<BulanikDizi> diziler)
        {
            _kurallar = kurallar;
            _diziler = diziler;
            _ayarlar = ayar;
            tetiklenenKurallar = new List<int>();
        }
        #endregion

        #region Getter & Setter
        public List<int> TetiklenenKurallar
        {
            get { return tetiklenenKurallar; }
        }
        #endregion

        #region Yardimci Metotlar

        private BulanikDizi BulanikDegiskenIleAra(string deger)
        {
            return _diziler.Find(delegate(BulanikDizi b) { return b.Degisken == deger; });
        }

        private double MinimumuBul(List<double> degerler)
        {
            double min = degerler[0];
            for (int i = 1; i < degerler.Count; i++)
            {
                if (degerler[i] < min)
                {
                    min = degerler[i];
                }
            }
            return min;
        }

        private double CarpimiAl(List<double> degerler)
        {
            double max = 1;
            for (int i = 0; i < degerler.Count; i++)
            {
                    max = degerler[i]*max;
            }
            return max;
        }

        private double Islem(double a, double b)
        {
             if (a > b) { return a; }
             return b;
        }

        private double Lojik(List<double> pts)
        {
            if (_ayarlar.Lojik == BaglantiMetodu.Min)
            {
                return MinimumuBul(pts);
            }
            else if (_ayarlar.Lojik == BaglantiMetodu.Carpim)
            {
                return CarpimiAl(pts);
            }
            return 0;
        }

        private double KuralDegeriBul(Kural kural)
        {
            List<double> kuralDegerleri = new List<double>();

            List<KuralItem> girisler = kural.GirisKurallari;

            for (int i = 0; i < girisler.Count; i++)
            {
                BulanikDizi dizi = BulanikDegiskenIleAra(girisler[i].Degisken);
                if (dizi != null)
                {
                    BulanikSayi sayi = dizi.UyelikDegeriyleAra(girisler[i].UyelikDegeri);
                    if (sayi != null)
                    {
                        kuralDegerleri.Add(sayi.BulanikDeger);
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            return Lojik(kuralDegerleri);
        }

        #endregion



        public List<BulanikDizi> KurallariUygula()
        {
            List<BulanikDizi> CikisDizileri = new List<BulanikDizi>();

            for (int i = 0; i < _kurallar.Count; i++)
            {
                List<KuralItem> cikisKurallari = _kurallar[i].CikisKurallari;
               double tetiklemeGucu = KuralDegeriBul(_kurallar[i]);
                if (tetiklemeGucu >= 0)
                {
                    tetiklenenKurallar.Add(i+1);
                    for (int j = 0; j < cikisKurallari.Count; j++)
                    {
                        string degis = cikisKurallari[j].Degisken;
                        if (CikisDizileri.Exists(delegate(BulanikDizi f) { return f.Degisken == degis; }))
                        {
                            int index = CikisDizileri.FindIndex(delegate(BulanikDizi f) { return f.Degisken == degis; });
                            string uye = cikisKurallari[j].UyelikDegeri;
                            if (CikisDizileri[index].Dizi.Exists(delegate(BulanikSayi n) { return n.UyeAdi == uye; }))
                            {
                                int index2 = CikisDizileri[index].Dizi.FindIndex(delegate(BulanikSayi n) { return n.UyeAdi == uye; });
                                CikisDizileri[index].Dizi[index2].BulanikDeger = Islem(CikisDizileri[index].Dizi[index2].BulanikDeger, tetiklemeGucu);
                            }
                            else
                            {
                                BulanikSayi num = new BulanikSayi(uye, tetiklemeGucu);
                                CikisDizileri[index].Dizi.Add(num);
                            }
                        }
                        else
                        {
                            BulanikDizi newset = new BulanikDizi(degis);
                            newset.Dizi.Add(new BulanikSayi(cikisKurallari[j].UyelikDegeri, tetiklemeGucu));
                            CikisDizileri.Add(newset);
                        }
                    }
                }
            }
            return CikisDizileri;
        }
        
       

    }
}
