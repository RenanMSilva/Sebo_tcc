using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sebo_tcc.DTO;
using Sebo_tcc.Models;
using Sebo_tcc.Services;

namespace Sebo_tcc.Controllers
{
    public class LoansController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoansController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<LoanModel> loans = _context.Loans.Include(x => x.Customer).Include(x => x.Book).ToList();
            return View(loans);
        }

        public IActionResult Create() 
        {
            IEnumerable<LoanModel> loans = _context.Loans.Include(x => x.Customer).Include(x => x.Book).ToList();
            return View(loans);
        }

        [HttpPost]
        public IActionResult Create(LoanDTO loandto) 
        {
            if (!ModelState.IsValid)
            {
                return View(loandto);

            }

            var clientid = _context.Customers.FirstOrDefault(x => x.Name == loandto.NameCustomer);
            var bookid = _context.Books.FirstOrDefault(x => x.Title == loandto.TittleBook);

            LoanModel loanmodel = new LoanModel()
            {
                IdBook = bookid.Id,
                IdCustomer = clientid.Id,
                DateLoan = loandto.DateLoan,
                DateReturn = loandto.DateReturn,
                ValueRequest = loandto.ValueRequest,
            };

            _context.Loans.Add(loanmodel);
            _context.SaveChanges();

            TempData["messageSucess"] = "locação realizada com sucesso!";

            return RedirectToAction("Index","Loans");
        }
    }
}
