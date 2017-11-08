using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.EF.Modelo.ConfiguracionModelo
{
    class VeterinarioConfig : EntityTypeConfiguration<Veterinario>
    {
        public VeterinarioConfig()
        {
            this.HasKey(t => new { t.ID });
            this.ToTable("Veterinarios");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Especialidad).HasColumnName("Especialidad");
        }
    }
}
