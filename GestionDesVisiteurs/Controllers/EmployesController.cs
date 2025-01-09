using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionDesVisiteurs;
using GestionDesVisiteurs.Models;

namespace GestionDesVisiteurs.Controllers
{
    public class EmployesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employes.Include(e => e.Directeur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employes
                .Include(e => e.Directeur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // GET: Employes/Create
        public IActionResult Create()
        {
            ViewData["DirecteurId"] = new SelectList(_context.Directeurs, "Id", "Departement");
            return View();
        }

        // POST: Employes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Poste,DirecteurId")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirecteurId"] = new SelectList(_context.Directeurs, "Id", "Departement", employe.DirecteurId);
            return View(employe);
        }

        // GET: Employes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employes.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            ViewData["DirecteurId"] = new SelectList(_context.Directeurs, "Id", "Departement", employe.DirecteurId);
            return View(employe);
        }

        // POST: Employes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Poste,DirecteurId")] Employe employe)
        {
            if (id != employe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.Id))
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
            ViewData["DirecteurId"] = new SelectList(_context.Directeurs, "Id", "Departement", employe.DirecteurId);
            return View(employe);
        }

        // GET: Employes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employes
                .Include(e => e.Directeur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employe = await _context.Employes.FindAsync(id);
            if (employe != null)
            {
                _context.Employes.Remove(employe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeExists(int id)
        {
            return _context.Employes.Any(e => e.Id == id);
        }
    }
}
