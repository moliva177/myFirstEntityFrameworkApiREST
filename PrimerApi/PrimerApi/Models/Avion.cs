using System.ComponentModel.DataAnnotations.Schema;


namespace PrimerApi.Models
{
    [Table("aviones")]
    public class Avion
    {
        public Guid Id { get; set; }
        public int CantidadPasajesros { get; set; }
        public String Matricula { get; set; }

        public Guid IdMarca { get; set; }
        [ForeignKey("IdMarca")] public MarcaAvion MarcaAvion { get; set; }
    }
}
