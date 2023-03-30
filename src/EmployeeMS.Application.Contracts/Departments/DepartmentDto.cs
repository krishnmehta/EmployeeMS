using System;
using Volo.Abp.Application.Dtos;

namespace EmployeeMS.Departments;

public class DepartmentDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public string ShortBio { get; set; }
}
