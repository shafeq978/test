using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class BMK
    {

        Ayarlar _ayarlar;

        public BMK(Ayarlar ayar)
        {
            _ayarlar = ayar;
        }

        private double Centroid(List<BulanikSayi> sayilar, BulanikDegisken degisken)
        {
            double adimSayisi = 17;
            double baslangic = degisken.Aralik[0];
            double bitis = degisken.Aralik[1];
            double adim = (bitis - baslangic) / (adimSayisi - 1);
            double pay = 0;
            double payda = 0;

            for (int i = 0; i < sayilar.Count; i++)
            {
                UyelikFonksiyonu uf = degisken.UyelikFonksiyonunuGetir(sayilar[i].UyeAdi);
                for (double j = baslangic; j < bitis; j = adim + j)
                {
                    double deger = uf.CikisiAl(j);
                    if (deger > 0)
                    {
                        if (deger < sayilar[i].BulanikDeger)
                        {
                            pay = deger * j + pay;
                            payda = deger + payda;
                        }
                        else
                        {
                            pay = sayilar[i].BulanikDeger * j + pay;
                            payda = sayilar[i].BulanikDeger + payda;
                        }
                    }
                }
            }
            return (pay / payda);
        }

        private double IslemiGetir(double deger1, double deger2)
        {
            if (_ayarlar.Islem == IslMetodu.Min)
            {
                if (deger1 < deger2) { return deger1; }
                else { return deger2; }
            }
            else if (_ayarlar.Islem == IslMetodu.Carpim)
            {
                return deger1 * deger2;
            }
            return 0;
        }

        private double AgirlikliOrtDurulastirma(List<BulanikSayi> sayilar, BulanikDegisken degisken)
        {
            double payda = 0;
            double pay = 0;

            for (int i = 0; i < sayilar.Count; i++)
            {
                UyelikFonksiyonu uf = degisken.UyelikFonksiyonunuGetir(sayilar[i].UyeAdi);
                pay = ((uf.AgirlikMerkezi * IslemiGetir(sayilar[i].BulanikDeger, uf.CikisiAl(uf.AgirlikMerkezi))) / (uf.Alan * uf.Alan)) + pay;
                payda = (IslemiGetir(sayilar[i].BulanikDeger, uf.CikisiAl(uf.AgirlikMerkezi)) / (uf.Alan * uf.Alan)) + payda;
            }
            return (pay / payda);
        }

        public List<BulanikSayi> Bulaniklastirma(double deger, BulanikDegisken degisken)
        {
            List<BulanikSayi> set = new List<BulanikSayi>();
            List<UyelikFonksiyonu> UFler = degisken.UFler;
            for (int i = 0; i < degisken.UFler.Count; i++)
            {
                double d = UFler[i].CikisiAl(deger);
                if (d >= 0)
                {
                    set.Add(new BulanikSayi(UFler[i].Isim, d));
                }
            }
            return set;
        }

        public double[] Durulastirma(List<BulanikDizi> diziler, BulanikDegisken degisken)
        {
            double[] deger = new double[2];
            for (int i = 0; i < diziler.Count; i++)
            {
                if (diziler[i].Degisken == degisken.Isim)
                {
                    deger[0] = AgirlikliOrtDurulastirma(diziler[i].Dizi, degisken);
                    deger[1] = Centroid(diziler[i].Dizi, degisken);
                }
            }
            return deger;
        }

    }
}
