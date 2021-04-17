using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Otomasyon.VeriErisim.Concrete.Sql;
using Otomasyon.Veriler.Concrete;
using Otomasyon.İs.Concrete;

namespace Otomasyon.KullaniciArayuzu.Concrete
{
    public partial class Bilancolar : Form
    {
        private bool dtBaslangic = false;
        private bool dtBitis = false;

        private bool yillik = false;
        private bool aylik = false;

        private bool aylikYillikKontrol = false;


        private GecmisDetayYonetimi gecmisDetayYonetimi;
        private GecmisSiparisYonetimi gecmisSiparisYonetimi;
       


        private List<GecmisSiparis> gecmissiparisler;
        private List<GecmisDetay> gecmisDetaylar;
        private List<Urun> urunler;
        
        private DataTable tablo;


        private int grdYil;
        private string grdAy;

        private string[] aylar =
        {
            "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım",
            "Aralık"
        };
       

        private string baslangicZaman;

        public Bilancolar(List<Urun> urunler)
        {
            gecmisDetayYonetimi = new GecmisDetayYonetimi(new SQLGecmisDetayDal());
            gecmisSiparisYonetimi = new GecmisSiparisYonetimi(new SQLGecmisSiparisDal());
           
            this.urunler = urunler;

            InitializeComponent();
        }

        private void dateBaslangic_ValueChanged(object sender, EventArgs e)
        {
            dtBaslangic = true;
          

            DateGoster();

        }

        private void dateBitis_ValueChanged(object sender, EventArgs e)
        {
            dtBitis = true;

            DateGoster();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecenekler.SelectedIndex == 0)
            {
               EnCokSatilanUrunler();
            }

           else if (cmbSecenekler.SelectedIndex == 1)
            {
                RiskliUrunleriGetir();
            }
        }

        private void RiskliUrunleriGetir()
        {
            List<Urun> riskliUrunler = new List<Urun>();

            tablo = new DataTable();
            tablo.Columns.Add("Ürün Adı", typeof(string));
            tablo.Columns.Add("Ürün Fiyatı", typeof(float));
            tablo.Columns.Add("Ürün Puanı", typeof(int));
            tablo.Columns.Add("Ürün Stok Duzeyi", typeof(int));


            foreach (var urun in urunler)
            {
                if (urun.StokDuzeyi >= 0 && urun.StokDuzeyi <= 15)
                {
                    riskliUrunler.Add(urun);
                }
            }

            foreach (var riskliUrun in riskliUrunler)
            {
                tablo.Rows.Add(riskliUrun.UrunAdi, riskliUrun.Fiyat, riskliUrun.UrunPuani, riskliUrun.StokDuzeyi);
            }

            grdBilanco.DataSource = tablo;

        }


        private void ListeleriEsitle()
        {
            gecmissiparisler = gecmisSiparisYonetimi.HepsiniGetir();
            gecmisDetaylar = gecmisDetayYonetimi.HepsiniGetir();
        }

        private void DateGoster()
        {
            if (dtBaslangic && dtBitis == false)
            {
                yillik = false;
                aylik = true;
                aylikYillikKontrol = true;
                var zaman = dateBaslangic.Value;

                tablo = new DataTable();
                tablo.Columns.Add("Ay", typeof(string));
                tablo.Columns.Add("Kazanç", typeof(float));

                tablo.Rows.Add(zaman.ToString("MMMM"), Toplam(DetayGetir(SiparisGetir(zaman))));

                grdBilanco.DataSource = tablo;
               
            }

            else if (dtBaslangic && dtBitis)
            {
                yillik = false;
                aylik = true;
                aylikYillikKontrol = true;
                var baslangic = dateBaslangic.Value;
                var bitis = dateBitis.Value;

               
                tablo = new DataTable();
                tablo.Columns.Add("Ay", typeof(string));
                tablo.Columns.Add("Kazanç", typeof(float));

              
                var gelenSiparisler = SiparisGetir(baslangic, bitis);
                

                while (DateTime.Compare(baslangic, bitis) <= 0)
                {
                    tablo.Rows.Add(baslangic.ToString("MMMM"),
                        Toplam(DetayGetir(gelenSiparisler), baslangic,1));
                    baslangic = baslangic.AddMonths(1);
                }

                grdBilanco.DataSource = tablo;

            }
            
        }

