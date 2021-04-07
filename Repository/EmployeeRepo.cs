using EmployeeCrud_core.Infastucture;
using EmployeeCrud_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCrud_core.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly MyDbContext _context;

        public EmployeeRepo(MyDbContext context)
        {
            _context = context;
        }
        public Employees Edit(int Id)
        {
            return _context.Employees.FirstOrDefault(x => x.EmployeeId == Id);
        }
    }
}
