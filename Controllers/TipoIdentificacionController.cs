using Microsoft.AspNetCore.Mvc;
using PruebaConcesionario.Models;
using PruebaConcesionario.Services;

namespace PruebaConcesionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdentificacionController : Controller
    {
        private readonly ITipoIdentificacionService _tipoIdentificacionService;
        public TipoIdentificacionController(ITipoIdentificacionService tipoIdentificacionService)
        {
            _tipoIdentificacionService = tipoIdentificacionService;
        }

        [HttpGet]
        public IActionResult GetTipoIdentificacion()
        {
            try
            {
                IEnumerable<TipoIdentificacion> tipoIdentificacion = _tipoIdentificacionService.BuscarTodos();
                return Ok(tipoIdentificacion);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}
