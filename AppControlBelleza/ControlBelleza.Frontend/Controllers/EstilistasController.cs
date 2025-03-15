using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlBelleza.Frontend.Data;
using ControlBelleza.Frontend.Models;

namespace ControlBelleza.Frontend.Controllers
{
    public class EstilistasController : Controller
    {
        private readonly DataContext _context;

        public EstilistasController(DataContext context)
        {
            _context = context;
        }

        // GET: Estilistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estilista.ToListAsync());
        }

        // GET: Estilistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estilista = await _context.Estilista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estilista == null)
            {
                return NotFound();
            }

            return View(estilista);
        }

        // GET: Estilistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estilistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Gmail,Telefono")] Estilista estilista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estilista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estilista);
        }

        // GET: Estilistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estilista = await _context.Estilista.FindAsync(id);
            if (estilista == null)
            {
                return NotFound();
            }
            return View(estilista);
        }

        // POST: Estilistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Gmail,Telefono")] Estilista estilista)
        {
            if (id != estilista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estilista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstilistaExists(estilista.Id))
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
            return View(estilista);
        }

        // GET: Estilistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estilista = await _context.Estilista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estilista == null)
            {
                return NotFound();
            }

            return View(estilista);
        }

        // POST: Estilistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estilista = await _context.Estilista.FindAsync(id);
            if (estilista != null)
            {
                _context.Estilista.Remove(estilista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstilistaExists(int id)
        {
            return _context.Estilista.Any(e => e.Id == id);
        }
    }
}
