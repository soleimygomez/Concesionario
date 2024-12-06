using PruebaConcesionario.Context;
using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public class TiposFrenoRepository : ITiposFrenoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TiposFrenoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        } 
        public IEnumerable<TiposFreno> BuscarTodos()
        {
            return _dbContext.TiposFreno.ToList();
        }
    }
}
