using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlBelleza.ControlBelleza.Persitence;
using ControlBelleza.Domain.Entities;

namespace proyecto.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstilistasController : ControllerBase
    {
        private readonly DataContext _context;

        public EstilistasController(DataContext context)
        {
            _context = context;
        }

        // POST: api/estilistas/crear
        [HttpPost("crear")]
        public async Task<IActionResult> CrearEstilista([FromBody] Estilista estilista)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Estilista.AddAsync(estilista);
            await _context.SaveChangesAsync();
            return Ok(estilista);
        }

        // GET: api/estilistas/lista
        [HttpGet("lista")]
        public async Task<ActionResult<IEnumerable<Estilista>>> ListarEstilistas()
        {
            var estilistas = await _context.Estilista.ToListAsync();
            return Ok(estilistas);
        }

        // GET: api/estilistas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Estilista>> ObtenerEstilista(int id)
        {
            var estilista = await _context.Estilista.FindAsync(id);
            if (estilista == null)
                return NotFound();

            return Ok(estilista);
        }

        // PUT: api/estilistas/editar/{id}
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> EditarEstilista(int id, [FromBody] Estilista estilista)
        {
            var estilistaExistente = await _context.Estilista.FindAsync(id);
            if (estilistaExistente == null)
                return NotFound();

            estilistaExistente.Nombre = estilista.Nombre;
            estilistaExistente.Apellido = estilista.Apellido;
            estilistaExistente.Gmail = estilista.Gmail;
            estilistaExistente.Telefono = estilista.Telefono;

            await _context.SaveChangesAsync();
            return Ok(estilistaExistente);
        }

        // DELETE: api/estilistas/eliminar/{id}
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarEstilista(int id)
        {
            var estilista = await _context.Estilista.FindAsync(id);
            if (estilista == null)
                return NotFound();

            _context.Estilista.Remove(estilista);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}