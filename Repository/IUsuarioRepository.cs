using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPorId(int id);
        IEnumerable<Usuario> BuscarTodos();
        void CrearUsuario(Usuario usuario);
        Usuario BuscarPorNombApell(string nombre, string apellido, string identificación);
        Usuario BuscarPorIdentificacion(string identificacion);
        Usuario BuscarUsuarioExist(string identificacion, int tipoIdentificacion);
    }
}
