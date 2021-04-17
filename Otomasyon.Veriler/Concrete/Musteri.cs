using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class Musteri:INesne
    {
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public float KazanilanPuan { get; set; }
        public string Eposta { get; set; }
        
    }
}
