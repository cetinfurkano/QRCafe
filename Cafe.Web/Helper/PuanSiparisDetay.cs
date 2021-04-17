using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cafe.Web.Helper
{
    public class PuanSiparisDetay
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Soyad { get; set; }
        public string MasaNumarasi { get; set; }
    }
}