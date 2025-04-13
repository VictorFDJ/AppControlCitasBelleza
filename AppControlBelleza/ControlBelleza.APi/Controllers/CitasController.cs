using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlBelleza.ControlBelleza.Persitence;
using ControlBelleza.Domain.Entities;

namespace proyecto.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly DataContext _context;

        public CitasController(DataContext context)
        {
            _context = context;
        }

        // POST: api/citas/crear
        [HttpPost("crear")]
        public async Task<IActionResult> CrearCita([FromBody] Citas cita)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Citas.AddAsync(cita);
            await _context.SaveChangesAsync();
            return Ok(cita);
        }

        // GET: api/citas/lista
        [HttpGet("lista")]
        public async Task<ActionResult<IEnumerable<Citas>>> ListarCitas()
        {
            var citas = await _context.Citas
                .Include(c => c.Cliente) // Incluye información del cliente
                .ToListAsync();
            return Ok(citas);
        }

        // GET: api/citas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Citas>> ObtenerCita(int id)
        {
            var cita = await _context.Citas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cita == null)
                return NotFound();

            return Ok(cita);
        }

        // PUT: api/citas/editar/{id}
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> EditarCita(int id, [FromBody] Citas cita)
        {
            var citaExistente = await _context.Citas.FindAsync(id);
            if (citaExistente == null)
                return NotFound();

            citaExistente.FechaCita = cita.FechaCita;
            citaExistente.ClienteId = cita.ClienteId;

            await _context.SaveChangesAsync();
            return Ok(citaExistente);
        }

        // DELETE: api/citas/eliminar/{id}
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
                return NotFound();

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}