using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PruebaConcesionario.Models;
using PruebaConcesionario.Models.Dto;
using PruebaConcesionario.Services;

namespace PruebaConcesionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : Controller
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet("{vehiculoId:int}")]
        public IActionResult BuscarPorIdVehiculo(int vehiculoId)
        {
            try
            {
                VehiculoDto vehiculo = _vehiculoService.BuscarPorId(vehiculoId);
                return Ok(vehiculo);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetVehiculos()
        {
            try
            {
                IEnumerable<Vehiculo> vehiculos = _vehiculoService.BuscarTodos();
                return Ok(vehiculos);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [HttpGet("GetAgrupaTipoVehiculoModelo")]
        public IActionResult GetAgrupaTipoVehModelo()
        {
            try
            {
                IEnumerable<SumaVehiculoDTO> vehiculos = _vehiculoService.SumaValorTipoVehiModelo();
                return Ok(vehiculos);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
 
        [HttpPost("CrearVehiculo")]
        public  IActionResult CrearVehiculo([FromForm] string marca, [FromForm] string modelo,[FromForm] int ano,
                                            [FromForm] string color, [FromForm] string kilometraje, [FromForm] decimal valor,
                                            [FromForm] int frenoID,[FromForm] int estado,[FromForm] int tipoVehiculo,
                                            [FromForm] string usuarioIdentificacion,[FromForm] int idCompania,
                                            [FromForm] int? numeroPuertas,[FromForm] string? tipoCombustible,
                                            [FromForm] string? tipoTransmision,[FromForm] int? cilindraje,IFormFile imagen)
        {
            try
            {
                VehiculoDto vehiculo = new VehiculoDto
                {
                    vehiculo = new Vehiculo
                    {
                        Marca = marca,
                        Modelo = modelo,
                        Ano = ano,
                        Color = color,
                        Kilometraje = kilometraje,
                        Valor = valor,
                        FrenoID = frenoID,
                        Estado = estado, 
                        TipoVehiculo = tipoVehiculo
                    }, 
                    usuario = new Usuario { Identificacion = usuarioIdentificacion },
                    IdCompania = idCompania,
                    carro = tipoVehiculo == 1 ? new Carro
                    {
                        NumeroPuertas = numeroPuertas,
                        TipoCombustible = tipoCombustible,
                        TipoTransmision = tipoTransmision,
                    } : null,
                    moto = tipoVehiculo == 2 ? new Moto
                    {
                        Cilindraje = cilindraje
                    } : null
                }; 

                if (imagen != null && imagen.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        imagen.CopyTo(memoryStream);
                        vehiculo.vehiculo.Imagen = memoryStream.ToArray();
                    }
                }
                VehiculoDto nuevoVehiculo = _vehiculoService.RegistrarVehiculo(vehiculo);
                return Ok(new { mensaje = "Vehículo registrado exitosamente", nuevoVehiculo });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("VenderVehiculo")]
        public IActionResult VenderVehiculo([FromBody] VehiculoDto vehiculo)
        {
            try
            {
                Vehiculo venderVehiculo = _vehiculoService.VenderVehiculo(vehiculo);
                return Ok(new { mensaje = "El vehículo se vendio exitosamente", venderVehiculo });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

    }
}
