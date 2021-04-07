using EmployeeCrud_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCrud_core.Infastucture
{
    public interface IEmployeeRepo
    {
        Employees Edit(int Id);

    }
}
