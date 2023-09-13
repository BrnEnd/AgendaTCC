using Microsoft.EntityFrameworkCore;
using SistemaAgendamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Repository.ModelConfiguration
{
    public static class EstabelecimentoModelConfiguration
    {
        public static ModelBuilder ConfigureEstabelecimento(this ModelBuilder builder)
        {
            builder.Entity<Estabelecimento>()
                .ToTable("Estabelecimento");

            builder.Entity<Estabelecimento>()
                .HasOne(a => a.Agenda)
                .WithOne(e => e.Estabelecimento)
                .HasForeignKey<Agenda>(a => a.IdAgenda);

            builder.Entity<Estabelecimento>()
                .HasKey(x => x.IdEstabelecimento);

            builder.Entity<Estabelecimento>()
                .Property(x => x.NomeEstabelecimento)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Entity<Estabelecimento>()
                .Property(x => x.NomeProfissional)
                .HasColumnType("varchar(100)");

            builder.Entity<Estabelecimento>()
                .Property(x => x.Ativo)
                .HasColumnType("char");

            return builder;
        }
    }
}
