﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurismoExel.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PW3_20172C_TP_TurismoEntities : DbContext
    {
        public PW3_20172C_TP_TurismoEntities()
            : base("name=PW3_20172C_TP_TurismoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Paquete> Paquete { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}