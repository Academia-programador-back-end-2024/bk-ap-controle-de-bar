using ControleDeBar.Data;
using ControleDeBar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Controllers
{
    public class GarcomsController : Controller
    {
        private readonly ControleDeBarContext _context;


        public GarcomsController(ControleDeBarContext context)
        {
            _context = context;
        }

        // GET: Garcons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Garcom.ToListAsync());
        }

        // GET: Garcons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garcon = await _context.Garcom
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
        public async Task<IActionResult> Create([Bind("Id,Nome")] Garcom garcom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garcom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garcom);
        }

        // GET: Garcons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garcon = await _context.Garcom.FindAsync(id);
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
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome")] Garcom garcom)
        {
            if (id != garcom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garcom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarconExists(garcom.Id))
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
            return View(garcom);
        }

        // GET: Garcons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garcon = await _context.Garcom
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
            var garcon = await _context.Garcom.FindAsync(id);
            if (garcon != null)
            {
                _context.Garcom.Remove(garcon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarconExists(string id)
        {
            return _context.Garcom.Any(e => e.Id == id);
        }
    }
}
