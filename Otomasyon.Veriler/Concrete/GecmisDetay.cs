using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class GecmisDetay:INesne
    {
        public int GecmisDetayId { get; set; }
        public GecmisSiparis GecmisSiparis { get; set; }
        public Urun GecmisUrun { get; set; }
        public float GecmisFiyat { get; set; }

    }
}
