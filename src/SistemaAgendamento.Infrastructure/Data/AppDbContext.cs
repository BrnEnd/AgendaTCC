using Microsoft.EntityFrameworkCore;
using SistemaAgendamento.Domain.Models;
using SistemaAgendamento.Repository.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureEstabelecimento();
            builder.ConfigureAgendamento();
        }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
