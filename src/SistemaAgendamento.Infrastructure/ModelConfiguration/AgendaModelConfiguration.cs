using Microsoft.EntityFrameworkCore;
using SistemaAgendamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Repository.ModelConfiguration
{
    public static class AgendaModelConfiguration
    {
        public static ModelBuilder ConfigureAgenda(this ModelBuilder builder)
        {
            builder.Entity<Agenda>()
                .ToTable("Agenda");

            builder.Entity<Agenda>()
                .HasOne(e => e.Estabelecimento)
                .WithOne(a => a.Agenda);

            builder.Entity<Agenda>()
                .HasKey(a => a.IdAgenda);

            builder.Entity<Agenda>()
                .Property(a => a.AgendaAberta)
                .HasColumnType("char")
                .IsRequired();

            return builder;
        }
    }
}
