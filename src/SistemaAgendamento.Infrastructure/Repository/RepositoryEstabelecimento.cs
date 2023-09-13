
using Microsoft.EntityFrameworkCore;
using SistemaAgendamento.Domain.Interfaces;
using SistemaAgendamento.Domain.Models;
using SistemaAgendamento.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Repository.Repository
{
    public class RepositoryEstabelecimento : Repository<Estabelecimento>, IEstabelecimentoRepository
    {
        public RepositoryEstabelecimento(AppDbContext context) : base(context)
        {
        }
        public List<Estabelecimento> GetEstabelecimentosAtivos()
        {
            return _context.Set<Estabelecimento>().AsNoTracking().Where(p => p.Ativo.Equals("S")).ToList();
        }
    }
    
}
