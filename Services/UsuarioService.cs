using System.Collections.Generic;
using PruebaConcesionario.Models;
using PruebaConcesionario.Models.Dto;
using PruebaConcesionario.Repository;

namespace PruebaConcesionario.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly ITipoIdentificacionRepository _tipoIdentificacionRepository;


        public UsuarioService( IUsuarioRepository usuarioRepository,IEmpleadoRepository empleadoRepository, ITipoIdentificacionRepository tipoIdentificacionRepository)
        { 
            _usuarioRepository = usuarioRepository;
            _empleadoRepository = empleadoRepository;
            _tipoIdentificacionRepository = tipoIdentificacionRepository;
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario prestamo = _usuarioRepository.BuscarPorId(id);
            if (prestamo == null)
            {
                throw new InvalidOperationException($"El Usuario con el id: {id} no existe");
            }
            return prestamo;
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return _usuarioRepository.BuscarTodos();
             
        }

        public Usuario CrearUsuario(CrearUsuarioDto usuarioNuevo)
        {
            _usuarioRepository.CrearUsuario(usuarioNuevo.usuario);
            Usuario usuario = _usuarioRepository.BuscarPorNombApell(usuarioNuevo.usuario.Nombre.Trim(),usuarioNuevo.usuario.Apellido.Trim(), usuarioNuevo.usuario.Identificacion.Trim());
            if(usuario == null)
            {
                throw new InvalidOperationException($"Error creando el usuario");
            }
            Empleado empleado= new Empleado();
            empleado.UsuarioID = usuario.UsuarioID;
            empleado.CompaniaID = usuarioNuevo.idCompania;
            _empleadoRepository.CrearEmpleado(empleado);

            return usuario;
             
        }

        public IEnumerable<TipoIdentificacion> BuscarTipoIdentificacion()
        {
            return _tipoIdentificacionRepository.BuscarTodos();
        }

        public Usuario BuscarUsuarioExist(string identificacion, int tipoIdentificacion)
        {
            return _usuarioRepository.BuscarUsuarioExist(identificacion, tipoIdentificacion);   
        }
    }
}