        private List<GecmisSiparis> SiparisGetir(DateTime gelenTarih)
        {
            List<GecmisSiparis> denkGelenList = new List<GecmisSiparis>();


            foreach (var item in gecmissiparisler)
            {
                var degiskenTarih = Convert.ToDateTime(item.VerilmeTarihi);
                
                if (degiskenTarih.Month == gelenTarih.Month && degiskenTarih.Year == gelenTarih.Year)
                {
                    denkGelenList.Add(item);
                }
            }

            return denkGelenList;
        }

        private List<GecmisSiparis> SiparisGetir(int yil)
        {
            List<GecmisSiparis> denkGelenList = new List<GecmisSiparis>();

            foreach (var item in gecmissiparisler)
            {
                var degiskenTarih = Convert.ToDateTime(item.VerilmeTarihi);

                if (degiskenTarih.Year == yil)
                {
                    denkGelenList.Add(item);
                }
            }

            return denkGelenList;

        }

        private List<GecmisSiparis> SiparisGetir(DateTime baslangictarih, DateTime bitistarih2)
        {
            List<GecmisSiparis> denkGelenList = new List<GecmisSiparis>();

            foreach (var item in gecmissiparisler)
            {
                var degiskenTarih = Convert.ToDateTime(item.VerilmeTarihi);

                if (DateTime.Compare(degiskenTarih, baslangictarih) >= 0 && (DateTime.Compare(degiskenTarih, bitistarih2) <= 0))
                {
                    denkGelenList.Add(item);
                }

            }

            return denkGelenList;

        }



        private List<GecmisDetay> DetayGetir(List<GecmisSiparis> gelenSiparis)
        {
            List<GecmisDetay> denkGelenList = new List<GecmisDetay>();

            foreach (var gecmisDetay in gecmisDetaylar)
            {
                foreach (var gecMisSiparis in gelenSiparis)
                {
                    if (gecmisDetay.GecmisSiparis.GecmisSiparisId == gecMisSiparis.GecmisSiparisId)
                    {
                        denkGelenList.Add(gecmisDetay);
                    }
                }
            }

            return denkGelenList;
        }

        private float Toplam(List<GecmisDetay> gelenDetaylar)
        {
            float toplam = 0;
            foreach (var gelenDetay in gelenDetaylar)
            {
                toplam += gelenDetay.GecmisFiyat;
            }

            return toplam;
        }

        private float Toplam(List<GecmisDetay> gelenDetaylar, DateTime gelenTarih, int belirleme)
        {
            float toplam = 0;

            if (gelenDetaylar.Count > 0)
            {
                foreach (var gelenDetay in gelenDetaylar)
                {
                    var degiskenTarih = Convert.ToDateTime(gelenDetay.GecmisSiparis.VerilmeTarihi);

                    if (belirleme == 0)
                    {
                        if (DateTime.Compare(gelenTarih,degiskenTarih) == 0)
                        {
                            toplam += gelenDetay.GecmisFiyat;
                        }
                    }

                    else if (belirleme == 1)
                    {
                        if (degiskenTarih.Month == gelenTarih.Month && degiskenTarih.Year == gelenTarih.Year)
                        {
                            toplam += gelenDetay.GecmisFiyat;
                        }
                    }

                }
            }

            return toplam;
        }

        private void Bilancolar_Load(object sender, EventArgs e)
        {
            ListeleriEsitle();
            baslangicZaman = dateBaslangic.Value.ToString("MMMM");
            YillikGetir();
        }



