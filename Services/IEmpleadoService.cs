using PruebaConcesionario.Models;

namespace PruebaConcesionario.Services
{
    public interface IEmpleadoService
    {
        Empleado BuscarPorId(int id);
        Empleado CrearEmpleado(Empleado empleado);
        IEnumerable<Empleado> BuscarTodos();
    }
}
