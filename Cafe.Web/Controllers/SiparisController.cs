using Cafe.Web.Helper;
using Otomasyon.İs.Concrete;
using Otomasyon.VeriErisim.Concrete.Sql;
using Otomasyon.Veriler.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Cafe.Web.Models;
using System;
using System.Web;

namespace Cafe.Web.Controllers
{
    [_SessionControl]
    [Authorize]
    public class SiparisController : Controller
    {
        private List<Urun> urunListesi;
        MasaYonetimi masaYonetimi = new MasaYonetimi(new SQLMasaDal());
        MasaBilgiYonetimi bilgiYonetimi = new MasaBilgiYonetimi(new SQLMasaBilgileriDal());

        public SiparisController()
        {
            UrunYonetimi urunYonetimi = new UrunYonetimi(new SQLUrunDal());
            urunListesi = urunYonetimi.HepsiniGetir();
        }
        // GET: Siparis
        public ActionResult Index()
        {
            return View(GetSiparis());
        }
        public ActionResult SepeteEkle(int UrunId)
        {
            var urun = urunListesi.Where(i => i.UrunId == UrunId).FirstOrDefault();
            if (urun != null)
            {
                GetSiparis().UrunEkle(urun, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult SepettenSil(int UrunId)
        {
            var urun = urunListesi.Where(i => i.UrunId == UrunId).FirstOrDefault();
            if (urun != null)
            {
                GetSiparis().UrunSil(urun);
            }
            return RedirectToAction("Index");
        }
        public Sepet GetSiparis()
        {
            var siparis = (Sepet)Session["Siparis"];
            if (siparis == null)
            {
                siparis = new Sepet();
                Session["Siparis"] = siparis;
            }
            return siparis;
        }
        public ActionResult Tamamla()
        {
            return View(new SiparisDetay());
        }
        [HttpPost]
        public ActionResult Tamamla(SiparisDetay siparisDetay)
        {
            var siparis = GetSiparis();
            if (siparis.sepet_s.Count == 0)
            {
                ModelState.AddModelError("", "Sepetinizde Ürün Bulunmamaktadır");
            }
            if (ModelState.IsValid)
            {
                var login = User.Identity.Name;
                var bilgiler = bilgiYonetimi.HepsiniGetir();
                if (bilgiler != null)
                {
                    foreach (var item in bilgiler)
                    {
                        if (item.Musteri.KullaniciAdi.Equals(login))
                        {
                            if (GetSiparis().SiparisGetir(login) != null)
                            {
                                return View("Hatali");
                            }
                            else
                            {
                                GetSiparis().SiparisTamamla();
                                siparis.Temizle();
                                return View("Tamamlandi");
                            }
                        }
                    }
                }
                GetSiparis().SiparisTamamla();
                MasayaOtur(siparisDetay);
                siparis.Temizle();
                return View("Tamamlandi");
            }
            else
            {
                return View(siparisDetay);
            }
        }
        public ActionResult PuanlaTamamla()
        {
            return View(new PuanSiparisDetay());
        }
        [HttpPost]
        public ActionResult PuanlaTamamla(PuanSiparisDetay puanSiparisDetay)
        {
            var siparis = GetSiparis();
            if (siparis.sepet_s.Count == 0)
            {
                ModelState.AddModelError("", "Sepetinizde Ürün Bulunmamaktadır");
            }
            if (ModelState.IsValid)
            {
                var login = User.Identity.Name;
                var bilgiler = bilgiYonetimi.HepsiniGetir();
                if (bilgiler != null)
                {
                    foreach (var item in bilgiler)
                    {
                        if (item.Musteri.KullaniciAdi.Equals(login))
                        {
                            if (GetSiparis().SiparisGetir(login) != null)
                            {
                                return View("Hatali");
                            }
                           else
                            {
                                if (GetSiparis().ToplamPuan() == GetSiparis().PuanIslemleri())
                                {
                                    return View("YetmeyenPuan");
                                }
                                else
                                {
                                    GetSiparis().SiparisTamamlaPuan();
                                    siparis.Temizle();
                                    return View("Tamamlandi");
                                }
                              
                            }
                        }
                    }
                }
                if (GetSiparis().ToplamPuan() == GetSiparis().PuanIslemleri())
                {
                    return View("YetmeyenPuan");
                }
                else
                {
                    GetSiparis().SiparisTamamlaPuan();
                    MasayaOtur(puanSiparisDetay);
                    siparis.Temizle();
                    return View("Tamamlandi");
                }

            }
            else
            {
                return View(puanSiparisDetay);
            }
        }


        public void MasayaOtur(PuanSiparisDetay puandetay1)
        {
            var login = User.Identity.Name;
            var musteri = GetSiparis().MusteriGetir(login);
            var masa = MasaGetir(puandetay1.MasaNumarasi);
            bilgiYonetimi.Ekle(new MasaBilgisi
            {
                AcilmaTarihi = DateTime.Now.ToString("dd.MM.yyyy"),
                AcilmaZamani = DateTime.Now.ToString("HH:mm"),
                Musteri = musteri,
                Masa = masa
            });
        }

        public Masa MasaGetir(string MasaId)
        {
            var list = masaYonetimi.HepsiniGetir();
            foreach (var item in list)
            {
                if (item.MasaId == MasaId)
                {
                    return item;
                }
            }
            return null;
        }
        public void MasayaOtur(SiparisDetay detay1)
        {
            var login = User.Identity.Name;
            var musteri = GetSiparis().MusteriGetir(login);
            var masa = MasaGetir(detay1.MasaNumarasi);
            bilgiYonetimi.Ekle(new MasaBilgisi
            {
                AcilmaTarihi = DateTime.Now.ToString("dd.MM.yyyy"),
                AcilmaZamani = DateTime.Now.ToString("HH:mm"),
                Musteri = musteri,
                Masa = masa
            });
        }
        public PartialViewResult _Point()
        {
            return PartialView(GetSiparis());
        }
    }
}