using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
{
    public void Configure(EntityTypeBuilder<Mascota> builder)
    {
        builder.ToTable("Mascota");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.FechaNacimiento)
        .HasColumnType("datetime");

        builder.HasOne(p=> p.Razas)
        .WithMany(p => p.Mascotas)
        .HasForeignKey(p => p.IdRaza);

        builder.HasOne(p => p.Clientes)
        .WithMany(p => p.Mascostas)
        .HasForeignKey(p => p.IdCliente);
    }
}
