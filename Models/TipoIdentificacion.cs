using System.ComponentModel.DataAnnotations;

namespace PruebaConcesionario.Models
{ 
      public class TipoIdentificacion
      {
            [Key]
            public int TipoID { get; set; }

            [Required]
            [StringLength(100)]
            public string Descripcion { get; set; }
      } 
}
