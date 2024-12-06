using System.ComponentModel.DataAnnotations;

namespace PruebaConcesionario.Models
{
    public class TiposFreno
    {
        public int FrenoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }

    }
}
