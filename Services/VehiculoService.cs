using PruebaConcesionario.Models;
using PruebaConcesionario.Models.Dto;
using PruebaConcesionario.Repository;

namespace PruebaConcesionario.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly ICarroRepository _carroRepository;
        private readonly IMotoRepository _motoRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly ITiposFrenoRepository _tiposFrenoRepository;


        public VehiculoService(IVehiculoRepository vehiculoRepository, IUsuarioRepository usuarioRepository, ICarroRepository carroRepository, IMotoRepository motoRepository, IEmpleadoRepository empleadoRepository, ITiposFrenoRepository tiposFrenoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
            _usuarioRepository = usuarioRepository;
            _carroRepository = carroRepository;
            _motoRepository = motoRepository;
            _empleadoRepository = empleadoRepository;
            _tiposFrenoRepository = tiposFrenoRepository;
        }

        public VehiculoDto RegistrarVehiculo(VehiculoDto nuevoVehiculo)
        {
            decimal valorMaximo = 250000000m;
            int CantPermitidaMoto = 15;
            int CantPermitidaCarro = 10;

            nuevoVehiculo.usuario = _usuarioRepository.BuscarPorIdentificacion(nuevoVehiculo.usuario.Identificacion);
            if (nuevoVehiculo.usuario != null)
            {
                nuevoVehiculo.vehiculo.Empleado = _empleadoRepository.BuscarPorUsuario(nuevoVehiculo.usuario.UsuarioID, nuevoVehiculo.IdCompania); 
            }

            if (nuevoVehiculo.vehiculo.Empleado == null)
            {
                throw new InvalidOperationException($"El empleado no se encuentra registrado, por favor registre el empleado");

            }
            
            if (((int)Estado.Usado) == nuevoVehiculo.vehiculo.Estado)
            {
                Vehiculo RefPrecioVehiculo = _vehiculoRepository.BuscarPorModelMarca(nuevoVehiculo.vehiculo.Modelo.Trim(), nuevoVehiculo.vehiculo.Marca.Trim());
                if (RefPrecioVehiculo != null)
                {
                    if (nuevoVehiculo.vehiculo.Valor < RefPrecioVehiculo.Valor * 0.85m)
                    {
                        throw new InvalidOperationException($"El valor del vehículo no puede ser menor al 85% del valor de lista.");
                    }
                }
            }
            if (nuevoVehiculo.vehiculo.Valor > valorMaximo)
            {
                throw new InvalidOperationException($"El valor del vehículo no puede ser mayor a {valorMaximo} ");
            }
            if (nuevoVehiculo.vehiculo.TipoVehiculo == (int)TipoVehiculo.Moto)
            {
                if(_motoRepository.ContarMotos() > CantPermitidaMoto)
                {
                    throw new InvalidOperationException($"El valor maximo de registros por vehículo tipo Moto es: {CantPermitidaMoto} ");
                }
                if (nuevoVehiculo.moto.Cilindraje >= 400)
                {
                    throw new InvalidOperationException($"El valor maximo de cilindraje por vehículo tipo Moto es:  400c.c");
                }
                nuevoVehiculo.moto.VehiculoID=_vehiculoRepository.CrearVehiculo(nuevoVehiculo.vehiculo);
                _motoRepository.CrearMoto(nuevoVehiculo.moto);
            }
            if (nuevoVehiculo.vehiculo.TipoVehiculo == (int)TipoVehiculo.Carro )
            {
                if (_carroRepository.ContarCarros() > CantPermitidaCarro)
                {
                    throw new InvalidOperationException($"El valor maximo de registros por vehículo tipo Carro es: {CantPermitidaCarro} ");
                }
                nuevoVehiculo.vehiculo.EmpleadoID = nuevoVehiculo.vehiculo.Empleado.EmpleadoID;
                nuevoVehiculo.carro.VehiculoID = _vehiculoRepository.CrearVehiculo(nuevoVehiculo.vehiculo);
                _carroRepository.CrearCarro(nuevoVehiculo.carro);
            }  
            return nuevoVehiculo;
        }

        public Vehiculo VenderVehiculo(VehiculoDto vehiculoDto)
        {
            vehiculoDto.usuario.TipoUsuario = TipoUsuario.Cliente;
            if(_usuarioRepository.BuscarUsuarioExist(vehiculoDto.usuario.Identificacion, (int)vehiculoDto.usuario.TipoIdentificacion) == null)
            {
                _usuarioRepository.CrearUsuario(vehiculoDto.usuario);
            }

            
            if (_vehiculoRepository.BuscarPorId((int)vehiculoDto.vehiculo.VehiculoID)==null)
            {
                throw new InvalidOperationException($"El Vehiculo con el Id : {vehiculoDto.vehiculo.VehiculoID}, no existe ");
            }

            if ((int)TipoVehiculo.Moto==vehiculoDto.vehiculo.TipoVehiculo)
            {
                _motoRepository.EliminarMoto(vehiculoDto.vehiculo.VehiculoID);
            }
            else if ((int)TipoVehiculo.Carro == vehiculoDto.vehiculo.TipoVehiculo)
            {
                _carroRepository.EliminarCarro(vehiculoDto.vehiculo.VehiculoID);
            }

            _vehiculoRepository.EliminarVehiculo(vehiculoDto.vehiculo.VehiculoID);

            return vehiculoDto.vehiculo;
             
        }

        public IEnumerable<Vehiculo> ListPreciosVehiculo(int estado)
        {
            return _vehiculoRepository.BuscarPreciosVehiculo(estado);
        }

        public VehiculoDto BuscarPorId(int vehiculoId)
        {
            VehiculoDto vehiculodto = new VehiculoDto();
            vehiculodto.vehiculo=_vehiculoRepository.BuscarPorId(vehiculoId);
            vehiculodto.carro = _carroRepository.BuscarPorId(vehiculoId);
            vehiculodto.moto = _motoRepository.BuscarPorId(vehiculoId);
            return vehiculodto;
        }

        public IEnumerable<Vehiculo> BuscarTodos()
        {
            return _vehiculoRepository.BuscarTodos();
        }

        public IEnumerable<SumaVehiculoDTO> SumaValorTipoVehiModelo()
        {
            return _vehiculoRepository.SumaValorTipoVehiModelo();
        }

        public IEnumerable<TiposFreno> BuscarTipoFrenos() 
        {
            return _tiposFrenoRepository.BuscarTodos();
        }
    }
}
