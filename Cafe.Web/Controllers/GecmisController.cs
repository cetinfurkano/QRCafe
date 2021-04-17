using Cafe.Web.Helper;
using Otomasyon.İs.Concrete;
using Otomasyon.VeriErisim.Concrete.Sql;
using Otomasyon.Veriler.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace Cafe.Web.Controllers
{
    [Authorize]
    public class GecmisController : Controller
    {
        
        // GET: Gecmis
        public ActionResult Index()
        {
            return View();
        }
    }
}