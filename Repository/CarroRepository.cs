using PruebaConcesionario.Context;
using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CarroRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Carro BuscarPorId(int id)
        {
            return _dbContext.Carro.FirstOrDefault(x => x.VehiculoID == id);
        }
         
        public IEnumerable<Carro> BuscarTodos()
        {
            return _dbContext.Carro.ToList();
        }
         
        public void CrearCarro(Carro Carro)
        {
            _dbContext.Carro.Add(Carro);
            _dbContext.SaveChanges();
        }

        public void EliminarCarro(int idVehiculo)
        {
            Carro carro = BuscarPorId(idVehiculo);
            if (carro != null)
            {
                _dbContext.Carro.Remove(carro);
                _dbContext.SaveChanges();
            }
        } 

        public int ContarCarros()
        {
            return _dbContext.Carro.Count();
        }
    }
}
