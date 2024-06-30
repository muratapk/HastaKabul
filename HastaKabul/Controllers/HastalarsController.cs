using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaKabul.Data;
using HastaKabul.Models;

namespace HastaKabul.Controllers
{
    public class HastalarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HastalarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hastalars
        public async Task<IActionResult> Index()
        {
              return _context.hastalars != null ? 
                          View(await _context.hastalars.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.hastalars'  is null.");
        }

        // GET: Hastalars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.hastalars == null)
            {
                return NotFound();
            }

            var hastalar = await _context.hastalars
                .FirstOrDefaultAsync(m => m.HastaId == id);
            if (hastalar == null)
            {
                return NotFound();
            }

            return View(hastalar);
        }

        // GET: Hastalars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hastalars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HastaId,HastaTc,HastaAd,HastaYas,HastaEmail,HastaPassword")] Hastalar hastalar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastalar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hastalar);
        }

        // GET: Hastalars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.hastalars == null)
            {
                return NotFound();
            }

            var hastalar = await _context.hastalars.FindAsync(id);
            if (hastalar == null)
            {
                return NotFound();
            }
            return View(hastalar);
        }

        // POST: Hastalars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HastaId,HastaTc,HastaAd,HastaYas,HastaEmail,HastaPassword")] Hastalar hastalar)
        {
            if (id != hastalar.HastaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastalar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastalarExists(hastalar.HastaId))
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
            return View(hastalar);
        }

        // GET: Hastalars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.hastalars == null)
            {
                return NotFound();
            }

            var hastalar = await _context.hastalars
                .FirstOrDefaultAsync(m => m.HastaId == id);
            if (hastalar == null)
            {
                return NotFound();
            }

            return View(hastalar);
        }

        // POST: Hastalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.hastalars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.hastalars'  is null.");
            }
            var hastalar = await _context.hastalars.FindAsync(id);
            if (hastalar != null)
            {
                _context.hastalars.Remove(hastalar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastalarExists(int id)
        {
          return (_context.hastalars?.Any(e => e.HastaId == id)).GetValueOrDefault();
        }
    }
}
