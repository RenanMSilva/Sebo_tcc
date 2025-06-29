using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Sebo_tcc.DTO;
using Sebo_tcc.Models;
using Sebo_tcc.Services;

namespace Sebo_tcc.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        public BooksController(ApplicationDbContext context, IWebHostEnvironment enviroment)
        {
            this._context = context;
            this._enviroment = enviroment;
        }
        public IActionResult Index()
        {
            IEnumerable<BookModel> books = _context.Books;
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookDTO bookdto)
        {

            if (!ModelState.IsValid)
            {
                return View(bookdto);

            }

            string newFileName = "";
            if (bookdto.ImageBook != null)
            {
                // bookdto.ImageBook = "livro sem imagem";
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(bookdto.ImageBook!.FileName);

                string imagefullpath = _enviroment.WebRootPath + "/assets/img/" + newFileName;
                using (var stream = System.IO.File.Create(imagefullpath))
                {
                    bookdto.ImageBook.CopyTo(stream);
                }
            }


            BookModel book = new BookModel()
            {
                Title = bookdto.Title,
                Description = bookdto.Description,
                Author = bookdto.Author,
                Price = bookdto.Price,
                YearPublication = bookdto.YearPublication,
                ImageBook = newFileName,
                LiteraryGenre = bookdto.LiteraryGenre,

            };

            _context.Books.Add(book);
            _context.SaveChanges();

            TempData["messageSucess"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("Index", "Books");
        }

        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return RedirectToAction("Index", "Books");
            }

            string imagefullpath = _enviroment.WebRootPath + "/assets/img/" + book.ImageBook;
            System.IO.File.Delete(imagefullpath);

            _context.Books.Remove(book);
            _context.SaveChanges(true);

            TempData["messageSucess"] = "Livro excluido com sucesso!";

            return RedirectToAction("Index", "Books");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return RedirectToAction("Index", "Books");
            }

            var bookdto = new BookDTO()
            {
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Price = book.Price,
                YearPublication = book.YearPublication,
                LiteraryGenre = book.LiteraryGenre,
                Quantity = book.Quantity,

            };
            ViewData["ImageFileName"] = book.ImageBook;

            return View(bookdto);
        }

        [HttpPost]
        public IActionResult Edit(int id, BookDTO bookdto)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return RedirectToAction("Index", "Books");

            }

            if (!ModelState.IsValid)
            {

                ViewData["ImageFileName"] = book.ImageBook;
                return View(bookdto);
            }

            //update image file if user change the image
            string newFileName = book.ImageBook;
            if (bookdto.ImageBook != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(bookdto.ImageBook.FileName);

                string imageFullPath = _enviroment.WebRootPath + "/assets/img/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    bookdto.ImageBook.CopyTo(stream);

                }

                //delete the old img
                if (book.ImageBook != "")
                {
                    string oldImageFullPatch = _enviroment.WebRootPath + "/assets/img/" + book.ImageBook;
                    System.IO.File.Delete(oldImageFullPatch);
                }

            }

            book.Title = bookdto.Title;
            book.Description = bookdto.Description;
            book.Author = bookdto.Author;
            book.Quantity = bookdto.Quantity;
            book.LiteraryGenre = bookdto.LiteraryGenre;
            book.ImageBook = newFileName;
            book.Price = bookdto.Price;
            book.YearPublication = bookdto.YearPublication;

            _context.SaveChanges();

            TempData["messageSucess"] = "Livro editado com sucesso!";

            return RedirectToAction("Index", "Books");



        }
    }
}
