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
    
    public partial class Masalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Masalar()
        {
            this.MasaBilgileri = new HashSet<MasaBilgileri>();
        }
    
        public string MasaId { get; set; }
        public string MusaitlikDurumu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasaBilgileri> MasaBilgileri { get; set; }
    }
}
