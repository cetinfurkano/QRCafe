using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.Veriler.Abstracts;

namespace Otomasyon.Veriler.Concrete
{
    public class Masa:INesne
    {
        public string MasaId { get; set; }
        public bool MusaitlikDurumu { get; set; }

    }
}
