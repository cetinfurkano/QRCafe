using Otomasyon.İs.Concrete;
using Otomasyon.VeriErisim.Concrete.Sql;
using System;
using Otomasyon.Veriler.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Cafe.Web.Controllers
{
    public class UyeFormController : Controller
    {
        // GET: UyeForm
        public JsonResult Index()
        {
            MusteriYonetimi musteriYonetimi = new MusteriYonetimi(new SQLMusteriDal());
            if (ModelState.IsValid)
            {

            }
            return Json(JsonRequestBehavior.AllowGet);
            
        }
    }
}