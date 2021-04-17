using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class GecmisSiparis:INesne
    {
        public int GecmisSiparisId { get; set; }
        public Musteri Musteri { get; set; }
        public string VerilmeTarihi { get; set; }
        public string VerilmeZamani { get; set; }
        public string TeslimTarihi{ get; set; }
        public string TeslimZamani { get; set; }

    }
}
