using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sebo_tcc.Models;
using Sebo_tcc.Services;

namespace Sebo_tcc.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SalesController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<SaleItemModel> vendas = _context.SaleItems
            .Include(s => s.Item) 
            .ToList();
            return View(vendas);
        }
    }
}
