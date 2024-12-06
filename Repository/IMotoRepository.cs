using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public interface IMotoRepository
    {
        Moto BuscarPorId(int id);
        IEnumerable<Moto> BuscarTodos();
        void CrearMoto(Moto moto);
        void EliminarMoto(int idVehiculo);
        int ContarMotos();
    }
}
