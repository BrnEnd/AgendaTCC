using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaAgendamento.Domain.Interfaces;
using SistemaAgendamento.Domain.Models;
using SistemaAgendamento.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAgendamento.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private IUnitOfWork _context;
        private IMapper _mapper;

        public ClienteController(IUnitOfWork context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet("getAgendamentos/{id}")]
        public ActionResult GetAgendamentos(int id)
        {
            //var agendamentos = _context.ClienteRepository.AgendamentosPendentes(id);
            //var response = _mapper.Map<List<AgendamentoDto>>(agendamentos);

            return Ok("Adicionar o response");
        }

    }
}
