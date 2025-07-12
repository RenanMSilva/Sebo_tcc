using Sebo_tcc.Models;
using Sebo_tcc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context, IConfiguration configuration
            )
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            List<SaleItemModel> cartItems = CartHelper.GetCartItems(Request, Response, _context);
            decimal subtotal = CartHelper.GetSubtotal(cartItems);

            ViewBag.CartItems = cartItems;
            ViewBag.Subtotal = subtotal;

            return View();
        }

        [HttpPost]
        public IActionResult Confirm() 
        {
            var cartItems = CartHelper.GetCartItems(Request, Response, _context);


            if (cartItems.Count == 0 )
            {
                return RedirectToAction("Index", "Home");
            }
            decimal subtotal = CartHelper.GetSubtotal(cartItems);
            // save the order
            var order = new SaleModel
            {
                SaleItems = cartItems,
                DateSale = DateTime.Now,
                SalePrice = subtotal,

            };

            _context.Sales.Add(order);
            _context.SaveChanges();




            // delete the shopping cart cookie
            Response.Cookies.Delete("shopping_cart");

            ViewBag.SuccessMessage = "Pedido registrado com sucesso!";

            return RedirectToAction("Index","Books");
        }

    }
}
