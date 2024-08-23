using ControleDeBar.Data;
using ControleDeBar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Controllers
{
    public class ComandasController : Controller
    {
        private readonly ControleDeBarContext _context;

        public ComandasController(ControleDeBarContext context)
        {
            _context = context;
        }

        // GET: Comandas
        public async Task<IActionResult> Index(ComandaFiltro filtro = null)
        {

            if (filtro == null)
            {
                filtro = new ComandaFiltro();
            }

            ViewBag.Filtro = filtro;


            var queryComandas =
                _context.Comandas
                    .Include(c => c.Cliente)
                    .Include(c => c.Garcom)
                    .Include(c => c.Mesa)
                    .Include(comanda => comanda.Consumos)
                    .ThenInclude(consumo => consumo.Produto)
                    .AsQueryable();

            if (filtro.TermoBusca != string.Empty)
            {
                queryComandas =
                    queryComandas.Where(comanda =>
                        comanda.Cliente.Nome.Contains(filtro.TermoBusca) ||
                        comanda.Garcom.Nome.Contains(filtro.TermoBusca) ||
                        comanda.Mesa.Numero.ToString() == filtro.TermoBusca
                        );
            }



            return View(await queryComandas.ToListAsync());
        }

        // GET: Comandas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comandas
                .Include(c => c.Cliente)
                .Include(c => c.Garcom)
                .Include(c => c.Mesa)
                .Include(comanda => comanda.Consumos)
                    .ThenInclude(consumo => consumo.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comanda == null)
            {
                return NotFound();
            }

            ViewBag.Produtos = _context.Produto.ToList();

            return View(comanda);
        }

        // GET: Comandas/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Clientes.ToList();
            ViewBag.Garcoms = _context.Garcom.ToList();
            ViewBag.Mesas = _context.Mesa.ToList();
            return View();
        }

        // POST: Comandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ClienteId,MesaId,GarcomId,DataDeAbertura")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comanda);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = _context.Clientes.ToList();
            ViewBag.Garcoms = _context.Garcom.ToList();
            ViewBag.Mesas = _context.Mesa.ToList();
            return View(comanda);
        }

        // GET: Comandas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comandas.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", comanda.ClienteId);
            ViewData["GarcomId"] = new SelectList(_context.Garcom, "Id", "Id", comanda.GarcomId);
            ViewData["MesaId"] = new SelectList(_context.Mesa, "Id", "Id", comanda.MesaId);
            return View(comanda);
        }

        // POST: Comandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ClienteId,MesaId,GarcomId,DataDeAbertura,DataDeEncerramento,Pago,Id")] Comanda comanda)
        {
            if (id != comanda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comanda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandaExists(comanda.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", comanda.ClienteId);
            ViewData["GarcomId"] = new SelectList(_context.Garcom, "Id", "Id", comanda.GarcomId);
            ViewData["MesaId"] = new SelectList(_context.Mesa, "Id", "Id", comanda.MesaId);
            return View(comanda);
        }

        // GET: Comandas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comandas
                .Include(c => c.Cliente)
                .Include(c => c.Garcom)
                .Include(c => c.Mesa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var comanda = await _context.Comandas.FindAsync(id);
            if (comanda != null)
            {
                _context.Comandas.Remove(comanda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandaExists(string id)
        {
            return _context.Comandas.Any(e => e.Id == id);
        }


        [HttpPost]
        public IActionResult CriarConsumo(Consumo consumo)
        {
            //Lógica criar o consumo

            _context.Consumos.Add(consumo);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = consumo.ComandaId });
        }
    }
}
