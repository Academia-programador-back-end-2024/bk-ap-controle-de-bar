using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarControl.Data;
using BarControl.Model;

namespace BarControl.Controller
{
    public class WaiterController : BaseController
    {
        private readonly BarControlContext _context;

        public WaiterController(BarControlContext context) : base(context)
        {
            _context = context;
        }

        // GET: Waiter
        public async Task<IActionResult> Index()
        {
            return View(await _context.Waiter.ToListAsync());
        }

        // GET: Waiter/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waiter = await _context.Waiter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waiter == null)
            {
                return NotFound();
            }

            return View(waiter);
        }

        // GET: Waiter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Waiter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name, Age")] Waiter waiter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waiter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waiter);
        }

        // GET: Waiter/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waiter = await _context.Waiter.FindAsync(id);
            if (waiter == null)
            {
                return NotFound();
            }
            return View(waiter);
        }

        // POST: Waiter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name, Age")] Waiter waiter)
        {
            if (id != waiter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waiter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaiterExists(waiter.Id))
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
            return View(waiter);
        }

        // GET: Waiter/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waiter = await _context.Waiter
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.RelatedSlipMessage = IsRelatedToSlip(waiter);

            if (waiter == null)
            {
                return NotFound();
            }

            return View(waiter);
        }

        // POST: Waiter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var waiter = await _context.Waiter.FindAsync(id);
            if (waiter != null)
            {
                _context.Waiter.Remove(waiter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaiterExists(string id)
        {
            return _context.Waiter.Any(e => e.Id == id);
        }
    }
}
