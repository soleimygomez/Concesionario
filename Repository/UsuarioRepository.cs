using PruebaConcesionario.Context;
using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Usuario BuscarPorId(int id)
        {
            return _dbContext.Usuario.FirstOrDefault(x => x.UsuarioID == id);
        }
        public Usuario BuscarPorIdentificacion(string identificacion)
        {
            return _dbContext.Usuario.FirstOrDefault(x => x.Identificacion == identificacion);
        }
        public Usuario BuscarUsuarioExist(string identificacion,int tipoIdentificacion)
        {
            return _dbContext.Usuario.FirstOrDefault(x => x.Identificacion == identificacion && x.TipoIdentificacion== tipoIdentificacion && x.TipoUsuario==TipoUsuario.Cliente);
        }
        public Usuario BuscarPorNombApell(string nombre,string apellido, string identificación)
        {
            return _dbContext.Usuario.FirstOrDefault(x => x.Nombre == nombre && x.Apellido == apellido && x.Identificacion== identificación);
        }


        public IEnumerable<Usuario> BuscarTodos()
        {
            return _dbContext.Usuario.ToList();
        }


        public void CrearUsuario(Usuario usuario)
        {
            _dbContext.Usuario.Add(usuario);
            _dbContext.SaveChanges();
        }

    }
}
