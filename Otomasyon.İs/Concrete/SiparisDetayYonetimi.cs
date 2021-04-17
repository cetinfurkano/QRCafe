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
    public class SiparisDetayYonetimi:Yonetim<SiparisDetayi>
    {
        public SiparisDetayYonetimi(VeriTabani<SiparisDetayi> veriTabani) : base(veriTabani)
        {
        }

        public override List<SiparisDetayi> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(SiparisDetayi siparisDetayi)
        {
            _veriTabani.Ekle(siparisDetayi);
        }

        public override void Sil(SiparisDetayi siparisDetayi)
        {
            _veriTabani.Sil(siparisDetayi);
        }

        public override void Guncelle(SiparisDetayi siparisDetayi)
        {
            _veriTabani.Guncelle(siparisDetayi);
        }
    }
}
