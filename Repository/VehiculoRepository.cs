using Microsoft.EntityFrameworkCore;
using PruebaConcesionario.Context;
using PruebaConcesionario.Models;
using PruebaConcesionario.Models.Dto;

namespace PruebaConcesionario.Repository
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VehiculoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Vehiculo BuscarPorId(int id)
        {
            return _dbContext.Vehiculo.FirstOrDefault(x => x.VehiculoID == id);
        }

        public Vehiculo BuscarPorUsuario(int idEmpleado)
        {
            return _dbContext.Vehiculo.FirstOrDefault(x => x.EmpleadoID == idEmpleado);
        }

        public IEnumerable<Vehiculo> BuscarTodos()
        {
            return _dbContext.Vehiculo
                     .Include(v => v.TiposFreno)
                     .ToList();
        }

        public  Vehiculo BuscarPorModelMarca(string modelo, string marca)
        {
            return _dbContext.Vehiculo.FirstOrDefault(x => x.Modelo==modelo && x.Marca==marca);
        }


        public int CrearVehiculo(Vehiculo vehiculo)
        {
            _dbContext.Vehiculo.Add(vehiculo);
            _dbContext.SaveChanges();
            return vehiculo.VehiculoID;
        }

        public void EliminarVehiculo(int idVehiculo)
        {
            Vehiculo vehiculo = BuscarPorId(idVehiculo);
            if (vehiculo != null)
            {
                _dbContext.Vehiculo.Remove(vehiculo);
                _dbContext.SaveChanges();
            }
        }


        public IEnumerable<Vehiculo> BuscarPreciosVehiculo(int estado)
        {
            return _dbContext.Vehiculo.Where(x => x.Estado == estado).ToList();
        }

        public IEnumerable<SumaVehiculoDTO> SumaValorTipoVehiModelo()
        {
            var resultado = _dbContext.Vehiculo
                .GroupBy(v => new { v.TipoVehiculo, v.Modelo })
                .Select(grupo => new SumaVehiculoDTO
                {
                    Tipo = grupo.Key.TipoVehiculo==(int)TipoVehiculo.Carro?"Carro":"Moto",
                    Modelo = grupo.Key.Modelo,
                    SumaValor = grupo.Sum(v => v.Valor)
                })
                .ToList(); 

            return resultado;
        }
    }
}
