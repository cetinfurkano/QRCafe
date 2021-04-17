using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.VeriErisim.Abstracts;
using Otomasyon.Veriler.Concrete;
using Otomasyon.İs.Abstracts;

namespace Otomasyon.İs.Concrete
{
    public class GecmisDetayYonetimi:Yonetim<GecmisDetay>
    {

        public GecmisDetayYonetimi(VeriTabani<GecmisDetay> veriTabani): base(veriTabani)
        {
        }

        public override List<GecmisDetay> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(GecmisDetay gecmisDetay)
        {
            _veriTabani.Ekle(gecmisDetay);
        }
    }
}
