using Gestor_de_gastos_pessoais_data.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.EntitiesConfiguration
{
    public class GastosConfiguration : IEntityTypeConfiguration<Gastos>
    {
        public void Configure(EntityTypeBuilder<Gastos> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(g => g.Valor)
                .IsRequired();

            builder.Property(g => g.Data)
                .IsRequired();

            builder.HasOne(g => g.LocalGasto)
                .WithMany()
                .HasForeignKey(g => g.LocalGastoid)
                .HasConstraintName("FK_gastos_localGastos_LocalGastoid");

            builder.HasOne(g => g.tipoGastos)
                .WithMany()
                .HasForeignKey(g => g.TipoGastosId)
                .IsRequired()
                .HasConstraintName("FK_gastos_tipoGastos_TipoGastosId");

            builder.HasOne(g => g.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(g => g.UsuarioSistemaId)
                .HasConstraintName("FK_gastos_AspNetUsers_UserId");
        }
    }

    public class TipoGastosConfiguration : IEntityTypeConfiguration<TipoGastos>
    {
        public void Configure(EntityTypeBuilder<TipoGastos> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Descricao)
                .HasMaxLength(100)
                .IsRequired();
        }
    }

    public class LocalGastoConfiguration : IEntityTypeConfiguration<LocalGasto>
    {
        public void Configure(EntityTypeBuilder<LocalGasto> builder)
        {
            builder.HasKey(l => l.id);

            builder.Property(l => l.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(l => l.Cnhpj)
                .HasMaxLength(20);

            builder.Property(l => l.Telefone)
                .HasMaxLength(20);
        }
    }


}
