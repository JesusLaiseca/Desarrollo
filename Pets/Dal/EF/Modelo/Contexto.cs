using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using Dal.EF.Modelo.ConfiguracionModelo;
using Entities;


namespace Dal.EF.Modelo
{
    public class Contexto:DbContext
    {
            public DbSet<Veterinario> Veterinarios { get; set; }

            public Contexto()
                : base("DefaultConnection")
        {
            Database.SetInitializer<Contexto>(null);

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new VeterinarioConfig());

            
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
