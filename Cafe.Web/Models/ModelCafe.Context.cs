﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KafeEntities : DbContext
    {
        public KafeEntities()
            : base("name=KafeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GecmisDetaylar> GecmisDetaylar { get; set; }
        public virtual DbSet<GecmisSiparisler> GecmisSiparisler { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Masalar> Masalar { get; set; }
        public virtual DbSet<Musteriler> Musteriler { get; set; }
        public virtual DbSet<SiparisDetaylari> SiparisDetaylari { get; set; }
        public virtual DbSet<Siparisler> Siparisler { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<UrunResimleri> UrunResimleri { get; set; }
        public virtual DbSet<UstKategoriler> UstKategoriler { get; set; }
        public virtual DbSet<MasaBilgileri> MasaBilgileri { get; set; }
    }
}
