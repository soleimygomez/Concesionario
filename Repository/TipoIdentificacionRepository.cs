using PruebaConcesionario.Context;
using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public class TipoIdentificacionRepository:ITipoIdentificacionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TipoIdentificacionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        } 
        public IEnumerable<TipoIdentificacion> BuscarTodos()
        {
            return _dbContext.TipoIdentificacion.ToList();
        }
    }
}
