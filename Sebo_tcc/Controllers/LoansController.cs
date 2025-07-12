using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sebo_tcc.DTO;
using Sebo_tcc.FormViewModel;
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
            var viewModel = new LoanFormViewModel
            {
                Loan = new LoanDTO
                {
                    DateLoan = DateTime.Today,
                    DateReturn = DateTime.Today.AddDays(7) // ou qualquer outra data padrão
                },

                Customers = _context.Customers
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),    // ← envia o ID
                Text = c.Name               // ← mostra o nome
            }).ToList(),

                Books = _context.Books
            .Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Title
            }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(LoanFormViewModel ViewModel)
        {
            var dto = ViewModel.Loan;
            if (!ModelState.IsValid)
            {
                var viewModel = new LoanFormViewModel
                {
                    Loan = dto,
                    Customers = _context.Customers.Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList(),
                    Books = _context.Books.Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Title
                    }).ToList()
                };

                return View(viewModel);
            }

            
            var loan = new LoanModel
            {
                IdCustomer = dto.IdCustomer,
                IdBook = dto.IdBook,
                DateLoan = dto.DateLoan,
                DateReturn = dto.DateReturn,
                ValueRequest = dto.ValueRequest
            };

            var stock = _context.Books.Find(dto.IdBook);
            stock.Quantity--;

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Return(int id)
        {
            var loans = _context.Loans.Find(id);
            if (loans == null)
            {
                return RedirectToAction("Index", "Loans");
            }

            var stock = _context.Books.Find(loans.IdBook);
            stock.Quantity++;

            _context.Loans.Remove(loans);
            _context.SaveChanges(true);

            TempData["messageSucess"] = "Livro devolvido com sucesso!";

            return RedirectToAction("Index", "Loans");
        }


        //public IActionResult Create() 
        //{
        //    IEnumerable<LoanModel> loans = _context.Loans.Include(x => x.Customer).Include(x => x.Book).ToList();
        //    return View(loans);
        //}



        //[HttpPost]
        //public IActionResult Create(LoanDTO loandto) 
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(loandto);

        //    }

        //    var clientid = _context.Customers.FirstOrDefault(x => x.Name == loandto.NameCustomer);
        //    var bookid = _context.Books.FirstOrDefault(x => x.Title == loandto.TittleBook);

        //    LoanModel loanmodel = new LoanModel()
        //    {
        //       IdBook = bookid.Id,
        //        IdCustomer = clientid.Id,
        //        DateLoan = loandto.DateLoan,
        //        DateReturn = loandto.DateReturn,
        //        ValueRequest = loandto.ValueRequest,
        //    };

        //    _context.Loans.Add(loanmodel);
        //    _context.SaveChanges();

        //    TempData["messageSucess"] = "locação realizada com sucesso!";

        //    return RedirectToAction("Index","Loans");
        //}
    }
}
