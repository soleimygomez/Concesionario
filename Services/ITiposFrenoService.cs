using PruebaConcesionario.Models;

namespace PruebaConcesionario.Services
{
    public interface ITiposFrenoService
    {
        IEnumerable<TiposFreno> BuscarTodos();
    }
}
