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
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly BarControlContext _context;

        public ProductController(BarControlContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseModel.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseModel = await _context.BaseModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseModel == null)
            {
                return NotFound();
            }

            return View(baseModel);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] BaseModel baseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseModel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseModel = await _context.BaseModel.FindAsync(id);
            if (baseModel == null)
            {
                return NotFound();
            }
            return View(baseModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id")] BaseModel baseModel)
        {
            if (id != baseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseModelExists(baseModel.Id))
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
            return View(baseModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseModel = await _context.BaseModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseModel == null)
            {
                return NotFound();
            }

            return View(baseModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var baseModel = await _context.BaseModel.FindAsync(id);
            if (baseModel != null)
            {
                _context.BaseModel.Remove(baseModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseModelExists(string id)
        {
            return _context.BaseModel.Any(e => e.Id == id);
        }
    }
}
