using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaConcesionario.Models
{
    public class Carro
    {
        [Key]
        [ForeignKey(nameof(Vehiculo))]
        public int VehiculoID { get; set; }  

        public int? NumeroPuertas { get; set; }

        [StringLength(50)]
        public string? TipoCombustible { get; set; }

        [StringLength(50)]
        public string? TipoTransmision { get; set; }

        public Vehiculo? Vehiculo { get; set; }  
    }
}
