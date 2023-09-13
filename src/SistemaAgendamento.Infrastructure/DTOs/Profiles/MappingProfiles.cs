using AutoMapper;
using SistemaAgendamento.Domain.Models;

namespace SistemaAgendamento.Repository.DTOs.Profiles
{
    public class MappingProfiles : Profile
    {
       public MappingProfiles()
        {
            CreateMap<Agendamento, AgendamentoDto>().ReverseMap();
            CreateMap<Estabelecimento, EstabelecimentoDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }   
    }
}
