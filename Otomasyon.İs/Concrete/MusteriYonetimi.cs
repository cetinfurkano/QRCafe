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
    public class MusteriYonetimi:Yonetim<Musteri>
    {
       
        public MusteriYonetimi(VeriTabani<Musteri> veriTabani):base(veriTabani)
        {
           
        }

        public override List<Musteri> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(Musteri musteri)
        {
            _veriTabani.Ekle(musteri);
        }

        public override void Sil(Musteri musteri)
        {
            _veriTabani.Sil(musteri);
        }

        public override void Guncelle(Musteri musteri)
        {
            _veriTabani.Guncelle(musteri);
        }

    }
}
