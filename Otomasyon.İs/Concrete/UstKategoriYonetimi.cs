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
    public class UstKategoriYonetimi:Yonetim<UstKategori>
    {
        
        public UstKategoriYonetimi(VeriTabani<UstKategori> veriTabani):base(veriTabani)
        {
            
        }

        public override List<UstKategori> HepsiniGetir()
        {
            return _veriTabani.HepsiniGetir();
        }

        public override void Ekle(UstKategori ustKategori)
        {
            _veriTabani.Ekle(ustKategori);
        }

        public override void Sil(UstKategori ustKategori)
        {
            _veriTabani.Sil(ustKategori);
        }

        public override void Guncelle(UstKategori ustKategori)
        {
            _veriTabani.Guncelle(ustKategori);
        }
    }
}
