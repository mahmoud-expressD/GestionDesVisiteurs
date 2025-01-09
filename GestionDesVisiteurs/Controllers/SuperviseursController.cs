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
    public class SuperviseursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperviseursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Superviseurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Superviseurs.ToListAsync());
        }

        // GET: Superviseurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superviseur = await _context.Superviseurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superviseur == null)
            {
                return NotFound();
            }

            return View(superviseur);
        }

        // GET: Superviseurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Superviseurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,Cin,Telephone")] Superviseur superviseur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superviseur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superviseur);
        }

        // GET: Superviseurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superviseur = await _context.Superviseurs.FindAsync(id);
            if (superviseur == null)
            {
                return NotFound();
            }
            return View(superviseur);
        }

        // POST: Superviseurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,Cin,Telephone")] Superviseur superviseur)
        {
            if (id != superviseur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superviseur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperviseurExists(superviseur.Id))
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
            return View(superviseur);
        }

        // GET: Superviseurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superviseur = await _context.Superviseurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superviseur == null)
            {
                return NotFound();
            }

            return View(superviseur);
        }

        // POST: Superviseurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superviseur = await _context.Superviseurs.FindAsync(id);
            if (superviseur != null)
            {
                _context.Superviseurs.Remove(superviseur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperviseurExists(int id)
        {
            return _context.Superviseurs.Any(e => e.Id == id);
        }
    }
}
