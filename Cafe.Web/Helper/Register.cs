using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cafe.Web.Helper
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Ad { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public string Soyad { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string KullaniciAdi { get; set; }
        [Required]
        [DisplayName("Parolanız")]
        public string Parola { get; set; }
        [Required]
        [DisplayName("EPosta")]
        [EmailAddress(ErrorMessage ="Eposta adresinizi düzgün giriniz")]
        public string Eposta { get; set; }
    }
}