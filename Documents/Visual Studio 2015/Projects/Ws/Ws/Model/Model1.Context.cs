﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ws.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sql8126141Entities : DbContext
    {
        public sql8126141Entities()
            : base("name=sql8126141Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<address> address { get; set; }
        public DbSet<client> client { get; set; }
        public DbSet<contact> contact { get; set; }
        public DbSet<employee> employee { get; set; }
        public DbSet<firm> firm { get; set; }
        public DbSet<log> log { get; set; }
        public DbSet<order> order { get; set; }
        public DbSet<payment> payment { get; set; }
        public DbSet<paymentdetail> paymentdetail { get; set; }
        public DbSet<price> price { get; set; }
        public DbSet<product> product { get; set; }
        public DbSet<productlist> productlist { get; set; }
        public DbSet<region> region { get; set; }
        public DbSet<role> role { get; set; }
        public DbSet<stock> stock { get; set; }
        public DbSet<stockdetail> stockdetail { get; set; }
        public DbSet<orderdetail> orderdetail { get; set; }
    }
}
