﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tiorem.agent.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TIOREMEntities : DbContext
    {
        public TIOREMEntities()
            : base("name=TIOREMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleTag> ArticleTag { get; set; }
        public virtual DbSet<CatalogueCategory> CatalogueCategory { get; set; }
        public virtual DbSet<CatalogueSource> CatalogueSource { get; set; }
        public virtual DbSet<CatalogueTag> CatalogueTag { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
