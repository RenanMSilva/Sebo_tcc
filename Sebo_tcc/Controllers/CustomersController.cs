using Microsoft.AspNetCore.Mvc;
using Sebo_tcc.DTO;
using Sebo_tcc.Models;
using Sebo_tcc.Services;
using System;

namespace Sebo_tcc.Controllers
{
    public class CustomersController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CustomersController( ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<CustomerModel> customer = _context.Customers;
            return View(customer);
        }


        public IActionResult create ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomersDTO customerdto) 
        {
            if (!ModelState.IsValid)
            {
                return View(customerdto);

            }

            CustomerModel customer = new CustomerModel()
            {
                Name = customerdto.Name,
                CPFCustomer = customerdto.CPFCustomer,
                BirthDate = customerdto.BirthDate,
                NumberCustomer = customerdto.NumberCustomer,

            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            TempData["messageSucess"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("Index", "Customers");

        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return RedirectToAction("Index", "Customers");
            }

            var customerdto = new CustomersDTO()
            {
                Name = customer.Name,
                CPFCustomer = customer.CPFCustomer,
                BirthDate = customer.BirthDate,
                NumberCustomer = customer.NumberCustomer,

            };
            

            return View(customerdto);

        }

        [HttpPost]
        public IActionResult Edit(int id, CustomersDTO customerdto) 
        {
            var customer = _context.Customers.Find(id);

            if (customer == null) 
            {
                return RedirectToAction("Index","Customers");
            }

            if (ModelState.IsValid)
            {
                customer.Name = customerdto.Name;
                customer.CPFCustomer = customerdto.CPFCustomer;
                customer.BirthDate = customerdto.BirthDate;
                customer.NumberCustomer = customerdto.NumberCustomer;
                _context.SaveChanges();

                TempData["messageSucess"] = "Livro editado com sucesso!";
            }

            return RedirectToAction("Index", "Customers");


        }

        public IActionResult Delete(int id) 
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return RedirectToAction("Index", "Customers");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges(true);

            TempData["messageSucess"] = "Cliente excluido com sucesso!";

            return RedirectToAction("Index", "Customers");
        }

        

    }

    
}
