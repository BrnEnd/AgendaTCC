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

        [HttpGet("getByName")]
        public ActionResult<IEnumerable<EstabelecimentoDto>> Get(string estabelecimento)
        {
            var estabelecimentos = _context.EstabelecimentoRepository.GetEstabelecimentoByName(estabelecimento);
            var response = _mapper.Map<EstabelecimentoDto>(estabelecimentos);

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
               return Ok("Sucesso. Estabelecimento cadastrado. ");

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao persistir dado no banco.", ex);
            }

        }

        [HttpPut("DesativarEstabelecimento/{nomeEstabelecimento}")]
        public IActionResult updateEstabelecimento(string nomeEstabelecimento)
        {
            try
            {
                var estabelecimento = _context.EstabelecimentoRepository.GetEstabelecimentoByName(nomeEstabelecimento);
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
