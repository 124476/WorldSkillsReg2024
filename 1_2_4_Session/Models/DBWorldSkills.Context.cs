﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1_2_4_Session.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Session_1_2_4_2024Entities : DbContext
    {
        public Session_1_2_4_2024Entities()
            : base("name=Session_1_2_4_2024Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Diagnoz> Diagnoz { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Meroprition> Meroprition { get; set; }
        public virtual DbSet<Otdel> Otdel { get; set; }
        public virtual DbSet<Pacient> Pacient { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Pol> Pol { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tip> Tip { get; set; }
    }
}
