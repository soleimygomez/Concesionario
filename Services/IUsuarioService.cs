using PruebaConcesionario.Models;
using PruebaConcesionario.Models.Dto;

namespace PruebaConcesionario.Services
{
    public interface IUsuarioService
    {
        Usuario BuscarPorId(int id);
        Usuario CrearUsuario(CrearUsuarioDto usuarioNuevo);
        IEnumerable<Usuario> BuscarTodos();
        Usuario BuscarUsuarioExist(string identificacion, int tipoIdentificacion);
    }
}
