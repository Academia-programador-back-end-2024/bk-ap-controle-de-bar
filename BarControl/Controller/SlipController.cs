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
    public class SlipController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly BarControlContext _context;

        public SlipController(BarControlContext context)
        {
            _context = context;
        }

        // GET: Slip
        public async Task<IActionResult> Index()
        {
            var barControlContext = _context.Slip
                .Include(s => s.Client)
                .Include(s => s.Table)
                .Include(s => s.Waiter);
            return View(await barControlContext.ToListAsync());
        }

        // GET: Slip/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slip = await _context.Slip
                .Include(s => s.Client)
                .Include(s => s.Table)
                .Include(s => s.Waiter)
                .Include(s => s.Consumptions)
                    .ThenInclude(consumption => consumption.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slip == null)
            {
                return NotFound();
            }

            return View(slip);
        }

        // GET: Slip/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id");
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id");
            ViewData["WaiterId"] = new SelectList(_context.Waiter, "Id", "Id");
            return View();
        }

        // POST: Slip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,TableId,WaiterId,OpeningDate")] Slip slip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", slip.ClientId);
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id", slip.TableId);
            ViewData["WaiterId"] = new SelectList(_context.Waiter, "Id", "Id", slip.WaiterId);
            return View(slip);
        }

        // GET: Slip/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slip = await _context.Slip.FindAsync(id);
            if (slip == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", slip.ClientId);
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id", slip.TableId);
            ViewData["WaiterId"] = new SelectList(_context.Waiter, "Id", "Id", slip.WaiterId);
            return View(slip);
        }

        // POST: Slip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ClientId,TableId,WaiterId,OpeningDate,ClosingDate,Paid,Id")] Slip slip)
        {
            if (id != slip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlipExists(slip.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", slip.ClientId);
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id", slip.TableId);
            ViewData["WaiterId"] = new SelectList(_context.Waiter, "Id", "Id", slip.WaiterId);
            return View(slip);
        }

        // GET: Slip/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slip = await _context.Slip
                .Include(s => s.Client)
                .Include(s => s.Table)
                .Include(s => s.Waiter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slip == null)
            {
                return NotFound();
            }

            return View(slip);
        }

        // POST: Slip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var slip = await _context.Slip.FindAsync(id);
            if (slip != null)
            {
                _context.Slip.Remove(slip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlipExists(string id)
        {
            return _context.Slip.Any(e => e.Id == id);
        }
    }
}
