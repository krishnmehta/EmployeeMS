using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EmployeeMS.Employees;

public class EmployeeAppService :
    CrudAppService<
        Employee, //The Employee entity
        EmployeeDto, //Used to show employees
        Guid, //Primary key of the employee entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateEmployeeDto>, //Used to create/update a employee
    IEmployeeAppService //implement the IEmployeeAppService
{
    public EmployeeAppService(IRepository<Employee, Guid> repository)
        : base(repository)
    {

    }
}
