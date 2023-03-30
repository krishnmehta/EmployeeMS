﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace EmployeeMS.Employees
{
    public class Employee : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public float Salary { get; set; }
    }
}
