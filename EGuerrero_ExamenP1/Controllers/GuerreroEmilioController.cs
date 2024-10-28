using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EGuerrero_ExamenP1.Data;
using EGuerrero_ExamenP1.Models;

namespace EGuerrero_ExamenP1.Controllers
{
    public class GuerreroEmilioController : Controller
    {
        private readonly EGuerrero_ExamenP1Context _context;

        public GuerreroEmilioController(EGuerrero_ExamenP1Context context)
        {
            _context = context;
        }

        // GET: GuerreroEmilio
        public async Task<IActionResult> Index()
        {
            var eGuerrero_ExamenP1Context = _context.GuerreroEmilio.Include(g => g.Celular);
            return View(await eGuerrero_ExamenP1Context.ToListAsync());
        }

        // GET: GuerreroEmilio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guerreroEmilio = await _context.GuerreroEmilio
                .Include(g => g.Celular)
                .FirstOrDefaultAsync(m => m.IdE == id);
            if (guerreroEmilio == null)
            {
                return NotFound();
            }

            return View(guerreroEmilio);
        }

        // GET: GuerreroEmilio/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo");
            return View();
        }

        // POST: GuerreroEmilio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdE,Nombre,Apellido,TieneExperiencia,FechaNacimiento,Salario,Modelo")] GuerreroEmilio guerreroEmilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guerreroEmilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", guerreroEmilio.Id);
            return View(guerreroEmilio);
        }

        // GET: GuerreroEmilio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guerreroEmilio = await _context.GuerreroEmilio.FindAsync(id);
            if (guerreroEmilio == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", guerreroEmilio.Id);
            return View(guerreroEmilio);
        }

        // POST: GuerreroEmilio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdE,Nombre,Apellido,TieneExperiencia,FechaNacimiento,Salario,Modelo")] GuerreroEmilio guerreroEmilio)
        {
            if (id != guerreroEmilio.IdE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guerreroEmilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuerreroEmilioExists(guerreroEmilio.IdE))
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
            ViewData["Id"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", guerreroEmilio.Id);
            return View(guerreroEmilio);
        }

        // GET: GuerreroEmilio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guerreroEmilio = await _context.GuerreroEmilio
                .Include(g => g.Celular)
                .FirstOrDefaultAsync(m => m.IdE == id);
            if (guerreroEmilio == null)
            {
                return NotFound();
            }

            return View(guerreroEmilio);
        }

        // POST: GuerreroEmilio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guerreroEmilio = await _context.GuerreroEmilio.FindAsync(id);
            if (guerreroEmilio != null)
            {
                _context.GuerreroEmilio.Remove(guerreroEmilio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuerreroEmilioExists(int id)
        {
            return _context.GuerreroEmilio.Any(e => e.IdE == id);
        }
    }
}
