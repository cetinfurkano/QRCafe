using Cafe.Web.Models;
using Otomasyon.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe.Web.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //Yeni Müsteri Üye
        public JsonResult Index(Musteri musteri)
        {
            try
            {
                using (KafeEntities kafe = new KafeEntities())
                {
                    if (ModelState.IsValid)
                    {
                        var musteriEkle = kafe.Musteriler.Add(new Musteriler()
                        {
                            Ad=musteri.Ad,
                            Eposta=musteri.Eposta,
                            KullaniciAdi=musteri.KullaniciAdi,
                            MusteriId=musteri.MusteriId,
                            Parola=musteri.Parola,
                            Soyad=musteri.Soyad,
                            KazanilanPuan=0,
                        });
                        kafe.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { msg = "Hatalı Üyelik"+ex.Message.ToString(), durum = false, }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "Başarılı", durum = true }, JsonRequestBehavior.AllowGet);
        }

    }
}