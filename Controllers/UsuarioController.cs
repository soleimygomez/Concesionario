using Microsoft.AspNetCore.Mvc;
using PruebaConcesionario.Models;
using PruebaConcesionario.Models.Dto;
using PruebaConcesionario.Services;

namespace PruebaConcesionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            try
            {
                IEnumerable<Usuario> usuario = _usuarioService.BuscarTodos();
                return Ok(usuario);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [HttpPost("CrearUsuario")]
        public IActionResult CrearUsuario([FromBody] CrearUsuarioDto usuario)
        {
            try
            {
                Usuario usuarioNuevo = _usuarioService.CrearUsuario(usuario);
                return Ok(usuarioNuevo);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

    }
}
