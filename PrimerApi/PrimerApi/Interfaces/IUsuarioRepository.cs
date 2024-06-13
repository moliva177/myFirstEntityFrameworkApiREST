using PrimerApi.Models;

namespace PrimerApi.Interfaces;

public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAll();
    Task<Usuario> GetById(int id);
}