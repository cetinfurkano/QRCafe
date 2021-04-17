using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class GunSonu: INesne
    {
        public string UrunAdi { get; set; }
        public int UrunAdet { get; set; }
        public float Fiyat { get; set; }
      
    }
}
