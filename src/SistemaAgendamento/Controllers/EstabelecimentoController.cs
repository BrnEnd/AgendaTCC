using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaAgendamento.Domain.Interfaces;
using SistemaAgendamento.Domain.Models;
using SistemaAgendamento.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAgendamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstabelecimentoController : ControllerBase
    {
        private IUnitOfWork _context;
        private IMapper _mapper;

        public EstabelecimentoController(IUnitOfWork context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<EstabelecimentoDto>> Get()
        {
            var estabelecimentos = _context.EstabelecimentoRepository.GetAll().ToList();
            var response = _mapper.Map<List<EstabelecimentoDto>>(estabelecimentos);

            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public ActionResult<EstabelecimentoDto> GetById(int id)
        {
            var estabelecimento = _context.EstabelecimentoRepository.GetById(id).Result;
            var response = _mapper.Map<EstabelecimentoDto>(estabelecimento);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }

        }

        [HttpGet("getAllAtivos")]
        public ActionResult<IEnumerable<EstabelecimentoDto>> GetAllAtivos()
        {
            var estabelecimentos = _context.EstabelecimentoRepository.GetEstabelecimentosAtivos().ToList();
            var response = _mapper.Map<List<EstabelecimentoDto>>(estabelecimentos);

            return Ok(response);
        }

        [HttpPost("addNewEstabelecimento")]
        public IActionResult addNewEstabelecimento([FromBody] EstabelecimentoDto request)
        {
            try
            {
                var estabelecimento = _mapper.Map<Estabelecimento>(request);
                _context.EstabelecimentoRepository.Add(estabelecimento);
                _context.Commit();
                var agenda = new Agenda(estabelecimento.IdEstabelecimento, 'S');
                estabelecimento.Agenda = agenda;
                _context.EstabelecimentoRepository.Update(estabelecimento);
                _context.Commit();

                return Ok("Sucesso. ID do Estabelecimento: " + estabelecimento.IdEstabelecimento);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao persistir dado no banco.", ex);
            }



        }

        [HttpPut("DesativarEstabelecimento/{id}")]
        public IActionResult updateEstabelecimento(int id)
        {
            try
            {
                var estabelecimento = _context.EstabelecimentoRepository.GetById(id).Result;
                estabelecimento.Ativo = 'N';
                _context.EstabelecimentoRepository.Update(estabelecimento);
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
