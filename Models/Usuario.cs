using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaConcesionario.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public int? TipoIdentificacion { get; set; }
 
        public string Identificacion { get; set; }
         
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
         
        public DateTime? FechaModificacion { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

         
    }
    public enum TipoUsuario
    {
        Empleado = 1,
        Cliente = 2 
    }
}
