using PrimerApi.Dto;
using PrimerApi.Response;

namespace PrimerApi.Interfaces.Services;

public interface IUsuarioService
{
    Task<ApiResponse<List<UsuarioDto>>> GetAll();
    Task<ApiResponse<UsuarioDto>> GetById(int id);
}