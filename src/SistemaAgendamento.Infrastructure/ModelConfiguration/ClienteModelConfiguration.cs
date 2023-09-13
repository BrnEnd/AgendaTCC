using Microsoft.EntityFrameworkCore;
using SistemaAgendamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Repository.ModelConfiguration
{
    public static class ClienteModelConfiguration
    {
        public static ModelBuilder ConfigureCliente(this ModelBuilder builder)
        {
            builder.Entity<Cliente>()
                .ToTable("Cliente");

            builder.Entity<Cliente>()
                .HasKey(x => x.IdCliente);

            builder.Entity<Cliente>()
                .Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Entity<Cliente>()
                .Property(x => x.Ativo)
                .HasColumnType("varchar(1)")
                .IsRequired();

            return builder;
        }
    }
}
