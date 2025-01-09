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
    public class PersonnelAccueilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonnelAccueilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonnelAccueils
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonnelAcceuils.ToListAsync());
        }

        // GET: PersonnelAccueils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelAccueil = await _context.PersonnelAcceuils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnelAccueil == null)
            {
                return NotFound();
            }

            return View(personnelAccueil);
        }

        // GET: PersonnelAccueils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonnelAccueils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email")] PersonnelAccueil personnelAccueil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personnelAccueil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personnelAccueil);
        }

        // GET: PersonnelAccueils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelAccueil = await _context.PersonnelAcceuils.FindAsync(id);
            if (personnelAccueil == null)
            {
                return NotFound();
            }
            return View(personnelAccueil);
        }

        // POST: PersonnelAccueils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email")] PersonnelAccueil personnelAccueil)
        {
            if (id != personnelAccueil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnelAccueil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnelAccueilExists(personnelAccueil.Id))
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
            return View(personnelAccueil);
        }

        // GET: PersonnelAccueils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelAccueil = await _context.PersonnelAcceuils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnelAccueil == null)
            {
                return NotFound();
            }

            return View(personnelAccueil);
        }

        // POST: PersonnelAccueils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personnelAccueil = await _context.PersonnelAcceuils.FindAsync(id);
            if (personnelAccueil != null)
            {
                _context.PersonnelAcceuils.Remove(personnelAccueil);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonnelAccueilExists(int id)
        {
            return _context.PersonnelAcceuils.Any(e => e.Id == id);
        }
    }
}
