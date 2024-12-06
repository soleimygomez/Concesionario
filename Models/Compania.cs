using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaConcesionario.Models
{
    public class Compania
    {
        [Key]
        public int CompaniaID { get; set; }

        [Required]
        public string Nit { get; set; }

        [Required]
        public string RazonSocial { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }
         
    }
}
