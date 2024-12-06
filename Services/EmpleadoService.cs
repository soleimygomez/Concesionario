using PruebaConcesionario.Models;
using PruebaConcesionario.Repository;

namespace PruebaConcesionario.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

         public EmpleadoService(IEmpleadoRepository empleadoRepository, IUsuarioRepository usuarioRepository)
        {
            _empleadoRepository = empleadoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Empleado BuscarPorId(int id)
        {
            Empleado empleado = _empleadoRepository.BuscarPorId(id);
            if (empleado == null)
            {
                throw new InvalidOperationException($"El empleado con el id: {id} no existe");
            }
            return empleado;
        }

        public IEnumerable<Empleado> BuscarTodos()
        {
            return _empleadoRepository.BuscarTodos(); 
             
        }


        public Empleado CrearEmpleado(Empleado empleado)
        { 
             
            Usuario usuario= _usuarioRepository.BuscarPorId(empleado.UsuarioID);
            if (usuario == null)
            {
                throw new InvalidOperationException($"El usuario con el id: {empleado.UsuarioID} no existe");
            }  

            _empleadoRepository.CrearEmpleado(empleado);

            return empleado;
        }


    }
}
