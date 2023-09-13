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
        private RepositoryCliente _repositoryCliente;
        private RepositoryAgenda _repositoryAgenda;
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
    

        public IClienteRepository ClienteRepository
        { 
            get
            {
                if (_repositoryCliente == null)
                {
                    _repositoryCliente = new RepositoryCliente(_context);
                }
                return _repositoryCliente;
            }
        }

        public IAgendaRepository AgendaRepository {
            get
            {
                if (_repositoryAgenda == null)
                {
                    _repositoryAgenda = new RepositoryAgenda(_context);
                }
                return _repositoryAgenda;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
