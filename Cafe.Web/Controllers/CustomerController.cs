using Cafe.Web.Models;
using Otomasyon.Veriler.Concrete;
using Otomasyon.İs.Concrete;
using Otomasyon.VeriErisim.Concrete.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe.Web.Controllers
{
    public class CustomerController : Controller
    {
        MusteriYonetimi musteriYonetimi = new MusteriYonetimi(new SQLMusteriDal());
        public ActionResult Index()
        {
            return View();
        }
        // GET: Customer
        [HttpPost]
        public ActionResult Index(Musteri musteri)
        {
            try
            {
                using (KafeEntities kafe = new KafeEntities())
                {
                    foreach (var item in musteriYonetimi.HepsiniGetir())
                    {
                        if (item.KullaniciAdi == musteri.KullaniciAdi || item.Eposta == musteri.Eposta)
                        {
                            return Json(new { msg = "Var olan bir kullanıcı adı ve Eposta girdiniz", durum = false }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        var musteriEkle = kafe.Musteriler.Add(new Musteriler()
                        {
                            Ad = musteri.Ad,
                            Eposta = musteri.Eposta,
                            KullaniciAdi = musteri.KullaniciAdi,
                            MusteriId = musteri.MusteriId,
                            Parola = musteri.Parola,
                            Soyad = musteri.Soyad,
                            KazanilanPuan = 0,
                        });
                        kafe.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { msg = "Hatalı Üye Olma İşlemi" + ex.Message.ToString(), durum = false, }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "Başarili", durum = true }, JsonRequestBehavior.AllowGet);

        }
    }
}