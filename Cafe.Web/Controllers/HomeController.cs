using Otomasyon.İs.Concrete;
using Otomasyon.VeriErisim.Concrete.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomasyon.Veriler.Concrete;
using System.IO;
using System.Drawing;
using System.Data.Entity;
using Cafe.Web.Helper;

namespace Otomasyon.Web.Controllers
{
    [_SessionControl]
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ResimGetir();
            return View();
        }
        public ActionResult _UstKategori()
        {
            UstKategoriYonetimi ustKategoriYonetimi = new UstKategoriYonetimi(new SQLUstKategoriDal());
            var ustKategoriListele = ustKategoriYonetimi.HepsiniGetir();
            return PartialView("_UstKategori", ustKategoriListele);
        }
        private void ResimGetir()
        {
            UrunResimYonetimi resimYonetimi = new UrunResimYonetimi(new SQLUrunResmiDal());
            var resimListesi = resimYonetimi.HepsiniGetir();

            var adres = Server.MapPath("~/Content/KafeResimleri/");

            if (!Directory.Exists(adres))
                Directory.CreateDirectory(adres);

            for (int i = 0; i < resimListesi.Count; i++)
            {
                using (MemoryStream ms = new MemoryStream(resimListesi[i].Resim))
                {
                    var img = Image.FromStream(ms);
                    img.Save(adres + resimListesi[i].ResimAdi);
                }
            }
        }

    }
}