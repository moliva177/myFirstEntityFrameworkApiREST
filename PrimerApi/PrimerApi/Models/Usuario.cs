using System.ComponentModel.DataAnnotations.Schema;

namespace PrimerApi.Models;

[Table("usuarios")]
public class Usuario
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; }
    public string Email { get; set; }
    public DateTime FechaAlta { get; set; }
}