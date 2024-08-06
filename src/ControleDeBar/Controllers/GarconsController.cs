using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeBar.Data;
using ControleDeBar.Model;

namespace ControleDeBar.Controllers
{
    public class GarconsController : Controller
    {
        private readonly ControleDeBarContext _context;

        public GarconsController(ControleDeBarContext context)
        {
            _context = context;
        }

        // GET: Garcons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Garcon.ToListAsync());
        }

        // GET: Garcons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garcon = await _context.Garcon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garcon == null)
            {
                return NotFound();
            }

            return View(garcon);
        }

        // GET: Garcons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Garcons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Garcon garcon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garcon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garcon);
        }

        // GET: Garcons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garcon = await _context.Garcon.FindAsync(id);
            if (garcon == null)
            {
                return NotFound();
            }
            return View(garcon);
        }

        // POST: Garcons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome")] Garcon garcon)
        {
            if (id != garcon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garcon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarconExists(garcon.Id))
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
            return View(garcon);
        }

        // GET: Garcons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garcon = await _context.Garcon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garcon == null)
            {
                return NotFound();
            }

            return View(garcon);
        }

        // POST: Garcons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var garcon = await _context.Garcon.FindAsync(id);
            if (garcon != null)
            {
                _context.Garcon.Remove(garcon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarconExists(string id)
        {
            return _context.Garcon.Any(e => e.Id == id);
        }
    }
}
