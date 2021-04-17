using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class MasaBilgisi : INesne
    {
        public int BilgiId { get; set; }
        public Masa Masa { get; set; }
        public Musteri Musteri { get; set; }
        public string AcilmaTarihi { get; set; }
        public string AcilmaZamani { get; set; }
       
    }
}
