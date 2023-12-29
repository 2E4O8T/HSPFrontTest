using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HSPFrontTest.Data;
using HSPFrontTest.Models;

namespace HSPFrontTest.Controllers
{
    public class RendezvousController : Controller
    {
        private readonly AppDbContext _context;

        public RendezvousController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Rendezvous
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Rendezvouss.OrderBy(r => r.DateRendezvous).Include(r => r.Medecin).Include(r => r.Patient);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Rendezvous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rendezvouss == null)
            {
                return NotFound();
            }

            var rendezvous = await _context.Rendezvouss
                .Include(r => r.Medecin)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.id == id);
            if (rendezvous == null)
            {
                return NotFound();
            }

            return View(rendezvous);
        }

        // GET: Rendezvous/Create
        public IActionResult Create()
        {
            ViewData["MedecinId"] = new SelectList(_context.Medecins, "Id", "Nom");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Nom");
            return View();
        }

        // POST: Rendezvous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DateRendezvous,PatientId,MedecinId")] Rendezvous rendezvous)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rendezvous);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedecinId"] = new SelectList(_context.Medecins, "Id", "Id", rendezvous.MedecinId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", rendezvous.PatientId);
            return View(rendezvous);
        }

        // GET: Rendezvous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rendezvouss == null)
            {
                return NotFound();
            }

            var rendezvous = await _context.Rendezvouss.FindAsync(id);
            if (rendezvous == null)
            {
                return NotFound();
            }
            ViewData["MedecinId"] = new SelectList(_context.Medecins, "Id", "Id", rendezvous.MedecinId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", rendezvous.PatientId);
            return View(rendezvous);
        }

        // POST: Rendezvous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DateRendezvous,PatientId,MedecinId")] Rendezvous rendezvous)
        {
            if (id != rendezvous.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rendezvous);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendezvousExists(rendezvous.id))
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
            ViewData["MedecinId"] = new SelectList(_context.Medecins, "Id", "Id", rendezvous.MedecinId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", rendezvous.PatientId);
            return View(rendezvous);
        }

        // GET: Rendezvous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rendezvouss == null)
            {
                return NotFound();
            }

            var rendezvous = await _context.Rendezvouss
                .Include(r => r.Medecin)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.id == id);
            if (rendezvous == null)
            {
                return NotFound();
            }

            return View(rendezvous);
        }

        // POST: Rendezvous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rendezvouss == null)
            {
                return Problem("Entity set 'AppDbContext.Rendezvouss'  is null.");
            }
            var rendezvous = await _context.Rendezvouss.FindAsync(id);
            if (rendezvous != null)
            {
                _context.Rendezvouss.Remove(rendezvous);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RendezvousExists(int id)
        {
          return (_context.Rendezvouss?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
