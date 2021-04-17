using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafe.Web.Helper;
using Otomasyon.İs.Concrete;
using Otomasyon.VeriErisim.Concrete.Sql;

namespace Otomasyon.Web.Controllers
{
    [_SessionControl]
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
      
    }
}