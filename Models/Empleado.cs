using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaConcesionario.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }
         
        public int CompaniaID { get; set; }

        public int UsuarioID { get; set; }

        [ForeignKey(nameof(CompaniaID))]
        public Compania Compania { get; set; }

        [ForeignKey(nameof(UsuarioID))]
        public Usuario Usuario { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }
    }
}
