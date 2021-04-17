using Cafe.Web.Helper;
using Cafe.Web.Models;
using Otomasyon.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe.Web.Controllers
{
    public class CartController : Controller
    {
        KafeEntities entities = new KafeEntities();
        // GET: Cart
        public ActionResult Index(Siparis siparis)
        {
            return View();
        }
    }
}