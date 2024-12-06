using PruebaConcesionario.Models;
using PruebaConcesionario.Models.Dto;

namespace PruebaConcesionario.Services
{
    public interface IVehiculoService
    {
        VehiculoDto RegistrarVehiculo(VehiculoDto nuevoVehiculo);
        Vehiculo VenderVehiculo(VehiculoDto vehiculoDto);
        IEnumerable<Vehiculo> ListPreciosVehiculo(int estado);
        IEnumerable<SumaVehiculoDTO> SumaValorTipoVehiModelo();
        IEnumerable<Vehiculo> BuscarTodos();
        VehiculoDto BuscarPorId(int vehiculoId);
        IEnumerable<TiposFreno> BuscarTipoFrenos();
    }
}
