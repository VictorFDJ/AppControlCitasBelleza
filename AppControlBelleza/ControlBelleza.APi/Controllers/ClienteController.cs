//using ControlBelleza.ControlBelleza.Persitence;
//using Microsoft.AspNetCore.Mvc;

//namespace ControlBelleza.APi.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class ClienteController : ControllerBase
//{
//    private readonly DataContext _context;
//    public ClienteController(DataContext context)
//    {
//        _context = context;
//    }



//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using CRUD.Persitense;
using ControlBelleza.Domain.Entities;
using ControlBelleza.ControlBelleza.Persitence;
using ControlBelleza.Domain.Entities;
namespace proyecto.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {

            _context = context;
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListaClientes()
        {

            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet]
        [Route("Buscar por ID")]

        public async Task<IActionResult> VerCliente(int id)
        {
            Cliente cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarCliente(int id, Cliente cliente)
        {
            var clientes = await _context.Clientes.FindAsync(id);

            clientes!.Name = cliente.Name;
            //clientes.Name = cliente.Telefono;
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            var ClienteRemove = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(ClienteRemove!);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
