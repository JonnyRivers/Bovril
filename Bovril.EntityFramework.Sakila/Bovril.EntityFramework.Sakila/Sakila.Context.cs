﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bovril.EntityFramework.Sakila
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sakilaEntities : DbContext
    {
        public sakilaEntities()
            : base("name=sakilaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<actor> actors { get; set; }
        public DbSet<address> addresses { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<city> cities { get; set; }
        public DbSet<country> countries { get; set; }
        public DbSet<customer> customers { get; set; }
        public DbSet<film> films { get; set; }
        public DbSet<film_actor> film_actor { get; set; }
        public DbSet<film_category> film_category { get; set; }
        public DbSet<film_text> film_text { get; set; }
        public DbSet<inventory> inventories { get; set; }
        public DbSet<language> languages { get; set; }
        public DbSet<payment> payments { get; set; }
        public DbSet<rental> rentals { get; set; }
        public DbSet<staff> staffs { get; set; }
        public DbSet<store> stores { get; set; }
    }
}
