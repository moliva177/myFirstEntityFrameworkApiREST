using PrimerApi.Models;

namespace PrimerApi.Interfaces;

public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAll();
    Task<Usuario> GetById(int id);
    Task<Usuario> GetByNombreUsuarioAndEmail(string nombreUsuario, string email);
}