using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cafe.Web.Helper
{
    public class SiparisDetay
    {
        [Required(ErrorMessage ="Lütfen Kartın Üstündeki İsmi Giriniz")]
        public string KartAdi { get; set; }
        [Required(ErrorMessage = "Lütfen Kart Numarasını Giriniz")]
        public string KartNo { get; set; }
        public string MasaNumarasi { get; set; }
       
    }
}