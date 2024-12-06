using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaConcesionario.Models
{
    public class Vehiculo
    {
        [Key]
        public int VehiculoID { get; set; }

        [Required]
        [StringLength(200)]
        public string Marca { get; set; } 

        [Required]
        [StringLength(200)]
        public string Modelo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        [Required]
        [StringLength(100)]
        public string Kilometraje { get; set; }

        public byte[]? Imagen { get; set; }

        [Required]
        public decimal Valor { get; set; }
         
        public int? FrenoID { get; set; }

        public int? EmpleadoID { get; set; }

        [Required]
        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public DateTime? FechaActualizacion { get; set; }

        public int? UsuarioActualizacion { get; set; }

        [ForeignKey(nameof(FrenoID))]
        public TiposFreno? TiposFreno { get; set; }

        [ForeignKey(nameof(EmpleadoID))]
        public Empleado? Empleado { get; set; }
        public int TipoVehiculo { get; set; }
        public int Estado { get; set; }
    }
    public enum TipoVehiculo
    {
        Carro = 1,
        Moto = 2
    } 
    public enum Estado
    {
        Nuevo = 1,
        Usado = 2
    }
}
