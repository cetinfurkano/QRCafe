using Otomasyon.Veriler.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomasyon.VeriErisim.Abstracts
{
    public interface IVeriTabani<T> where T: class, INesne, new()
    {
        void Ekle(T veri);
        void Sil(T veri);
        void Guncelle(T veri);
        List<T> HepsiniGetir();

    }
}
