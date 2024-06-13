using Microsoft.EntityFrameworkCore;
using PrimerApi.Data;
using PrimerApi.Interfaces;
using PrimerApi.Models;

namespace PrimerApi.Repos;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ContextDb _contextDb;

    public UsuarioRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<List<Usuario>> GetAll()
    {
        var usuarios = await _contextDb.Usuarios.ToListAsync();
        return usuarios;
    }

    public async Task<Usuario> GetById(int id)
    {
        var usuario = await _contextDb.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
        
        if (usuario != null)
        {
            return usuario;
        }

        throw new Exception("Usuario no encontrado");
    }
}