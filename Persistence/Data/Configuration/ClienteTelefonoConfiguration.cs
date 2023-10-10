using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ClienteTelefonoConfiguration : IEntityTypeConfiguration<ClienteTelefono>
{
    public void Configure(EntityTypeBuilder<ClienteTelefono> builder)
    {
        builder.ToTable("ClienteTelefono");
        
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id);

        builder.Property(t => t.Numero)
        .HasColumnName("Numero")
        .HasColumnType("int")
        .HasMaxLength(15);

        builder.HasOne(t => t.Clientes)
        .WithMany(p => p.ClientesTelefonos)
        .HasForeignKey(t => t.IdCliente);
        
    }
}
