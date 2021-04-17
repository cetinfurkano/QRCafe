using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.VeriErisim.Abstracts;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.İs.Abstracts
{
    public abstract class Yonetim<T> where T: class, INesne, new()
    {
        protected VeriTabani<T> _veriTabani;

        public Yonetim(VeriTabani<T> veriTabani)
        {
            _veriTabani = veriTabani;
        }

        public virtual void Ekle(T veri)
        {
            return;
        }

        public virtual void Sil(T veri)
        {
            return;
        }

        public virtual void Guncelle(T veri)
        {
            return;
        }

        public abstract List<T> HepsiniGetir();
    }
}
