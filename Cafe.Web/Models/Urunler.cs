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
    
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.GecmisDetaylar = new HashSet<GecmisDetaylar>();
            this.SiparisDetaylari = new HashSet<SiparisDetaylari>();
            this.UrunResimleri = new HashSet<UrunResimleri>();
        }
    
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int StokDuzeyi { get; set; }
        public double Fiyat { get; set; }
        public double UrunPuani { get; set; }
        public int KategoriId { get; set; }
        public string AktifMi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GecmisDetaylar> GecmisDetaylar { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetaylari> SiparisDetaylari { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunResimleri> UrunResimleri { get; set; }
    }
}