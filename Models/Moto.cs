using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaConcesionario.Models
{
    public class Moto
    {
        [Key]
        [ForeignKey(nameof(Vehiculo))]
        public int VehiculoID { get; set; }  

        public int? Cilindraje { get; set; }  

        public Vehiculo? Vehiculo { get; set; }  
    
    }
}
