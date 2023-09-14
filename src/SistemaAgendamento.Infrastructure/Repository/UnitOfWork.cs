using SistemaAgendamento.Domain.Interfaces;
using SistemaAgendamento.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private RepositoryEstabelecimento _repositoryEstabelecimento;
        private RepositoryAgendamento _repositoryAgendamento;
        public AppDbContext _context; 
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IEstabelecimentoRepository EstabelecimentoRepository
        {
          
            get
            {
                if (_repositoryEstabelecimento == null)
                    {
                    _repositoryEstabelecimento = new RepositoryEstabelecimento(_context);
                    }
                return _repositoryEstabelecimento;
            }
        }
        

        public IAgendamentoRepository AgendamentoRepository
        {
            get
            {
                if (_repositoryAgendamento == null)
                {
                    _repositoryAgendamento = new RepositoryAgendamento(_context);
                }
                return _repositoryAgendamento;
            }
        }
    

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
