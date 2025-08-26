using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTrack.Data;
using SmartTrack.Models;

namespace SmartTrack.Controllers
{
    [Authorize] // All actions require the user to be logged in
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeesController(ApplicationDbContext db) 
        {
            _db = db;
        }
        // Accessible by any authenticated user
        public IActionResult Index( string searchString,int page =1)
        {
            int pageSize = 5;
            var employees =_db.Employees.AsQueryable();
            ViewData["CurrentFilter"]=searchString;
            

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e =>
                    e.FirstName.Contains(searchString) ||
                    e.LastName.Contains(searchString) ||
                    e.EmailAddress.Contains(searchString) ||
                    e.Department.Contains(searchString) ||
                    e.Designation.Contains(searchString));
            }
            int totalRecords = employees.Count();
            // Pagination
            var pagedEmployees = employees
                                 .OrderBy(e => e.EmployeeID)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewBag.SearchString = searchString;

            return View(pagedEmployees);
        }

        //return View(employees.ToList());
        //    List<Employee>objEmployeesList =_db.Employees.ToList();
        //    return View(objEmployeesList);
        //
        // Accessible by Admins only
        [Authorize(Roles = "Admin")]

        public IActionResult Create() 
        { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create( Employee obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);//adds new emp to data base
                _db.SaveChanges();//save changes to database
                return RedirectToAction("Index");
            }
             return View(obj);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null ||id == 0) 
            {
                return NotFound();
            }
            Employee? employee = _db.Employees.Find(id);
            if (employee == null) 
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Employee obj)
        {

            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);//updates new emp to data base
                _db.SaveChanges();//save changes to database
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee? employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Employee obj)
        {

            if (ModelState.IsValid)
            {
                _db.Employees.Remove(obj);//remove new emp to data base
                _db.SaveChanges();//save changes to database
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }

}
