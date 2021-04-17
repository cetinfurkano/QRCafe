using Cafe.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe.Web.Controllers
{
    [_SessionControl]
    [Authorize]
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Index()
        {
            return View();
        }
    }
}