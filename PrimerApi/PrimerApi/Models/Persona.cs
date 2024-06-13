using System.ComponentModel.DataAnnotations.Schema;

namespace PrimerApi.Models;

[Table("personas")]
public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string DNI { get; set; }
    public DateTime FechaNacimiento { get; set; }
    
    public int IdCategoria { get; set; }
    [ForeignKey("IdCategoria")] public Categoria Categoria { get; set; }

    public DateTime FechaAlta { get; set; }
}