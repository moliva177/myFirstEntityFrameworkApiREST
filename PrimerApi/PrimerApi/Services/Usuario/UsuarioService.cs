using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrimerApi.Dto;
using PrimerApi.Interfaces;
using PrimerApi.Interfaces.Services;
using PrimerApi.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrimerApi.Services.Usuario;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IConfiguration config)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
        _config = config;
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

    public async Task<ApiResponse<LoginDto>> LoginUsuario(string nombreUsuario, string email)
    {
        var usuario = await _usuarioRepository.GetByNombreUsuarioAndEmail(nombreUsuario, email);

        if (usuario is null)
        {
            return new ApiResponse<LoginDto>
            {
                StatusCode = System.Net.HttpStatusCode.NoContent,
                ErrorMessage = "El usuario solicitado no existe"
            };
        }

        var token = GenerateToken(usuario);

        var result = new ApiResponse<LoginDto>();
        result.Data = new LoginDto()
        {
            NombreUsuario = usuario.NombreUsuario,
            Email = usuario.Email,
            Token = token
        };

        return result;
    }

    private string GenerateToken(Models.Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.NombreUsuario.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Token")["Key"]));

        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: credential);

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;
    }
}