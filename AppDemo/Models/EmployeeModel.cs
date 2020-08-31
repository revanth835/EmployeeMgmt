using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Models
{
    public class EmployeeModel
    {
        [Required]
        public string Name { get; set; }
        public string Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Skillsets { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        public bool IsActive { get; set; }
    }
}
