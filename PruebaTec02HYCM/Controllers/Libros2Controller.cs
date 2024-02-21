using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTec02HYCM.Models;

namespace PruebaTec02HYCM.Controllers
{
    public class Libros2Controller : Controller
    {
        private readonly LibroAutoresContext _context;

        public Libros2Controller(LibroAutoresContext context)
        {
            _context = context;
        }

        // GET: Libros2
        public async Task<IActionResult> Index()
        {
            var libroAutoresContext = _context.Libros2s.Include(l => l.Autor);
            return View(await libroAutoresContext.ToListAsync());
        }

        // GET: Libros2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libros2s == null)
            {
                return NotFound();
            }

            var libros2 = await _context.Libros2s
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libros2 == null)
            {
                return NotFound();
            }

            return View(libros2);
        }

        // GET: Libros2/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorId");
            return View();
        }

        // POST: Libros2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,GeneroLite,Descripcion,AutorId,Imagen")] Libros2 libros2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libros2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorId", libros2.AutorId);
            return View(libros2);
        }

        // GET: Libros2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libros2s == null)
            {
                return NotFound();
            }

            var libros2 = await _context.Libros2s.FindAsync(id);
            if (libros2 == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorId", libros2.AutorId);
            return View(libros2);
        }

        // POST: Libros2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,GeneroLite,Descripcion,AutorId,Imagen")] Libros2 libros2)
        {
            if (id != libros2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libros2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Libros2Exists(libros2.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorId", libros2.AutorId);
            return View(libros2);
        }

        // GET: Libros2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libros2s == null)
            {
                return NotFound();
            }

            var libros2 = await _context.Libros2s
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libros2 == null)
            {
                return NotFound();
            }

            return View(libros2);
        }

        // POST: Libros2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libros2s == null)
            {
                return Problem("Entity set 'LibroAutoresContext.Libros2s'  is null.");
            }
            var libros2 = await _context.Libros2s.FindAsync(id);
            if (libros2 != null)
            {
                _context.Libros2s.Remove(libros2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Libros2Exists(int id)
        {
          return (_context.Libros2s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
