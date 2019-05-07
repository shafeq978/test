using Mamdani.Bulanik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Mamdani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<BulanikDegisken> kumeler { get; set; }
        public int Renk { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            double aa = double.Parse(maskedTextBox1.Text);
            double bb = double.Parse(maskedTextBox2.Text);
            double cc = double.Parse(maskedTextBox3.Text);

            GirisDegeriniEkle(chart1, aa);
            GirisDegeriniEkle(chart2, bb);
            GirisDegeriniEkle(chart3, cc);
           
            List<string> donusler = Bulat(aa, bb, cc);
            for (int i = 0; i < donusler.Count; i++)
            {
                if (donusler[i] == "Dönüş Hızı")
                {
                    while (donusler[i + 1] != "Süre")
                    { Renk = 0;
                        string aaa = donusler[i + 1];
                        aaa = aaa.Substring(aaa.IndexOf(">")+2);
                        CikisDegeriniEkle(chart4,Convert.ToDouble(aaa), donusler[i + 1].Substring(0, donusler[i + 1].IndexOf("--")),10);
                        i++; Renk++;
                    }
                }

               else if (donusler[i] == "Süre")
                {
                    Renk = 0;
                    while (donusler[i + 1] != "Deterjan")
                    {
                        string aaa = donusler[i + 1];
                        aaa = aaa.Substring(aaa.IndexOf(">") + 2);
                        CikisDegeriniEkle(chart5, Convert.ToDouble(aaa), donusler[i + 1].Substring(0, donusler[i + 1].IndexOf("--")),300);
                        i++; Renk++;
                    }
                }
             else   if (donusler[i] == "Deterjan")
                {
                    while (donusler[i + 1] != "5. Durulaştırılmış Çıkışlar\n")
                    {
                        Renk = 0;
                        string aaa = donusler[i + 1];
                        aaa = aaa.Substring(aaa.IndexOf(">") + 2);
                        CikisDegeriniEkle(chart6, Convert.ToDouble(aaa), donusler[i + 1].Substring(0, donusler[i + 1].IndexOf("--")),100);
                        i++; Renk++;

                    }
                }
            }

            listBox1.DataSource = donusler;
        }

        private void GirisDegeriniEkle(Chart chrt, double aa)
        {
            chrt.Series["Değer"].Points.Clear();

            chrt.Series["Değer"].Points.AddXY(aa, 0);
            chrt.Series["Değer"].Points.AddXY(aa, 1);

            chrt.Series["Değer"].Color = Color.Black;
            chrt.Series["Değer"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
        }
        private void CikisDegeriniEkle(Chart chrt, double aa, string isim,int bitis)
        {
            chrt.Series.Add(isim);//["Değer"].Points.Clear();
            Series series1 = chrt.Series[isim];
            series1.BorderWidth = 2;
            
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.CustomProperties = "IsXAxisQuantitative=False";
          
            series1.XValueMember = "X";
            series1.YValueMembers = "Y";

            series1.Points.AddXY(0, aa);
            series1.Points.AddXY(bitis, aa);

            series1.Color = RenkGetir(Renk);
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
        }

        Color RenkGetir(int sayi)
        {
            switch (sayi)
            {
                case 0: return  Color.Black;
                case 1: return Color.Aqua;
                case 2: return Color.Brown;
                case 3: return Color.Cyan;
                case 4: return Color.DarkRed;
                case 5: return Color.Fuchsia;
                default:
                    break;
            }
            return Color.Black;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            #region DataGridView_Kurallar
            dataGridView1.Rows.Add(new List<string>() { "1", "Hassas", "Küçük", "Küçük", "Hassas", "Kısa", "Çok Az" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "2", "Hassas", "Küçük", "Orta", "Normal Hassas", "Kısa", "Az" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "3", "Hassas", "Küçük", "Büyük", "Orta", "Normal Kısa", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "4", "Hassas", "Orta", "Küçük", "Hassas", "Kısa", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "5", "Hassas", "Orta", "Orta", "Normal Hassas", "Normal Kısa", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "6", "Hassas", "Orta", "Büyük", "Orta", "Orta", "Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "7", "Hassas", "Büyük", "Küçük", "Normal Hassas", "Normal Kısa", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "8", "Hassas", "Büyük", "Orta", "Normal Hassas", "Orta", "Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "9", "Hassas", "Büyük", "Büyük", "Orta", "Normal Uzun", "Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "10", "Orta", "Küçük", "Küçük", "Normal Hassas", "Normal Kısa", "Az" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "11", "Orta", "Küçük", "Orta", "Orta", "Kısa", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "12", "Orta", "Küçük", "Büyük", "Normal Güçlü", "Orta", "Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "13", "Orta", "Orta", "Küçük", "Normal Hassas", "Uzun", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "14", "Orta", "Orta", "Orta", "Orta", "Orta", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "15", "Orta", "Orta", "Büyük", "Hassas", "Uzun", "Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "16", "Orta", "Büyük", "Küçük", "Hassas", "Orta", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "17", "Orta", "Büyük", "Orta", "Hassas", "Normal Uzun", "Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "18", "Orta", "Büyük", "Büyük", "Hassas", "Uzun", "Çok Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "19", "Sağlam", "Küçük", "Küçük", "Orta", "Orta", "Az" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "20", "Sağlam", "Küçük", "Orta", "Normal Güçlü", "Orta", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "21", "Sağlam", "Küçük", "Büyük", "Güçlü", "Normal Uzun", "Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "22", "Sağlam", "Orta", "Küçük", "Orta", "Orta", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "23", "Sağlam", "Orta", "Orta", "Normal Güçlü", "Normal Uzun", "Orta" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "24", "Sağlam", "Orta", "Büyük", "Güçlü", "Orta", "Çok Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "25", "Sağlam", "Büyük", "Küçük", "Normal Güçlü", "Normal Uzun", "Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "26", "Sağlam", "Büyük", "Orta", "Normal Güçlü", "Uzun", "Fazla" }.ToArray());
            dataGridView1.Rows.Add(new List<string>() { "27", "Sağlam", "Büyük", "Büyük", "Güçlü", "Uzun", "Çok Fazla" }.ToArray());
            #endregion

            this.kumeler = BulanikKumeler();
            GirisGrafigiEkle(chart1, kumeler[0]);
            GirisGrafigiEkle(chart2, kumeler[1]);
            GirisGrafigiEkle(chart3, kumeler[2]);

            CikisGrafigiEkle(chart4, kumeler[3]);
            CikisGrafigiEkle(chart6, kumeler[4]);
            CikisGrafigiEkle(chart5, kumeler[5]);

        }

        private void GirisGrafigiEkle(Chart chrt, BulanikDegisken degisken)
        {
            chrt.Titles.Add(degisken.Isim);



            chrt.Series[degisken.UFler[0].Isim].Points.AddXY(degisken.UFler[0].Parametreler[0], 0);
            chrt.Series[degisken.UFler[0].Isim].Points.AddXY(degisken.UFler[0].Parametreler[1], 1);
            chrt.Series[degisken.UFler[0].Isim].Points.AddXY(degisken.UFler[0].Parametreler[2], 1);
            chrt.Series[degisken.UFler[0].Isim].Points.AddXY(degisken.UFler[0].Parametreler[3], 0);

            chrt.Series[degisken.UFler[1].Isim].Points.AddXY(degisken.UFler[1].Parametreler[0], 0);
            chrt.Series[degisken.UFler[1].Isim].Points.AddXY(degisken.UFler[1].Parametreler[1], 1);
            chrt.Series[degisken.UFler[1].Isim].Points.AddXY(degisken.UFler[1].Parametreler[2], 0);



            chrt.Series[degisken.UFler[2].Isim].Points.AddXY(degisken.UFler[2].Parametreler[0], 0);
            chrt.Series[degisken.UFler[2].Isim].Points.AddXY(degisken.UFler[2].Parametreler[1], 1);
            chrt.Series[degisken.UFler[2].Isim].Points.AddXY(degisken.UFler[2].Parametreler[2], 1);
            chrt.Series[degisken.UFler[2].Isim].Points.AddXY(degisken.UFler[2].Parametreler[3], 0);


            chrt.Series[degisken.UFler[0].Isim].Color = Color.Blue;
            chrt.Series[degisken.UFler[1].Isim].Color = Color.Green;
            chrt.Series[degisken.UFler[2].Isim].Color = Color.Purple;


            chrt.ChartAreas[0].AxisX.Minimum = 0;
        }
        private void CikisGrafigiEkle(Chart chrt, BulanikDegisken degisken)
        {
            chrt.Titles.Add(degisken.Isim);



            chrt.Series[degisken.UFler[0].Isim].Points.AddXY(degisken.UFler[0].Parametreler[0], 0);
            chrt.Series[degisken.UFler[0].Isim].Points.AddXY(degisken.UFler[0].Parametreler[1], 1);
            chrt.Series[degisken.UFler[0].Isim].Points.AddXY(degisken.UFler[0].Parametreler[2], 1);
            chrt.Series[degisken.UFler[0].Isim].Points.AddXY(degisken.UFler[0].Parametreler[3], 0);

            chrt.Series[degisken.UFler[1].Isim].Points.AddXY(degisken.UFler[1].Parametreler[0], 0);
            chrt.Series[degisken.UFler[1].Isim].Points.AddXY(degisken.UFler[1].Parametreler[1], 1);
            chrt.Series[degisken.UFler[1].Isim].Points.AddXY(degisken.UFler[1].Parametreler[2], 0);

            chrt.Series[degisken.UFler[2].Isim].Points.AddXY(degisken.UFler[2].Parametreler[0], 0);
            chrt.Series[degisken.UFler[2].Isim].Points.AddXY(degisken.UFler[2].Parametreler[1], 1);
            chrt.Series[degisken.UFler[2].Isim].Points.AddXY(degisken.UFler[2].Parametreler[2], 0);

            chrt.Series[degisken.UFler[3].Isim].Points.AddXY(degisken.UFler[3].Parametreler[0], 0);
            chrt.Series[degisken.UFler[3].Isim].Points.AddXY(degisken.UFler[3].Parametreler[1], 1);
            chrt.Series[degisken.UFler[3].Isim].Points.AddXY(degisken.UFler[3].Parametreler[2], 0);



            chrt.Series[degisken.UFler[4].Isim].Points.AddXY(degisken.UFler[4].Parametreler[0], 0);
            chrt.Series[degisken.UFler[4].Isim].Points.AddXY(degisken.UFler[4].Parametreler[1], 1);
            chrt.Series[degisken.UFler[4].Isim].Points.AddXY(degisken.UFler[4].Parametreler[2], 1);
            chrt.Series[degisken.UFler[4].Isim].Points.AddXY(degisken.UFler[4].Parametreler[3], 0);


            chrt.Series[degisken.UFler[0].Isim].Color = Color.Blue;
            chrt.Series[degisken.UFler[1].Isim].Color = Color.Green;
            chrt.Series[degisken.UFler[2].Isim].Color = Color.Purple;


            chrt.ChartAreas[0].AxisX.Minimum = 0;
        }
        public List<string> Bulat(double giris1, double giris2, double giris3)
        {
            List<string> donusler = new List<string>();
            Ayarlar ayar = new Ayarlar(IslMetodu.Carpim, BaglantiMetodu.Min);



            BMK k = new BMK(ayar);
            BulanikDizi set1 = new BulanikDizi(k.Bulaniklastirma(giris1, this.kumeler[0]), this.kumeler[0].Isim);
            BulanikDizi set2 = new BulanikDizi(k.Bulaniklastirma(giris2, this.kumeler[1]), this.kumeler[1].Isim);
            BulanikDizi set3 = new BulanikDizi(k.Bulaniklastirma(giris3, this.kumeler[2]), this.kumeler[2].Isim);

            donusler.Add("1.Girişler\n");
            donusler.Add("Hassaslık: " + giris1.ToString());
            donusler.Add("Miktar: " + giris2.ToString());
            donusler.Add("Kirlilik: " + giris3.ToString());


            List<BulanikDizi> bulanikDizi = new List<BulanikDizi>();
            bulanikDizi.Add(set1);
            bulanikDizi.Add(set2);
            bulanikDizi.Add(set3);

            donusler.Add("\n2. Girişlerin Bulanıklaştırılması\n");
            for (int i = 0; i < bulanikDizi.Count; i++)
            {
                donusler.Add(bulanikDizi[i].Degisken);

                for (int j = 0; j < bulanikDizi[i].Dizi.Count; j++)
                {
                    donusler.Add(bulanikDizi[i].Dizi[j].ToString());
                }


            }

            List<KuralItem> GirisKurali = new List<KuralItem>();
            List<KuralItem> CikisKurali = new List<KuralItem>();

            List<Kural> Racons = new List<Kural>();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                GirisKurali = new List<KuralItem>();
                CikisKurali = new List<KuralItem>();

                GirisKurali.AddRange(new KuralItem[3] { new KuralItem("Hassaslık", dataGridView1.Rows[i].Cells[1].Value.ToString()), new KuralItem("Miktar", dataGridView1.Rows[i].Cells[2].Value.ToString()), new KuralItem("Kirlilik", dataGridView1.Rows[i].Cells[3].Value.ToString()) });
                CikisKurali.AddRange(new KuralItem[3] { new KuralItem("Dönüş Hızı", dataGridView1.Rows[i].Cells[4].Value.ToString()), new KuralItem("Süre", dataGridView1.Rows[i].Cells[5].Value.ToString()), new KuralItem("Deterjan", dataGridView1.Rows[i].Cells[6].Value.ToString()) });
                Racons.Add(new Kural(GirisKurali, CikisKurali, Baglac.And));

            }
            dataGridView1.ClearSelection();


            KuralIslemi islem = new KuralIslemi(ayar, Racons, bulanikDizi);

            List<BulanikDizi> isl = islem.KurallariUygula();

            donusler.Add("3. Tetiklenen Kurallar \n");
            for (int i = 0; i < islem.TetiklenenKurallar.Count; i++)
            {
                donusler.Add("Kural " + islem.TetiklenenKurallar[i].ToString());
                dataGridView1.Rows[islem.TetiklenenKurallar[i] - 1].Selected = true;
            }
            donusler.Add("4. Bulanık Çıkışlar \n");
            for (int i = 0; i < isl.Count; i++)
            {
                donusler.Add(isl[i].Degisken);

                for (int j = 0; j < isl[i].Dizi.Count; j++)
                {

                    string aaa = isl[i].Dizi[j].ToString();
                    aaa = aaa.Substring(aaa.IndexOf(">") + 2);
                   if(aaa != "0")
                    donusler.Add(isl[i].Dizi[j].ToString());
                }


            }

            double[] cikis1 = k.Durulastirma(isl, this.kumeler[3]);
            double[] cikis2 = k.Durulastirma(isl, this.kumeler[4]);
            double[] cikis3 = k.Durulastirma(isl, this.kumeler[5]);
            donusler.Add("5. Durulaştırılmış Çıkışlar\n");
            donusler.Add(" Ağırlıklı Ortalama:\n");
            donusler.Add("Dönüş Hızı: " + cikis1[0].ToString());
            donusler.Add("Süre: " + cikis2[0].ToString());
            donusler.Add("Deterjan: " + cikis3[0].ToString());
            donusler.Add(" Centroid:\n");
            donusler.Add("Dönüş Hızı: " + cikis1[1].ToString());
            donusler.Add("Süre: " + cikis2[1].ToString());
            donusler.Add("Deterjan: " + cikis3[1].ToString());

            return donusler;

        }

        public List<BulanikDegisken> BulanikKumeler()
        {
            List<BulanikDegisken> degiskenler = new List<BulanikDegisken>();

            BulanikDegisken X1 = new BulanikDegisken("Hassaslık", GirisCikisTipi.Giris);
            X1.araligiAyarla(0, 10);
            X1.UfEkle(new YamukUF("Sağlam", -4, -1.5, 2, 4));
            X1.UfEkle(new UcgenUF("Orta", 3, 5, 7));
            X1.UfEkle(new YamukUF("Hassas", 5.5, 8, 12.5, 14));
            degiskenler.Add(X1);

            BulanikDegisken X2 = new BulanikDegisken("Miktar", GirisCikisTipi.Giris);
            X2.araligiAyarla(0, 10);
            X2.UfEkle(new YamukUF("Küçük", -4, -1.5, 2, 4));
            X2.UfEkle(new UcgenUF("Orta", 3, 5, 7));
            X2.UfEkle(new YamukUF("Büyük", 5.5, 8, 12.5, 14));
            degiskenler.Add(X2);

            BulanikDegisken X3 = new BulanikDegisken("Kirlilik", GirisCikisTipi.Giris);
            X3.araligiAyarla(0, 10);
            X3.UfEkle(new YamukUF("Küçük", -4.5, -2.5, 2, 4.5));
            X3.UfEkle(new UcgenUF("Orta", 3, 5, 7));
            X3.UfEkle(new YamukUF("Büyük", 5.5, 8, 12.5, 15));
            degiskenler.Add(X3);

            BulanikDegisken Y1 = new BulanikDegisken("Dönüş Hızı", GirisCikisTipi.Cikis);
            Y1.araligiAyarla(0, 10);
            Y1.UfEkle(new YamukUF("Hassas", -5.8, -2.8, 0.5, 1.5));
            Y1.UfEkle(new UcgenUF("Normal Hassas", 0.5, 2.75, 5));
            Y1.UfEkle(new UcgenUF("Orta", 2.75, 5, 7.25));
            Y1.UfEkle(new UcgenUF("Normal Güçlü", 5, 7.25, 9.5));
            Y1.UfEkle(new YamukUF("Güçlü", 8.5, 9.5, 12.8, 15.2));
            degiskenler.Add(Y1);

            BulanikDegisken Y2 = new BulanikDegisken("Süre", GirisCikisTipi.Cikis);
            Y2.araligiAyarla(0, 100);
            Y2.UfEkle(new YamukUF("Kısa", -46.5, -25.28, 22.3, 39.9));
            Y2.UfEkle(new UcgenUF("Normal Kısa", 22.3, 39.9, 57.5));
            Y2.UfEkle(new UcgenUF("Orta", 39.9, 57.5, 75.1));
            Y2.UfEkle(new UcgenUF("Normal Uzun", 57.5, 75.1, 92.7));
            Y2.UfEkle(new YamukUF("Uzun", 75, 92.7, 111.6, 130));
            degiskenler.Add(Y2);

            BulanikDegisken Y3 = new BulanikDegisken("Deterjan", GirisCikisTipi.Cikis);
            Y3.araligiAyarla(0, 300);
            Y3.UfEkle(new YamukUF("Çok Az", 0, 0, 20, 85));
            Y3.UfEkle(new UcgenUF("Az", 20, 85, 150));
            Y3.UfEkle(new UcgenUF("Orta", 85, 150, 215));
            Y3.UfEkle(new UcgenUF("Fazla", 150, 215, 280));
            Y3.UfEkle(new YamukUF("Çok Fazla", 215, 280, 300, 300));
            degiskenler.Add(Y3);

            return degiskenler;
        }

    }
}
