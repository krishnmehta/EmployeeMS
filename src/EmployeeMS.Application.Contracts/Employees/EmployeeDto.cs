using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace EmployeeMS.Employees
{
    public class EmployeeDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
}
