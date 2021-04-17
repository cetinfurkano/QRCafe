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
    public class KategoriYonetimi:Yonetim<Kategori>
    {
        public KategoriYonetimi(VeriTabani<Kategori> veriTabani):base(veriTabani)
        {
           
        }

        public override List<Kategori> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(Kategori kategori)
        {
            _veriTabani.Ekle(kategori);
        }

        public override void Sil(Kategori kategori)
        {
            _veriTabani.Sil(kategori);
        }

        public override void Guncelle(Kategori kategori)
        {
            _veriTabani.Guncelle(kategori);
        }
    }
}
