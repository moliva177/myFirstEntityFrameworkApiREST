using AutoMapper;
using PrimerApi.Dto;
using PrimerApi.Models;

namespace PrimerApi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, UsuarioDto>();
        CreateMap<Avion, AvionDto>();
    }
}