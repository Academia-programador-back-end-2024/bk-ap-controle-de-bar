using BarControl.Data;
using BarControl.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BarControl.Controllers
{
    public class BillingController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly BarControlContext _context;
        
        //Constructor 
        public BillingController(BarControlContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            
            var slipQuery = _context.Slip
                .Include(s => s.Client) // Includes another DbSet
                .Include(s => s.Table) // Includes another DbSet
                .Include(s => s.Waiter) // Includes another DbSet
                .Include(s => s.Consumptions)
                .ThenInclude(s => s.Product)
                .AsQueryable();
            
            BillingViewModel viewModel = new BillingViewModel();

            viewModel.Slips = slipQuery.ToList();
            viewModel.BillTotal = viewModel.Slips.Where(slip => slip.Paid != null && slip.Paid == true).Sum(s => s.TotalSellingValue());
            viewModel.PendentTotal = viewModel.Slips.Where(slip => slip.Paid == false).Sum(s => s.TotalSellingValue());
            viewModel.TotalCostSlips = viewModel.Slips.Sum(s => s.TotalSellingValue());
            viewModel.TotalProfit = viewModel.Slips.Sum(s => s.TotalSellingValue());
            
            return View(viewModel);
        }
    }
}