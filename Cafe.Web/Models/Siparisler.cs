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
    
    public partial class Siparisler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Siparisler()
        {
            this.SiparisDetaylari = new HashSet<SiparisDetaylari>();
        }
    
        public int SiparisId { get; set; }
        public int MusteriId { get; set; }
        public string VerilmeZamani { get; set; }
        public string VerilmeTarihi { get; set; }
    
        public virtual Musteriler Musteriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetaylari> SiparisDetaylari { get; set; }
    }
}