        private void rdGunluk_Click(object sender, EventArgs e)
        {
            GunlukGetir();
        }

        private void rdYillik_Click(object sender, EventArgs e)
        {
            YillikGetir();
        }

        private void YillikGetir()
        {
            yillik = true;
          

            tablo = new DataTable();
            tablo.Columns.Add("Yıl", typeof(int));
            tablo.Columns.Add("Kazanç", typeof(float));

            List<int> yillar = new List<int>();
            List<float> kazanclar = new List<float>();

            for (int i = 0; i < gecmissiparisler.Count; i++)
            {
                var tarih1 = Convert.ToDateTime(gecmissiparisler[i].VerilmeTarihi);

                for (int j = 0; j < gecmissiparisler.Count; j++)
                {
                    var tarih2 = Convert.ToDateTime(gecmissiparisler[j].VerilmeTarihi);
                    if (j == i)
                    {
                        continue;
                    }

                    if (tarih1.Year != tarih2.Year)
                    {
                        if (!yillar.Contains(tarih2.Year))
                        {
                            yillar.Add(tarih2.Year);
                            kazanclar.Add(Toplam(DetayGetir(SiparisGetir(Convert.ToDateTime(gecmissiparisler[j].VerilmeTarihi)))));
                        }
                    }

                }
            }

            if (yillar.Count == 0)
            {
                var yil = Convert.ToDateTime(gecmissiparisler[0].VerilmeTarihi).Year;
                tablo.Rows.Add(yil, Toplam(DetayGetir(gecmissiparisler)));
            }

            else if (yillar.Count > 0)
            {
                for (int i = 0; i < yillar.Count; i++)
                {
                    tablo.Rows.Add(yillar[i], kazanclar[i]);
                }
            }

            grdBilanco.DataSource = tablo;
        }

        private void GunlukGetir()
        {
          
            yillik = false;

            var gunBaslangic = dateBaslangic.Value.Date;
            var gunBitis = dateBitis.Value.Date;

            var gelenSiparisler = SiparisGetir(gunBaslangic, gunBitis);

            tablo = new DataTable();
            tablo.Columns.Add("Gün", typeof(string));
            tablo.Columns.Add("Kazanç", typeof(float));

            while (DateTime.Compare(gunBaslangic, gunBitis) <= 0)
            {
                tablo.Rows.Add(gunBaslangic.ToShortDateString(),
                    Toplam(DetayGetir(gelenSiparisler), gunBaslangic, 0));
                gunBaslangic = gunBaslangic.AddDays(1);
            }


            grdBilanco.DataSource = tablo;
        }

        private void grdBilanco_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (yillik)
            {
               grdYil = Convert.ToInt32(grdBilanco.CurrentRow.Cells[0].Value);

                var yilBasi = new DateTime(grdYil, 1, 1);
                var yilSonu = yilBasi.AddYears(1).AddDays(-1);
                
                tablo = new DataTable();
                tablo.Columns.Add("Ay", typeof(string));
                tablo.Columns.Add("Kazanç", typeof(float));

                var siparisler = SiparisGetir(grdYil);

                while (DateTime.Compare(yilBasi, yilSonu) <= 0)
                {
                    tablo.Rows.Add(yilBasi.ToString("MMMM"),
                        Toplam(DetayGetir(siparisler), yilBasi, 1));
                    yilBasi = yilBasi.AddMonths(1);
                }

                grdBilanco.DataSource = tablo;
                yillik = false;
                aylik = true;
            }

