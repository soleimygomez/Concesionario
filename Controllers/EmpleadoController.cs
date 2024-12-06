using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PruebaConcesionario.Models;
using PruebaConcesionario.Models.Dto;
using PruebaConcesionario.Services;

namespace PruebaConcesionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public IActionResult GetEmpleados()
        {
            try
            {
                IEnumerable<Empleado> empleados = _empleadoService.BuscarTodos();
                return Ok(empleados);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [HttpPost("CrearEmpleado")]
        public IActionResult CrearEmpleado([FromBody] Empleado empleado)
        {
            try
            {
                Empleado empleadoNuevo=_empleadoService.CrearEmpleado(empleado);
                return Ok(empleadoNuevo);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }


    }
}
