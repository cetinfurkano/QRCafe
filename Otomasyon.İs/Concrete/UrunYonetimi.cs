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
    public class UrunYonetimi:Yonetim<Urun>
    {
       
        public UrunYonetimi(VeriTabani<Urun> veriTabani):base(veriTabani)
        {
        }

        public override List<Urun> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(Urun urun)
        {
            _veriTabani.Ekle(urun);
        }

        public override void Sil(Urun urun)
        {
            _veriTabani.Sil(urun);
        }

        public override void Guncelle(Urun urun)
        {
            _veriTabani.Guncelle(urun);
        }

    }
}
