using AjaxCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxCrud.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AjaxController(ApplicationDbContext context)
        {
            _context =   context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult EmployeeList()
        {
            var data = _context.Employees.ToList(); 
            return new JsonResult(data);
        }
        [HttpPost]
        public JsonResult AddEmployee(Employee employee)
        {
            var emp = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,   
            };
            _context.Employees.Add(emp);    
            _context.SaveChanges();
            return new JsonResult("Data saved");   
        }
        public JsonResult Delete(int id)
        {
            var data= _context.Employees.Where(e=>e.Id==id).SingleOrDefault();
            _context.Employees.Remove(data);    
            _context.SaveChanges(); 
            return new JsonResult("Data Deleted");
        }
        //[HttpPost]
        public JsonResult Edit(int id)
        {
            var data=_context.Employees.Where(e=>e.Id == id).SingleOrDefault();
            _context.SaveChanges();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return new JsonResult("Data updated");
        }
    }
}
