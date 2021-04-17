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
    public class GunSonuYonetimi : Yonetim<GunSonu>
    {
        public override List<GunSonu> HepsiniGetir()
        {
           return _veriTabani.HepsiniGetir();
        }

        public GunSonuYonetimi(VeriTabani<GunSonu> veriTabani) : base(veriTabani)
        {
        }

    }
}
