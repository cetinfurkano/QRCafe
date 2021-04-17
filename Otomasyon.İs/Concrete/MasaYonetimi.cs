using Otomasyon.VeriErisim.Concrete.Sql;
using Otomasyon.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.VeriErisim.Abstracts;
using Otomasyon.İs.Abstracts;

namespace Otomasyon.İs.Concrete
{
   public class MasaYonetimi:Yonetim<Masa>
   {
       public MasaYonetimi(VeriTabani<Masa> veriTabani):base(veriTabani)
       {
        }
        
       public override List<Masa> HepsiniGetir()
       {
           return _veriTabani.HepsiniGetir();
       }

       public override void Ekle(Masa masa)
       {
           _veriTabani.Ekle(masa);
       }

       public override void Sil(Masa masa)
       {
           _veriTabani.Sil(masa);
       }

       public override void Guncelle(Masa masa)
       {
           _veriTabani.Guncelle(masa);
       }
        
   }
}
