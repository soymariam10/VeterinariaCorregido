using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id);

        builder.Property(p => p.Nombre)
        .HasColumnName("Nombre")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(p => p.Apellido)
        .HasColumnName("Apellido")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(p => p.Email)
        .HasColumnName("Email")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

    }
}
