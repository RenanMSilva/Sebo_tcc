using Microsoft.AspNetCore.Mvc;
using Sebo_tcc.Models;
using Sebo_tcc.Services;

namespace Sebo_tcc.Controllers
{
    public class BooksController : Controller
    { 
        private readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context)
        {
            this._context = context;   
        }
        public IActionResult Index()
        {   
            IEnumerable<BookModel> books = _context.Books;
            return View(books);
        }
    }
}
