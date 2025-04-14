using ControlBelleza.ControlBelleza.Persitence;
using ControlBelleza.Domain.Entities;
using ControlBelleza.infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlBelleza.infrastructure.Repositories
{
    class ClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            this._context = context;
        }
    
        public class ClientesController : ControllerBase
        {
            private readonly DataContext _context;

            public ClientesController(DataContext context)
            {

                _context = context;
            }

         
            //public async Task<ClienteModel> CrearCliente(Cliente cliente)
            //{
            //    await _context.Clientes.AddAsync(cliente);
            //    await _context.SaveChangesAsync();
            //    return Ok();

            //}
   
            public async Task<ClienteModel> ListaClientes(ClienteModel ok)
            {

                var clientes = await _context.Clientes.ToListAsync();
                return ok;
            }

    

            //public async Task<ClienteModel> VerCliente(int id)
            //{
            //    Cliente cliente = await _context.Clientes.FindAsync(id);

            //    if (cliente == null)
            //    {
            //        return NotFound();
            //    }
            //    return cliente
            //}

            //public async Task<ClienteModel> ActualizarCliente(int id, Cliente cliente)
            //{
            //    var clientes = await _context.Clientes.FindAsync(id);

            //    clientes!.Name = cliente.Name;
            //    //clientes.Name = cliente.Telefono;
            //    await _context.SaveChangesAsync();

            //    return Ok();
            //}

         
        }
    }
}
