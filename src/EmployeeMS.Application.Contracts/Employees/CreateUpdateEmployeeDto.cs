using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeMS.Employees
{
    public class CreateUpdateEmployeeDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public float Salary { get; set; }

        public Guid DepartmentId { get; set; }

    }
}
