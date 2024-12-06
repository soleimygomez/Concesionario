using PruebaConcesionario.Models;
using PruebaConcesionario.Models.Dto;

namespace PruebaConcesionario.Repository
{
    public interface IVehiculoRepository
    {
        Vehiculo BuscarPorId(int id);
        Vehiculo BuscarPorUsuario(int idEmpleado);
        IEnumerable<Vehiculo> BuscarTodos();
        int CrearVehiculo(Vehiculo vehiculo);
        void EliminarVehiculo(int idVehiculo);
        IEnumerable<Vehiculo> BuscarPreciosVehiculo(int estado);
        Vehiculo BuscarPorModelMarca(string modelo, string marca);
        IEnumerable<SumaVehiculoDTO> SumaValorTipoVehiModelo();
    }
}
