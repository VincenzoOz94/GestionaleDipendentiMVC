using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionaleDipendentiMVC.Data;
using GestionaleDipendentiMVC.Models;

namespace GestionaleDipendentiMVC.Controllers
{
    public class RuoliController : Controller
    {
        private readonly GestionaleDipendentiMVCContext _context;

        public RuoliController(GestionaleDipendentiMVCContext context)
        {
            _context = context;
        }

        // GET: Ruoloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ruolo.ToListAsync());
        }

        // GET: Ruoloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruolo = await _context.Ruolo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ruolo == null)
            {
                return NotFound();
            }

            return View(ruolo);
        }

        // GET: Ruoloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ruoloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeRuolo")] Ruolo ruolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ruolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ruolo);
        }

        // GET: Ruoloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruolo = await _context.Ruolo.FindAsync(id);
            if (ruolo == null)
            {
                return NotFound();
            }
            return View(ruolo);
        }

        // POST: Ruoloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeRuolo")] Ruolo ruolo)
        {
            if (id != ruolo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ruolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RuoloExists(ruolo.Id))
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
            return View(ruolo);
        }

        // GET: Ruoloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruolo = await _context.Ruolo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ruolo == null)
            {
                return NotFound();
            }

            return View(ruolo);
        }

        // POST: Ruoloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ruolo = await _context.Ruolo.FindAsync(id);
            if (ruolo != null)
            {
                _context.Ruolo.Remove(ruolo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RuoloExists(int id)
        {
            return _context.Ruolo.Any(e => e.Id == id);
        }
    }
}
