using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("Ciudad");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(p => p.NombreCiudad)
        .HasColumnName("Nombre")
        .HasColumnType("varchar")
        .HasMaxLength(50);
                
        //relacion de uno a muchos
        builder.HasOne(t => t.Departamentos)
        .WithMany(p => p.Ciudades)
        .HasForeignKey(p => p.IdDep);
    }
}
