//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cafe.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UrunResimleri
    {
        public int ResimId { get; set; }
        public string ResimAdi { get; set; }
        public string ResimYolu { get; set; }
        public byte[] Resim { get; set; }
        public int UrunId { get; set; }
    
        public virtual Urunler Urunler { get; set; }
    }
}