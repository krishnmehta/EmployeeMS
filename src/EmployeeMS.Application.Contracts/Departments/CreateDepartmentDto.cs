using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Departments;

public class CreateDepartmentDto
{
    [Required]
    [StringLength(DepartmentConsts.MaxNameLength)]
    public string Name { get; set; }

    public string ShortBio { get; set; }
}
