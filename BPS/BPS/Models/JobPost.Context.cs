﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BPS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BuildersEntities : DbContext
    {
        public BuildersEntities()
            : base("name=BuildersEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BuildingType> BuildingTypes { get; set; }
        public virtual DbSet<Job_Post> Job_Post { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
    }
}