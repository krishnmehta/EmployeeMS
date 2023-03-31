using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EmployeeMS.Employees
{
    public class EmployeeFilterDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
