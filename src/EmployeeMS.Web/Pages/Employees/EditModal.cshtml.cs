using System;
using System.Threading.Tasks;
using EmployeeMS.Employees;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.Web.Pages.Employees;

public class EditModalModel : EmployeeMSPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateEmployeeDto Employee { get; set; }

    private readonly IEmployeeAppService _employeeAppService;

    public EditModalModel(IEmployeeAppService employeeAppService)
    {
        _employeeAppService = employeeAppService;
    }

    public async Task OnGetAsync()
    {
        var bookDto = await _employeeAppService.GetAsync(Id);
        Employee = ObjectMapper.Map<EmployeeDto, CreateUpdateEmployeeDto>(bookDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _employeeAppService.UpdateAsync(Id, Employee);
        return NoContent();
    }
}
