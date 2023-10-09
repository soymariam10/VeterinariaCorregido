using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id);

        builder.Property(p => p.NombreDepartamento)
        .HasMaxLength(50)
        .IsRequired();

        //relacion de uno a muchos
        builder.HasOne(t => t.Paises)
        .WithMany(p => p.Departamentos)
        .HasForeignKey(p => p.IdPais);

    }
}
