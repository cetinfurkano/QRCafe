using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class UrunResmi:INesne
    {
        public int ResimId { get; set; }
        public string ResimAdi { get; set; }
        public string ResimYolu { get; set; }
        public byte[] Resim { get; set; }
        public Urun Urun { get; set; }
    }
}
