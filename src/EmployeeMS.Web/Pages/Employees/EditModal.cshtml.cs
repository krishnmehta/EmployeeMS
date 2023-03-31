using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMS.Departments;
using EmployeeMS.Employees;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.ObjectMapping;

namespace EmployeeMS.Web.Pages.Employees;

public class EditModalModel : EmployeeMSPageModel
{
    [BindProperty]
    public EditEmployeeViewModel Employee { get; set; }

    public List<SelectListItem> Departments { get; set; }

    private readonly IEmployeeAppService _employeeAppService;

    public EditModalModel(IEmployeeAppService employeeAppService)
    {
        _employeeAppService = employeeAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var employeeDto = await _employeeAppService.GetAsync(id);
        Employee = ObjectMapper.Map<EmployeeDto, EditEmployeeViewModel>(employeeDto);

        var departmentLookup = await _employeeAppService.GetDepartmentLookupAsync();
        Departments = departmentLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _employeeAppService.UpdateAsync(
        Employee.Id,
            ObjectMapper.Map<EditEmployeeViewModel, CreateUpdateEmployeeDto>(Employee)
        );

        return NoContent();
    }

    public class EditEmployeeViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [SelectItems(nameof(Departments))]
        [DisplayName("Department")]
        public Guid DepartmentId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public float Salary { get; set; }
    }
}