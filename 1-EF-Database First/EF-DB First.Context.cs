﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1_EF_Database_First
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gl3tp2Act1Entities : DbContext
    {
        public gl3tp2Act1Entities()
            : base("name=gl3tp2Act1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<marques> marques { get; set; }
        public virtual DbSet<personnes> personnes { get; set; }
        public virtual DbSet<voitures> voitures { get; set; }
    }
}
