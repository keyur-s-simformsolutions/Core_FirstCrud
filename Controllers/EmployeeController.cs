using AutoMapper;
using EmployeeCrud_core.Infastucture;
using EmployeeCrud_core.Models;
using Microsoft.AspNetCore.Components;
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
        private readonly IEmployeeRepo _repo;
        private readonly MyDbContext _context;
       [Inject]
        public IMapper _Mapper { get; set; }

        public EmployeeController(MyDbContext context,IEmployeeRepo Repo, IMapper Mapper)
        {
            _context = context;
            _repo = Repo;
            _Mapper = Mapper;
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
                var empInDb = _context.Employees.SingleOrDefault(e => e.EmployeeId == employee.EmployeeId);

                _Mapper.Map(employee, empInDb);
                _context.SaveChanges();
                //_context.Entry(employee).State = EntityState.Modified;
                //_context.savechanges();

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
            //var Edit = _context.Employees.FirstOrDefault(x=>x.EmployeeId == Id);
            var Edit = _repo.Edit(Id);

            return View("Index",Edit);
        }
        [HttpPost]
        public int Delete(int Id)
        {
            var del = _context.Employees.FirstOrDefault(x => x.EmployeeId == Id);
            _context.Employees.Remove(del);
            _context.SaveChanges();
            return 1;
          
        }
        public IActionResult Details(int Id)
        {
            var detail = _context.Employees.FirstOrDefault(x => x.EmployeeId == Id);

            return View(detail);
        }


    }
}
