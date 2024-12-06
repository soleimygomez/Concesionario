using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public interface ICarroRepository
    {
        Carro BuscarPorId(int id); 
        IEnumerable<Carro> BuscarTodos(); 
        void CrearCarro(Carro Carro);
        void EliminarCarro(int idVehiculo);
        int ContarCarros();
    }
}
