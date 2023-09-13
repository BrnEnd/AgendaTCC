using AutoMapper;
using SistemaAgendamento.Domain.Interfaces;
using SistemaAgendamento.Domain.Models;
using SistemaAgendamento.Repository.Data;
using SistemaAgendamento.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Application.Business
{
    public class EstabelecimentoBusiness
    {
        private IEstabelecimentoRepository _estabelecimentoRepository ;
        private IMapper _mapper;
        public EstabelecimentoBusiness(IEstabelecimentoRepository estabelecimentoRepository, IMapper mapper)
        {
           _estabelecimentoRepository = estabelecimentoRepository;
            _mapper = mapper;
        }


        public string DesativarEstabelecimento(IUnitOfWork _context,EstabelecimentoDto estabelecimentoDto)
        {
            
            
        }

    }
}
