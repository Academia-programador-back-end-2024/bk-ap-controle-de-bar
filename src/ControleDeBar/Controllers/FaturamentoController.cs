using ControleDeBar.Data;
using ControleDeBar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Controllers
{
    public class FaturamentoController : Controller
    {
        private readonly ControleDeBarContext _context;

        public FaturamentoController(ControleDeBarContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var queryComandas =
                _context.Comandas
                    .Include(c => c.Cliente)
                    .Include(c => c.Garcom)
                    .Include(c => c.Mesa)
                    .Include(comanda => comanda.Consumos)
                    .ThenInclude(consumo => consumo.Produto)
                    .AsQueryable();



            FaturamentoViewModel viewModel = new FaturamentoViewModel();

            viewModel.Comandas = queryComandas.ToList();
            viewModel.TotalFaturado =
                viewModel.Comandas.Where(comanda => comanda.Pago != null &&
                                                    comanda.Pago == true).Sum(c => c.TotalVenda());
            viewModel.TotalFaturado =
                viewModel.Comandas.Where(comanda => comanda.Pago != null &&
                                                    comanda.Pago == false).Sum(c => c.TotalVenda());
            viewModel.CustoTotal = viewModel.Comandas.Sum(c => c.TotalCusto());
            viewModel.LucroTotal = viewModel.Comandas.Sum(c => c.TotalVenda());



            return View(viewModel);
        }
    }
}
