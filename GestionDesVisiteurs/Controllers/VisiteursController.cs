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
    public class VisiteursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisiteursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Visiteurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visiteurs.ToListAsync());
        }

        // GET: Visiteurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visiteur = await _context.Visiteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visiteur == null)
            {
                return NotFound();
            }

            return View(visiteur);
        }

        // GET: Visiteurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visiteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,Telephone,NumeroCIN,DateVisite,HeureEntree,HeureSortie,EstValide")] Visiteur visiteur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visiteur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visiteur);
        }

        // GET: Visiteurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visiteur = await _context.Visiteurs.FindAsync(id);
            if (visiteur == null)
            {
                return NotFound();
            }
            return View(visiteur);
        }

        // POST: Visiteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,Telephone,NumeroCIN,DateVisite,HeureEntree,HeureSortie,EstValide")] Visiteur visiteur)
        {
            if (id != visiteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visiteur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisiteurExists(visiteur.Id))
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
            return View(visiteur);
        }

        // GET: Visiteurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visiteur = await _context.Visiteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visiteur == null)
            {
                return NotFound();
            }

            return View(visiteur);
        }

        // POST: Visiteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visiteur = await _context.Visiteurs.FindAsync(id);
            if (visiteur != null)
            {
                _context.Visiteurs.Remove(visiteur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisiteurExists(int id)
        {
            return _context.Visiteurs.Any(e => e.Id == id);
        }
    }
}
