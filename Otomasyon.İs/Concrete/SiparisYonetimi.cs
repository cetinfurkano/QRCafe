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
    public class SiparisYonetimi:Yonetim<Siparis>
    {
        public SiparisYonetimi(VeriTabani<Siparis> veriTabani):base(veriTabani)
        {
        }

        public override List<Siparis> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(Siparis siparis)
        {
            _veriTabani.Ekle(siparis);
        }

        public override void Sil(Siparis siparis)
        {
            _veriTabani.Sil(siparis);
        }

        public override void Guncelle(Siparis siparis)
        {
            _veriTabani.Guncelle(siparis);
        }

    }
}
