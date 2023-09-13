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
             .HasOne(e => e.Agenda)
             .WithMany(a => a.Agendamentos);

            builder.Entity<Agendamento>()
                .Property(a => a.DiaHoraAgendamento)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Entity<Agendamento>()
                .Property(a => a.StatusAgendamento)
                .HasConversion<int>()
                .IsRequired();

            builder.Entity<Agendamento>()
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Agendamentos);


            return builder;
        }
    }
}
