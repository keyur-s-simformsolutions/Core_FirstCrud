using EmployeeCrud_core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCrud_core.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyDbContext _context;

        public EmployeeController(MyDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Employees employee)
        {
            if (employee.EmployeeId == 0)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
        
            else
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();

            }

            return RedirectToAction("EmployeeList");
        }
        public IActionResult EmployeeList()
        {
           var model= _context.Employees.ToList();
     
            return View(model);
        }
        public IActionResult Edit(int Id)
        {
            var Edit = _context.Employees.FirstOrDefault(x=>x.EmployeeId == Id);

            return View("Index",Edit);
        }
        public IActionResult Delete(int Id)
        {
            var del = _context.Employees.FirstOrDefault(x => x.EmployeeId == Id);
            _context.Employees.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
        public IActionResult Details(int Id)
        {
            var detail = _context.Employees.FirstOrDefault(x => x.EmployeeId == Id);

            return View(detail);
        }


    }
}
