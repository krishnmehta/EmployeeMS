using System.Threading.Tasks;
using EmployeeMS.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.Web.Pages.Employees{
    public class CreateModalModel : EmployeeMSPageModel
    {
        [BindProperty]
        public CreateUpdateEmployeeDto Employee { get; set; }

        private readonly IEmployeeAppService _employeeAppService;

        public CreateModalModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public void OnGet()
        {
            Employee = new CreateUpdateEmployeeDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeAppService.CreateAsync(Employee);
            return NoContent();
        }
    }
}