            else if (aylik)
            {
                if (aylikYillikKontrol == false)
                {
                    string ay = grdBilanco.CurrentRow.Cells[0].Value.ToString();


                    var ayBasi = new DateTime(grdYil, Array.IndexOf(aylar, ay) + 1, 1);
                    var aySonu = ayBasi.AddMonths(1).AddDays(-1);

                    tablo = new DataTable();
                    tablo.Columns.Add("Gün", typeof(string));
                    tablo.Columns.Add("Kazanç", typeof(float));

                    var siparisler = SiparisGetir(ayBasi, aySonu);

                    while (DateTime.Compare(ayBasi, aySonu) <= 0)
                    {
                        tablo.Rows.Add(ayBasi.ToShortDateString(),
                            Toplam(DetayGetir(siparisler), ayBasi, 0));
                        ayBasi = ayBasi.AddDays(1);
                    }
                    grdBilanco.DataSource = tablo;
                    aylik = false;
                }
                else
                {
                    string ay = grdBilanco.CurrentRow.Cells[0].Value.ToString();
                    var ayBasi = new DateTime(DateTime.Now.Year, Array.IndexOf(aylar, ay) + 1, 1);
                    var aySonu = ayBasi.AddMonths(1).AddDays(-1);

                    tablo = new DataTable();
                    tablo.Columns.Add("Gün", typeof(string));
                    tablo.Columns.Add("Kazanç", typeof(float));

                    var siparisler = SiparisGetir(ayBasi, aySonu);

                    while (DateTime.Compare(ayBasi, aySonu) <= 0)
                    {
                        tablo.Rows.Add(ayBasi.ToShortDateString(),
                            Toplam(DetayGetir(siparisler), ayBasi, 0));
                        ayBasi = ayBasi.AddDays(1);
                    }
                    grdBilanco.DataSource = tablo;
                    aylik = false;
                    aylikYillikKontrol = false;
                }
            }
        }

        private void EnCokSatilanUrunler()
        {
            var mod = new List<int>();

            List<GecmisDetay> liste = new List<GecmisDetay>();

            foreach (var item in gecmisDetaylar)
            {
                liste.Add(item);
            }


            var gosterilecekUrunler = new List<Urun>();

            for (int i = 0; i < liste.Count; i++)
            {
                int sayac = 1;

                for (int j = 0; j < liste.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (liste[i].GecmisUrun.UrunId == liste[j].GecmisUrun.UrunId)
                    {
                        sayac++;
                        liste.Remove(liste[j]);
                        j = 0;
                    }
                }
                gosterilecekUrunler.Add(liste[i].GecmisUrun);
                liste = UruneGoreSil(liste[i].GecmisUrun, liste);
                mod.Add(sayac);
                i = 0;
            }

            tablo = new DataTable();
            tablo.Columns.Add("Ürün Adı", typeof(string));
            tablo.Columns.Add("Kateogori Adı", typeof(string));
            tablo.Columns.Add("Fiyatı", typeof(float));
            tablo.Columns.Add("Puanı", typeof(float));


            int say = 0;

            do
            {
                int index = IndexGonder(mod);

                tablo.Rows.Add(
                    gosterilecekUrunler[index].UrunAdi,
                    gosterilecekUrunler[index].Kategori.KategoriAdi,
                    gosterilecekUrunler[index].Fiyat,
                    gosterilecekUrunler[index].UrunPuani

                );
                mod.RemoveAt(index);
                gosterilecekUrunler.RemoveAt(index);
                say = 0;
                if (mod.Count == 0)
                {
                    break;
                }
            } while (say < gosterilecekUrunler.Count);


            grdBilanco.DataSource = tablo;


        }


        private int IndexGonder(List<int> modListesi)
        {
            int max = modListesi[0];

            for (int i = 0; i < modListesi.Count; i++)
            {
                if (modListesi[i] > max)
                {
                    max = modListesi[i];
                }
            }

            return modListesi.IndexOf(max);

        }

        private List<GecmisDetay> UruneGoreSil(Urun urun, List<GecmisDetay> liste)
        {
           
            for (int i = 0; i < liste.Count; i++)
            {
                if (liste[i].GecmisUrun.UrunId == urun.UrunId)
                {
                    liste.Remove(liste[i]);
                    i = 0;
                }

                
            }

            return liste;
        }

		private void btnGuncelle_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}


