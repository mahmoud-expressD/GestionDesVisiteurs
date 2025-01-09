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
    public class DirecteursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DirecteursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Directeurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Directeurs.ToListAsync());
        }

        // GET: Directeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directeur = await _context.Directeurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directeur == null)
            {
                return NotFound();
            }

            return View(directeur);
        }

        // GET: Directeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Departement")] Directeur directeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directeur);
        }

        // GET: Directeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directeur = await _context.Directeurs.FindAsync(id);
            if (directeur == null)
            {
                return NotFound();
            }
            return View(directeur);
        }

        // POST: Directeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Departement")] Directeur directeur)
        {
            if (id != directeur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirecteurExists(directeur.Id))
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
            return View(directeur);
        }

        // GET: Directeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directeur = await _context.Directeurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directeur == null)
            {
                return NotFound();
            }

            return View(directeur);
        }

        // POST: Directeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directeur = await _context.Directeurs.FindAsync(id);
            if (directeur != null)
            {
                _context.Directeurs.Remove(directeur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirecteurExists(int id)
        {
            return _context.Directeurs.Any(e => e.Id == id);
        }
    }
}
