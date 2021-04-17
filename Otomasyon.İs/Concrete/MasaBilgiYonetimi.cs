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
   public class MasaBilgiYonetimi:Yonetim<MasaBilgisi>
   {
        public MasaBilgiYonetimi(VeriTabani<MasaBilgisi> veriTabani) : base(veriTabani)
        {
            
        }

        public override List<MasaBilgisi> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(MasaBilgisi masaBilgileri)
        {
            _veriTabani.Ekle(masaBilgileri);
        }

        public override void Sil(MasaBilgisi masaBilgileri)
        {
            _veriTabani.Sil(masaBilgileri);
        }

        public override void Guncelle(MasaBilgisi masaBilgileri)
        {
            _veriTabani.Guncelle(masaBilgileri);
        }

    }
}
