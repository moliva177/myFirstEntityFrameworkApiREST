using System.ComponentModel.DataAnnotations.Schema;

namespace PrimerApi.Models;

[Table("categorias")]
public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaAlta { get; set; }
}