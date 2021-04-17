using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.VeriErisim.Abstracts;
using Otomasyon.Veriler.Concrete;
using Otomasyon.İs.Abstracts;

namespace Otomasyon.İs.Concrete
{
   public class UrunResimYonetimi:Yonetim<UrunResmi>
    {
       

        public UrunResimYonetimi(VeriTabani<UrunResmi> veriTabani) :base(veriTabani)
        {
        }

        public override List<UrunResmi> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(UrunResmi urunResmi)
        {
            _veriTabani.Ekle(urunResmi);
        }

        public override void Sil(UrunResmi urunResmi)
        {
            _veriTabani.Sil(urunResmi);
        }

        public override void Guncelle(UrunResmi urunResmi)
        {
            _veriTabani.Guncelle(urunResmi);
        }
        
    }
}
