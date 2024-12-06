using System.Linq;
using PruebaConcesionario.Context;
using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmpleadoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Empleado BuscarPorId(int id)
        {
            return _dbContext.Empleado.FirstOrDefault(x => x.EmpleadoID == id);
        }

        public Empleado BuscarPorUsuario(int idUsuario, int idCompania)
        {
            return _dbContext.Empleado.FirstOrDefault(x => x.UsuarioID == idUsuario && x.CompaniaID== idCompania);
        }

        public IEnumerable<Empleado> BuscarTodos()
        {
            return _dbContext.Empleado.ToList();
        }


        public void CrearEmpleado(Empleado empleado)
        {
            _dbContext.Empleado.Add(empleado);
            _dbContext.SaveChanges();
        }

    }
}
