using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public interface ITipoIdentificacionRepository
    {
        IEnumerable<TipoIdentificacion> BuscarTodos();
    }
}
