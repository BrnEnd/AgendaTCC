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
    public class RepositoryAgendamento : Repository<Agendamento>, IAgendamentoRepository
    {
        public RepositoryAgendamento(AppDbContext context) : base(context)
        {
        }

        public string AddNewAgendamento(Agendamento agendamento)
        {      

                //var _agendamento = new Agendamento(Guid.NewGuid(), agendamento.DiaHoraAgendamento, agendamento.StatusAgendamento, agendamento.NomeCliente, agendamento.NomeProcedimento, agendamento.NomeEstabelecimento);
                
                _context.Agendamentos.Add(agendamento);
                _context.SaveChanges();
                return "Agendamento realizado com sucesso!";
          
        }

        public string CancelarAgendamento(Agendamento agendamento)
        {
            agendamento.StatusAgendamento = (int)Status.Cancelado;
            _context.Update(agendamento);
            _context.SaveChanges();
            return "Agendamento cancelado com sucesso!";
        }

        public Estabelecimento GetEstabelecimentoByName(string name)
        {
            return _context.Set<Estabelecimento>().Where(x => x.NomeEstabelecimento.Contains(name)).FirstOrDefault();
        }

    }
    
}
