using PruebaConcesionario.Models;
using PruebaConcesionario.Repository;

namespace PruebaConcesionario.Services
{
    public class TipoIdentificacionService : ITipoIdentificacionService
    {
        private readonly ITipoIdentificacionRepository _tipoIdentificacionRepository;

        public TipoIdentificacionService(ITipoIdentificacionRepository tipoIdentificacionRepository)
        {
            _tipoIdentificacionRepository = tipoIdentificacionRepository; 
        }
        public IEnumerable<TipoIdentificacion> BuscarTodos()
        {
            return _tipoIdentificacionRepository.BuscarTodos();

        }
    }
}
