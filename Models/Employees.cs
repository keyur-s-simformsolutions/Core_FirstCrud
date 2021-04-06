using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCrud_core.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string DateOfJoining { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}
