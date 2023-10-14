using Microsoft.EntityFrameworkCore;
using SistemaAgendamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Repository.ModelConfiguration
{
    public static class AgendamentoModelConfiguration
    {
        public static ModelBuilder ConfigureAgendamento(this ModelBuilder builder)
        {
            builder.Entity<Agendamento>()
                .ToTable("Agendamento");

            builder.Entity<Agendamento>()
                .HasKey(a => a.IdAgendamento);

            builder.Entity<Agendamento>()
                .Property(a => a.NomeEstabelecimento)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Entity<Agendamento>()
                .Property(a => a.DiaHoraAgendamento)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Entity<Agendamento>()
                .Property(a => a.NomeCliente)
                .HasColumnType("varchar(100)")
                .IsRequired();
           
            builder.Entity<Agendamento>()
                .Property(a => a.NomeProcedimento)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Entity<Agendamento>()
                .Property(a => a.StatusAgendamento)
                .HasConversion<int>()
                .IsRequired();

            return builder;
        }
    }
}
