using Otomasyon.İs.Concrete;
using Otomasyon.VeriErisim.Concrete.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using Otomasyon.Veriler.Concrete;

namespace Cafe.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Home");
        }
        [HttpPost, AllowAnonymous]
        public ActionResult Login(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                MusteriYonetimi musteriYonetimi = new MusteriYonetimi(new SQLMusteriDal());
                var musteriListesi = musteriYonetimi.HepsiniGetir();

                var login = musteriListesi.Where(i => i.KullaniciAdi == musteri.KullaniciAdi && i.Parola == musteri.Parola).FirstOrDefault();
                if (login != null)
                {
                    FormsAuthentication.SetAuthCookie(musteri.KullaniciAdi, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                }
            }
            return View(musteri);
        }
        [ValidateInput(false)]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}