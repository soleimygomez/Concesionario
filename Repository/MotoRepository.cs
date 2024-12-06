using PruebaConcesionario.Context;
using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public class MotoRepository: IMotoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MotoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Moto BuscarPorId(int id)
        {
            return _dbContext.Moto.FirstOrDefault(x => x.VehiculoID == id);
        }

        public IEnumerable<Moto> BuscarTodos()
        {
            return _dbContext.Moto.ToList();
        }

        public void CrearMoto(Moto moto)
        {
            _dbContext.Moto.Add(moto);
            _dbContext.SaveChanges();
        }

        public void EliminarMoto(int idVehiculo)
        {
            Moto moto = BuscarPorId(idVehiculo);
            if (moto != null)
            {
                _dbContext.Moto.Remove(moto);
                _dbContext.SaveChanges();
            }
        }

        public int ContarMotos()
        {
            return _dbContext.Moto.Count();
        }
    }
}
