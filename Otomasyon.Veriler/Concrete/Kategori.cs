using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class Kategori:INesne
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public UstKategori UstKategori { get; set; }
        public bool AktifMi { get; set; }

      
    }
}
