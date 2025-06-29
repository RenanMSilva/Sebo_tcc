using Microsoft.AspNetCore.Mvc;
using Sebo_tcc.DTO;
using Sebo_tcc.Models;
using Sebo_tcc.Services;

namespace Sebo_tcc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<EmployeeModel> employee = _context.Employees;
            return View(employee);
        }


        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeesDTO employessdto)
        {
            if (!ModelState.IsValid)
            {
                return View(employessdto);

            }

            EmployeeModel employee = new EmployeeModel()
            {
                NameEmployee = employessdto.NameEmployee,
                CPFEmployee = employessdto.CPFEmployee,
                DataHiring = employessdto.DataHiring,
                EmailEmployee = employessdto.EmailEmployee,


            };

            _context.Employees.Add(employee);
            _context.SaveChanges();

            TempData["messageSucess"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("Index", "Customers");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return RedirectToAction("Index", "Customers");
            }

            var employeedto = new EmployeesDTO()
            {
                NameEmployee = employee.NameEmployee,
                EmailEmployee = employee.EmailEmployee,
                CPFEmployee = employee.CPFEmployee,
                DataHiring = employee.DataHiring


            };


            return View(employeedto);

        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeesDTO employeedto)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            if (ModelState.IsValid)
            {
                employee.NameEmployee = employeedto.NameEmployee;
                employee.EmailEmployee = employeedto.EmailEmployee;
                employee.CPFEmployee = employeedto.CPFEmployee;
                employee.DataHiring = employeedto.DataHiring;
                
                _context.SaveChanges();

                TempData["messageSucess"] = "Cadastro de colaborador editado com sucesso!";
            }

            return RedirectToAction("Index", "Employees");


        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges(true);

            TempData["messageSucess"] = "Cliente excluido com sucesso!";

            return RedirectToAction("Index", "Customers");
        }


    }
}

