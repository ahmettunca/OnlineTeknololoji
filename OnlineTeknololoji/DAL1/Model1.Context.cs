﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineTeknololoji.DAL1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class teknomarketDB1Entities : DbContext
    {
        public teknomarketDB1Entities()
            : base("name=teknomarketDB1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FotoTablo> FotoTablo { get; set; }
        public virtual DbSet<GonderimDetayTablo> GonderimDetayTablo { get; set; }
        public virtual DbSet<KategoriTablo> KategoriTablo { get; set; }
        public virtual DbSet<RollerTablo> RollerTablo { get; set; }
        public virtual DbSet<sepetDurumuTablo> sepetDurumuTablo { get; set; }
        public virtual DbSet<SepetTablo> SepetTablo { get; set; }
        public virtual DbSet<Uyeler> Uyeler { get; set; }
        public virtual DbSet<UyeRolTablo> UyeRolTablo { get; set; }
        public virtual DbSet<UrunTablo> UrunTablo { get; set; }
    }
}
