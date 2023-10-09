using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ClienteDireccionConfiguration : IEntityTypeConfiguration<ClienteDireccion>
{
    public void Configure(EntityTypeBuilder<ClienteDireccion> builder)
    {
        builder.ToTable("Direccion");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(p => p.TipoDeVia)
        .HasColumnName("TipodeVia")
        .HasColumnType("varchar")
        .HasMaxLength(20)
        .IsRequired();
    }
}
