using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class SiparisDetayi:INesne
    {
        public int DetayId { get; set; }
        public Siparis Siparis { get; set; }
        public Urun Urun { get; set; }
    }
}
