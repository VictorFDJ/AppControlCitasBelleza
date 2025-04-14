//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using ControlBelleza.Frontend.Models;
//using ControlBelleza.ControlBelleza.Persitence;
//using ControlBelleza.Domain.Entities;


//namespace ControlBelleza.Frontend.Controllers
//{
//    public class CitasController : Controller
//    {
//        private readonly DataContext _context;

//        public CitasController(DataContext context)
//        {
//            _context = context;
//        }

//        // GET: Citas
//        public async Task<IActionResult> Index()
//        {
//            var dataContext = _context.Citas.Include(c => c.Cliente);
//            return View(await dataContext.ToListAsync());
//        }

//        // GET: Citas/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var citas = await _context.Citas
//                .Include(c => c.Cliente)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (citas == null)
//            {
//                return NotFound();
//            }

//            return View(citas);
//        }

//        // GET: Citas/Create
//        public async Task<IActionResult> Create()
//        {
//            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
//            var cliente = await _context.Clientes
//            .Select(d => new { d.Id, d.Name })
//            .ToListAsync();


//            ViewBag.ClienteId = new SelectList(cliente, "Id", "Name");
//            return View();
//        }

//        // POST: Citas/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(CitasViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var citas = new Citas();
//                citas.ClienteId = model.ClienteId;
//                citas.FechaCita = model.FechaCita;

//                _context.Citas.Add(citas);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(model);
//            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", citas.ClienteId);
//        }

//        // GET: Citas/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var citas = await _context.Citas.FindAsync(id);
//            if (citas == null)
//            {
//                return NotFound();
//            }
//            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", citas.ClienteId);
//            return View(citas);
//        }

//        // POST: Citas/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaCita,ClienteId")] Citas citas)
//        {
//            if (id != citas.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Citas.Update(citas);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CitasExists(citas.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", citas.ClienteId);
//            return View(citas);
//        }

//        // GET: Citas/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var citas = await _context.Citas
//                .Include(c => c.Cliente)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (citas == null)
//            {
//                return NotFound();
//            }

//            return View(citas);
//        }

//        // POST: Citas/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var citas = await _context.Citas.FindAsync(id);
//            if (citas != null)
//            {
//                _context.Citas.Remove(citas);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool CitasExists(int id)
//        {
//            return _context.Citas.Any(e => e.Id == id);
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlBelleza.Frontend.Models;
using ControlBelleza.ControlBelleza.Persitence;
using ControlBelleza.Domain.Entities;


namespace ControlBelleza.Frontend.Controllers
{
    public class CitasController : Controller
    {
        private readonly DataContext _context;

        public CitasController(DataContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Citas.Include(c => c.Cliente);
            return View(await dataContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Citas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // GET: Citas/Create
        public async Task<IActionResult> Create()
        {
            var cliente = await _context.Clientes
                .Select(d => new { d.Id, d.Name })
                .ToListAsync();

            ViewBag.ClienteId = new SelectList(cliente, "Id", "Name");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CitasViewModel model)
        {
            if (ModelState.IsValid)
            {
                var citas = new Citas();
                citas.ClienteId = model.ClienteId;
                citas.FechaCita = model.FechaCita;

                _context.Citas.Add(citas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recuperar la lista de clientes en caso de error de validación
            var cliente = await _context.Clientes
                .Select(d => new { d.Id, d.Name })
                .ToListAsync();
            ViewBag.ClienteId = new SelectList(cliente, "Id", "Name", model.ClienteId);

            return View(model);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Citas.FindAsync(id);
            if (citas == null)
            {
                return NotFound();
            }

            // Convertir la entidad Citas a CitasViewModel (inverso de Create)
            var model = new CitasViewModel
            {
                Id = citas.Id,
                FechaCita = citas.FechaCita,
                ClienteId = citas.ClienteId
            };

            // Obtener la lista de clientes con nombre para el dropdown
            var cliente = await _context.Clientes
                .Select(d => new { d.Id, d.Name })
                .ToListAsync();

            // Configurar ViewBag para que coincida con lo que usa la vista
            ViewBag.ClienteId = new SelectList(cliente, "Id", "Name", model.ClienteId);

            return View(model);
        }

        // POST: Citas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CitasViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Encontrar la entidad existente
                    var citas = await _context.Citas.FindAsync(id);
                    if (citas == null)
                    {
                        return NotFound();
                    }

                    // Actualizar los datos de la entidad con los del modelo
                    citas.FechaCita = model.FechaCita;
                    citas.ClienteId = model.ClienteId;

                    _context.Update(citas);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitasExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Configurar el ViewBag correctamente en caso de error
            var cliente = await _context.Clientes
                .Select(d => new { d.Id, d.Name })
                .ToListAsync();
            ViewBag.ClienteId = new SelectList(cliente, "Id", "Name", model.ClienteId);

            return View(model);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Citas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citas = await _context.Citas.FindAsync(id);
            if (citas != null)
            {
                _context.Citas.Remove(citas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitasExists(int id)
        {
            return _context.Citas.Any(e => e.Id == id);
        }
    }
}

