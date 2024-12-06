using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public interface ITiposFrenoRepository
    {
        IEnumerable<TiposFreno> BuscarTodos();
    }
}
