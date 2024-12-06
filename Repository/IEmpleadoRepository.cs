using PruebaConcesionario.Models;

namespace PruebaConcesionario.Repository
{
    public interface IEmpleadoRepository
    {
        void CrearEmpleado(Empleado empleado);
        Empleado BuscarPorId(int id);
        IEnumerable<Empleado> BuscarTodos();
        Empleado BuscarPorUsuario(int idUsuario, int idCompania);
    }
}
