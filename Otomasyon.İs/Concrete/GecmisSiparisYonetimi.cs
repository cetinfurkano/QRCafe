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
    public class GecmisSiparisYonetimi:Yonetim<GecmisSiparis>
    {
        
        public GecmisSiparisYonetimi(VeriTabani<GecmisSiparis> veriTabani):base(veriTabani)
        {
        }

        public override List<GecmisSiparis> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(GecmisSiparis gecmisSiparis)
        {
            _veriTabani.Ekle(gecmisSiparis);
        }

      
    }
}
