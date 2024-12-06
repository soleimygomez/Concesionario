namespace PruebaConcesionario.Models.Dto
{
    public class VehiculoDto
    {
       public Vehiculo vehiculo {  get; set; }
       public int tipoVehiculo { get; set; }
       public  Moto? moto { get; set; }
       public Carro? carro { get; set; } 
       public Usuario usuario { get; set; }   

       public int IdCompania { get; set; }
    }
}
