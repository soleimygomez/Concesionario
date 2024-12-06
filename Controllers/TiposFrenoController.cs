using Microsoft.AspNetCore.Mvc;
using PruebaConcesionario.Models;
using PruebaConcesionario.Services;

namespace PruebaConcesionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposFrenoController : Controller
    {
        private readonly ITiposFrenoService _tiposFrenoService;
        public TiposFrenoController(ITiposFrenoService tiposFrenoService)
        {
            _tiposFrenoService = tiposFrenoService;
        }

        [HttpGet]
        public IActionResult GetTiposFrenos()
        {
            try
            {
                IEnumerable<TiposFreno> tiposFreno = _tiposFrenoService.BuscarTodos();
                return Ok(tiposFreno);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}
