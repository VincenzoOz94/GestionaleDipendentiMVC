using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionaleDipendentiMVC.Data;
using GestionaleDipendentiMVC.Models;
using System.Xml.Serialization;

namespace GestionaleDipendentiMVC.Controllers
{
    public class DipendentiController : Controller
    {
        private readonly GestionaleDipendentiMVCContext _context;

        public DipendentiController(GestionaleDipendentiMVCContext context)
        {
            _context = context;
        }

        // GET: Dipendenti
        public async Task<IActionResult> Index()
        {
            var gestionaleDipendentiMVCContext = _context.Dipendente.Include(d => d.Ruolo);
            return View(await gestionaleDipendentiMVCContext.ToListAsync());
        }
        public IActionResult SalvaToXml()
        {
            string path = "D:\\visualStudio_c#_workspace\\GestionaleDipendentiMVC\\GestionaleDipendentiMVC\\xml";
            var dipendenti = _context.Dipendente.Include(d=>d.Ruolo).ToList();

            var xmlSerializer = new XmlSerializer(typeof(List<Dipendente>));

            using (var stream = new FileStream("dipendenti.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(stream, dipendenti.Select(d => new Dipendente
                {
                    Id = d.Id,
                    Nome = d.Nome,
                    Cognome = d.Cognome,
                    Stipendio = d.Stipendio,
                    RuoloId = d.RuoloId,
                    Ruolo = d.Ruolo 
                }).ToList());
            }

            return RedirectToAction("GetReport","Report");
        }

        // GET: Dipendenti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipendente = await _context.Dipendente
                .Include(d => d.Ruolo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dipendente == null)
            {
                return NotFound();
            }

            return View(dipendente);
        }

        // GET: Dipendenti/Create
        public IActionResult Create()
        {
            ViewData["RuoloId"] = new SelectList(_context.Ruolo, "Id", "NomeRuolo");
            return View();
        }

        // POST: Dipendenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dipendente dipendente)
        {
            
                _context.Add(dipendente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["RuoloId"] = new SelectList(_context.Ruolo, "Id", "NomeRuolo", dipendente.RuoloId);
            return View(dipendente);
        }

        // GET: Dipendenti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipendente = await _context.Dipendente.FindAsync(id);
            if (dipendente == null)
            {
                return NotFound();
            }
            ViewData["RuoloId"] = new SelectList(_context.Ruolo, "Id", "NomeRuolo", dipendente.RuoloId);
            return View(dipendente);
        }

        // POST: Dipendenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Dipendente dipendente)
        {
            if (id != dipendente.Id)
            {
                return NotFound();
            }
                    _context.Update(dipendente);
                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["RuoloId"] = new SelectList(_context.Ruolo, "Id", "NomeRuolo", dipendente.RuoloId);
            return View(dipendente);
        }

        // GET: Dipendenti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipendente = await _context.Dipendente
                .Include(d => d.Ruolo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dipendente == null)
            {
                return NotFound();
            }

            return View(dipendente);
        }

        // POST: Dipendenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dipendente = await _context.Dipendente.FindAsync(id);
            if (dipendente != null)
            {
                _context.Dipendente.Remove(dipendente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DipendenteExists(int id)
        {
            return _context.Dipendente.Any(e => e.Id == id);
        }
    }
    
}
