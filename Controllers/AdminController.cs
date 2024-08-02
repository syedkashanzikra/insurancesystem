using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project1.Context;
using project1.Filters;

namespace project1.Controllers
{
    [CheckUserLoggedIn]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Dashboard()
        {
            return View();
        
        }

        public IActionResult Customer()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Vehicle()
        {
            return View();
        }
    }
}
