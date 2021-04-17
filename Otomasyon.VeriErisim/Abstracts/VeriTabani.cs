using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.VeriErisim.Abstracts
{
    public abstract class VeriTabani<T> where T: class, INesne, new()
    {
        protected string yol = @"Data Source=FURKAN-PC;Initial Catalog = KafeOtomasyonu; Integrated Security = True;MultipleActiveResultSets=True;";
        protected SqlConnection _sqlConnection;
        protected SqlCommand _sqlCommand;

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

