using Cafe.Web.Models;
using Otomasyon.İs.Concrete;
using Otomasyon.VeriErisim.Concrete.Sql;
using Otomasyon.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe.Web.Helper
{
    public class Sepet
    {
        private List<Sepet_API> sepetliste = new List<Sepet_API>();
        MusteriYonetimi musteriYonetimi = new MusteriYonetimi(new SQLMusteriDal());
        SiparisYonetimi siparisYonetimi = new SiparisYonetimi(new SQLSiparisDal());
        SiparisDetayYonetimi detayYonetimi = new SiparisDetayYonetimi(new SQLSiparisDetayiDal());

        private Musteri girenMusteri;

        public List<Sepet_API> sepet_s
        {
            get { return sepetliste; }
        }

        public void UrunEkle(Urun urun, int quantity)
        {
            var Ururnekle = sepetliste.Where(i => i.Urun.UrunId == urun.UrunId).FirstOrDefault();

            if (Ururnekle == null)
            {
                sepetliste.Add(new Sepet_API() {Urun = urun, Quantity = quantity});
            }
            else
            {
                Ururnekle.Quantity += quantity;
            }
        }

        public void UrunSil(Urun urun)
        {
            var sil = sepetliste.RemoveAll(i => i.Urun.UrunId == urun.UrunId);
        }

        public double Toplam()
        {
            return sepetliste.Sum(i => i.Urun.Fiyat * i.Quantity);
        }

        public void Temizle()
        {
            sepetliste.Clear();
        }

        public float ToplamPuan()
        {
            var login = HttpContext.Current.User.Identity.Name;
            girenMusteri = MusteriGetir(login);
            
            return girenMusteri.KazanilanPuan;

        }

        public void SiparisTamamla()
        {

            var login = HttpContext.Current.User.Identity.Name;


            siparisYonetimi.Ekle(new Siparis
            {
                Musteri = MusteriGetir(login),
                VerilmeZamani = DateTime.Now.ToString("HH:mm"),
                VerilmeTarihi = DateTime.Now.ToString("dd.MM.yyyy"),
            });
            var siparis = SiparisGetir(login);

            foreach (var item in sepetliste)
            {
                for (int i = 0; i < item.Quantity; i++)
                    detayYonetimi.Ekle(new SiparisDetayi
                    {
                        Siparis = siparis,
                        Urun = item.Urun,
                    });
            }
            
        }

        public void SiparisTamamlaPuan()
        {
            var login = HttpContext.Current.User.Identity.Name;
            siparisYonetimi.Ekle(new Siparis
            {
                Musteri = MusteriGetir(login),
                VerilmeZamani = DateTime.Now.ToString("HH:mm"),
                VerilmeTarihi = DateTime.Now.ToString("dd.MM.yyyy"),
            });
            var siparis = SiparisGetir(login);

            foreach (var item in sepetliste)
            {
                for (int i = 0; i < item.Quantity; i++)
                    detayYonetimi.Ekle(new SiparisDetayi
                    {
                        Siparis = siparis,
                        Urun = item.Urun,
                    });
            }
            
            musteriYonetimi.Guncelle(new Musteri
            {
                MusteriId = girenMusteri.MusteriId,
                Eposta = girenMusteri.Eposta,
                KazanilanPuan = PuanIslemleri(),
                Ad = girenMusteri.Ad,
                KullaniciAdi = girenMusteri.KullaniciAdi,
                Soyad = girenMusteri.Soyad,
                Parola = girenMusteri.Parola
            });
        }
    
        public float PuanIslemleri()
        {
            float guncelPuan = ToplamPuan();

            float puan = guncelPuan;

            if (puan >= ToplamAlisPuani())
            {
                guncelPuan = puan - ToplamAlisPuani();
            }

            else
            {

                guncelPuan = puan;
            }
            
            return guncelPuan;
        }

        public float ToplamAlisPuani()
        {
            return sepetliste.Sum(i => i.Urun.AlisPuani * i.Quantity);
        }

        public Siparis SiparisGetir(string kulAd)
        {
            var list = siparisYonetimi.HepsiniGetir();
            foreach (var item in list)
            {
                if (item.Musteri.KullaniciAdi.Equals(kulAd))
                {
                    return item;
                }
            }
            return null;
        }
        public Musteri MusteriGetir(string kulAd)
        {
            var list = musteriYonetimi.HepsiniGetir();
            foreach (var item in list)
            {
                if (item.KullaniciAdi.Equals(kulAd))
                {
                    return item;
                }
            }
            return null;
        }
    }
    public class Sepet_API
    {
        public Urun Urun { get; set; }
        public int Quantity { get; set; }
        public Masa Masa { get; set; }
      
    }
}