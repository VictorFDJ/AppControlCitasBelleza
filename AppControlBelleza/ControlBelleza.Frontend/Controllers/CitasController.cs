using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlBelleza.Frontend.Models;
using ControlBelleza.ControlBelleza.Persitence;


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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
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
        public async Task<IActionResult> Create(CitasModel model)
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
            return View(model);
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", citas.ClienteId);
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", citas.ClienteId);
            return View(citas);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaCita,ClienteId")] Citas citas)
        {
            if (id != citas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Citas.Update(citas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitasExists(citas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", citas.ClienteId);
            return View(citas);
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
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using ControlBelleza.Frontend.Data;
//using ControlBelleza.Frontend.Models;

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
//            var citas = await _context.Citas.Include(c => c.Cliente).ToListAsync();
//            return View(citas);
//        }

//        // GET: Citas/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null) return NotFound();

//            var citas = await _context.Citas
//                .Include(c => c.Cliente)
//                .FirstOrDefaultAsync(m => m.Id == id);

//            return citas == null ? NotFound() : View(citas);
//        }

//        // GET: Citas/Create
//        public async Task<IActionResult> Create()
//        {
//            var clientes = await _context.Clientes
//                .Select(d => new { d.Id, d.Name })
//                .ToListAsync();

//            ViewBag.ClienteId = new SelectList(clientes, "Id", "Name");
//            return View();
//        }

//        // POST: Citas/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,FechaCita,ClienteId")] Citas citas)
//        {
//            if (!ModelState.IsValid)
//            {
//                var clientes = await _context.Clientes
//                    .Select(d => new { d.Id, d.Name })
//                    .ToListAsync();

//                ViewBag.ClienteId = new SelectList(clientes, "Id", "Name", citas.ClienteId);
//                return View(citas);
//            }

//            _context.Add(citas);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        // GET: Citas/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null) return NotFound();

//            var citas = await _context.Citas.FindAsync(id);
//            if (citas == null) return NotFound();

//            var clientes = await _context.Clientes
//                .Select(d => new { d.Id, d.Name })
//                .ToListAsync();

//            ViewBag.ClienteId = new SelectList(clientes, "Id", "Name", citas.ClienteId);
//            return View(citas);
//        }

//        // POST: Citas/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaCita,ClienteId")] Citas citas)
//        {
//            if (id != citas.Id) return NotFound();

//            if (!ModelState.IsValid)
//            {
//                var clientes = await _context.Clientes
//                    .Select(d => new { d.Id, d.Name })
//                    .ToListAsync();

//                ViewBag.ClienteId = new SelectList(clientes, "Id", "Name", citas.ClienteId);
//                return View(citas);
//            }

//            try
//            {
//                _context.Update(citas);
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!_context.Citas.Any(e => e.Id == citas.Id)) return NotFound();
//                throw;
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        // GET: Citas/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null) return NotFound();

//            var citas = await _context.Citas
//                .Include(c => c.Cliente)
//                .FirstOrDefaultAsync(m => m.Id == id);

//            return citas == null ? NotFound() : View(citas);
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
//                await _context.SaveChangesAsync();
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

