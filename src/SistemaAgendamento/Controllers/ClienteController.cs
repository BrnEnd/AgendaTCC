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

        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var clientes = _context.ClienteRepository.GetAll().ToList();
            var response = _mapper.Map<List<ClienteDto>>(clientes);

            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public ActionResult GetById(int id)
        {
            var cliente = _context.ClienteRepository.GetById(id).Result;
            var response = _mapper.Map<ClienteDto>(cliente);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }

        }

        [HttpGet("getAgendamentos/{id}")]
        public ActionResult GetAgendamentos(int id)
        {
            var agendamentos = _context.ClienteRepository.AgendamentosPendentes(id);
            var response = _mapper.Map<List<AgendamentoDto>>(agendamentos);

            return Ok(response);
        }

        [HttpPost("addNewCliente")]
        public ActionResult AddNewCliente(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            _context.ClienteRepository.Add(cliente);
            _context.Commit();

            return Ok("Sucesso.");
        }

        [HttpPut("DesativarCliente/{id}")]
        public IActionResult updateCliente(int id)
        {
            try
            {
                var cliente = _context.ClienteRepository.GetById(id).Result;
                cliente.Ativo = 'N';
                _context.ClienteRepository.Update(cliente);
                _context.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao persistir dado no banco.", ex);
            }

            return Ok("Sucesso.");
        }


    }
}
