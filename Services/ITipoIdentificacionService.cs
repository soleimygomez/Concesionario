using PruebaConcesionario.Models;

namespace PruebaConcesionario.Services
{
    public interface ITipoIdentificacionService
    {
        IEnumerable<TipoIdentificacion> BuscarTodos();
    }
}
