using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaAgendamento.Domain.Interfaces;
using SistemaAgendamento.Domain.Models;
using SistemaAgendamento.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAgendamento.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private IUnitOfWork _context;
        private IMapper _mapper;

        public AgendamentoController(IUnitOfWork context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet("getAll")]
        public ActionResult<IEnumerable<AgendamentoDto>> Get()
        {
            var agendamentos = _context.AgendamentoRepository.GetAll().ToList();
            var response = _mapper.Map<List<AgendamentoDto>>(agendamentos);

            return Ok(response);
        }


        [HttpPost("addNewAgendamento")]
        public async Task<ActionResult> AddNewAgendamentoAsync([FromBody] AgendamentoDto request)
        {

            var agendamento = _mapper.Map<Agendamento>(request);
            try
            {

                var estabelecimentoExist = _context.AgendamentoRepository.GetEstabelecimentoByName(agendamento.NomeEstabelecimento);

                if (estabelecimentoExist == null)
                {
                    return NotFound("Estabelecimento não cadastrado.");
                }
                if (estabelecimentoExist.Ativo.Equals("N"))
                {
                    return BadRequest("Estabelecimento desativado.");
                }
                if (agendamento.NomeProcedimento == null)
                {
                    return NotFound("Por favor, adicione o nome do procedimento.");
                }

                if (_context.AgendamentoRepository.AddNewAgendamento(agendamento).Equals("Agendamento realizado com sucesso!"))
                {
                    return Ok("Sucesso.");
                }
                else
                {
                    return BadRequest("Não foi possivel concluir agendamento.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao persistir dado no banco.", ex);
            }
        }

        //    [HttpPut("cancelarAgendamento/{Id:guid}")]
        //    public async Task<ActionResult> CancelarAgendamentoAsync(Guid Id)
        //    {
        //        try
        //        {
        //            Agendamento agendamento = await _context.AgendamentoRepository.GetById(Id);

        //            if (agendamento == null)
        //            {
        //                return NotFound("Agendamento não encontrado.");
        //            }

        //            if (_context.AgendamentoRepository.CancelarAgendamento(agendamento).Equals("Agendamento cancelado com sucesso!"))
        //            {
        //                return Ok("Sucesso.");
        //            }
        //            else
        //            {
        //                return BadRequest("Não foi possivel concluir cancelamento.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Erro ao persistir dado no banco.", ex);
        //        }
        //    }

        //}
    }
}
