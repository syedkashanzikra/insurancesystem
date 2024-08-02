using Microsoft.AspNetCore.Mvc;
using project1.Context;
using project1.Filters;
using project1.Models;
using System.Text;

namespace project1.Controllers
{
    [CheckUserLoggedIn]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public IActionResult Add_Customer() 
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]  // Helps prevent CSRF attacks
        public IActionResult Add_Customer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerAdded = DateTime.Now;
                // Assuming you have a database context called _context
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Dashboard","Admin");  // Redirect to the index view or wherever appropriate
            }
            return View(customer);  // Return view with validation errors
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();  // Return a not found response if the customer does not exist
            }
            return View(customer);  // Pass the customer to the view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerAdded = DateTime.Now;
                _context.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Customer", "Admin");  // Redirect to the dashboard after updating
            }
            return View(customer);  // If the model state is not valid, return the view with the current data
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();  // If the customer does not exist, return a not found response
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Customer", "Admin");  // Redirect to the dashboard after deleting
        }

        public IActionResult ExportToExcel()
        {
            var customers = _context.Customers.ToList();
            var sb = new StringBuilder();
            sb.AppendLine("Name,Email,Added Date");
            foreach (var customer in customers)
            {
                sb.AppendLine($"{customer.CustomerName},{customer.CustomerEmail},{customer.CustomerAdded:dd MMM yyyy}");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Customers.csv");
        }

    }
}
