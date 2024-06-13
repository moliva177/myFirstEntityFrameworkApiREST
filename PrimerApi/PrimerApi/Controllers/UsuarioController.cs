using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerApi.Data;
using PrimerApi.Interfaces;
using PrimerApi.Interfaces.Services;
using PrimerApi.Models;
using PrimerApi.Query;

namespace PrimerApi.Controllers;

[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly ContextDb _contextDb;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUsuarioService _usuarioService;
    
    public UsuarioController(ContextDb contextoDb, IUsuarioRepository usuarioRepository,
        IUsuarioService usuarioService)
    {
        _contextDb = contextoDb;
        _usuarioRepository = usuarioRepository;
        _usuarioService = usuarioService;
    }

    [HttpGet("/usuarios/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.GetAll();
        return Ok(usuarios);
    }
    
    [HttpGet("/usuarios/GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuarios = await _usuarioService.GetById(id);
        return Ok(usuarios);
    }
    
    [HttpPost("/usuarios/nuevo")]
    public async Task<IActionResult> NuevoUsuario([FromBody] NuevoUsuarioQuery query)
    {
        //Validemos
        if (query.Email == "" || query.NombreUsuario == "")
        {
            return BadRequest("Todos los campos son obligatorios");
        }

        var existe = await _contextDb.Usuarios
            .FirstOrDefaultAsync(c => c.Email == query.Email);

        if (existe != null)
        {
            return BadRequest("Usuario ya registrado previamente");
        }

        var usuarioNuevo = new Usuario
        {
            NombreUsuario = query.NombreUsuario.Trim(),
            Email = query.Email.Trim(),
            FechaAlta = DateTime.Now
        };

        await _contextDb.AddAsync(usuarioNuevo);
        await _contextDb.SaveChangesAsync();

        return Ok(usuarioNuevo);
       
    }
}