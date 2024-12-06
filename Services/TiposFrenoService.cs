using PruebaConcesionario.Models;
using PruebaConcesionario.Repository;

namespace PruebaConcesionario.Services
{
    public class TiposFrenoService : ITiposFrenoService
    {
        private readonly ITiposFrenoRepository _tiposFrenoRepository;

        public TiposFrenoService(ITiposFrenoRepository tiposFrenoRepository)
        {
            _tiposFrenoRepository = tiposFrenoRepository; 
        }
        public IEnumerable<TiposFreno> BuscarTodos()
        {
            return _tiposFrenoRepository.BuscarTodos();

        }
    }
}
