using EmployeeMS.Employees;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EmployeeMS.Employees;

public interface IEmployeeAppService :
    ICrudAppService< //Defines CRUD methods
        EmployeeDto, //Used to show employees
        Guid, //Primary key of the employee entity
        EmployeeFilterDto, //Used for paging/sorting
        CreateUpdateEmployeeDto> //Used to create/update a employee
{
    // ADD the NEW METHOD
    Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync();

}
