﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiteratureWritten.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class linar2Entities : DbContext
    {
        public linar2Entities()
            : base("name=linar2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        public virtual DbSet<EditionReceiving> EditionReceiving { get; set; }
        public virtual DbSet<Editions> Editions { get; set; }
        public virtual DbSet<EditionType> EditionType { get; set; }
        public virtual DbSet<Periodicity> Periodicity { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SubscribedEditions> SubscribedEditions { get; set; }
        public virtual DbSet<SubscriptionTerm> SubscriptionTerm { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
