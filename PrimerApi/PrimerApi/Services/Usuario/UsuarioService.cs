using AutoMapper;
using PrimerApi.Dto;
using PrimerApi.Interfaces;
using PrimerApi.Interfaces.Services;
using PrimerApi.Repos;
using PrimerApi.Response;

namespace PrimerApi.Services.Usuario;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<UsuarioDto>>> GetAll()
    {
        var response = new ApiResponse<List<UsuarioDto>>();
        var usuarios = await _usuarioRepository.GetAll();
        if (usuarios != null && usuarios.Count > 0)
        {
            response.Data = _mapper.Map<List<UsuarioDto>>(usuarios);
            // var result = new List<UsuarioDto>();
            //
            // foreach (var usu in usuarios)
            // {
            //     var usuDto = new UsuarioDto
            //     {
            //         NombreUsuario = usu.NombreUsuario,
            //         Email = usu.Email
            //     };
            //     
            //     result.Add(usuDto);
            // }
            //
            // return new ApiResponse<List<UsuarioDto>>
            // {
            //     Data = result
            // };
        }

        return response;
    }

    public async Task<ApiResponse<UsuarioDto>> GetById(int id)
    {
        var usuario = await _usuarioRepository.GetById(id);
        if (usuario != null)
        {
            var usuDto = new UsuarioDto
            {
                NombreUsuario = usuario.NombreUsuario,
                Email = usuario.Email
            };
            return new ApiResponse<UsuarioDto>
            {
                Data = usuDto
            };
        }

        return new ApiResponse<UsuarioDto>();
    }
}