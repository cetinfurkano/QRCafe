using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
   public class UstKategori:INesne
    {
        public int UstKategoriId { get; set; }
        public string UstKategoriAdi { get; set; }
        public bool AktifMi { get; set; }
    }
}
