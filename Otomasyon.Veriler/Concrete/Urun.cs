using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class Urun:INesne
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public Kategori Kategori { get; set; }
        public float Fiyat { get; set; }
        public int StokDuzeyi { get; set; }
        public float UrunPuani { get; set; }
        public bool AktifMi { get; set; }
        public float AlisPuani { get; set; }
       
    }
}
