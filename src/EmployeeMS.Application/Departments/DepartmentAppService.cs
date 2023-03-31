using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMS.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace EmployeeMS.Departments;

[Authorize(EmployeeMSPermissions.Employees.Default)]
public class DepartmentAppService : EmployeeMSAppService, IDepartmentAppService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly DepartmentManager _departmentManager;

    public DepartmentAppService(
        IDepartmentRepository departmentRepository,
        DepartmentManager departmentManager)
    {
        _departmentRepository = departmentRepository;
        _departmentManager = departmentManager;
    }

    //...SERVICE METHODS WILL COME HERE...
    public async Task<DepartmentDto> GetAsync(Guid id)
    {
        var department = await _departmentRepository.GetAsync(id);
        return ObjectMapper.Map<Department, DepartmentDto>(department);
    }
    public async Task<PagedResultDto<DepartmentDto>> GetListAsync(GetDepartmentListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Department.Name);
        }

        var departments = await _departmentRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _departmentRepository.CountAsync()
            : await _departmentRepository.CountAsync(
                author => author.Name.Contains(input.Filter));

        return new PagedResultDto<DepartmentDto>(
            totalCount,
            ObjectMapper.Map<List<Department>, List<DepartmentDto>>(departments)
        );
    }

    [Authorize(EmployeeMSPermissions.Departments.Create)]
    public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
    {
        var department = await _departmentManager.CreateAsync(
            input.Name,
            input.ShortBio
        );
        await _departmentRepository.InsertAsync(department);
        return ObjectMapper.Map<Department, DepartmentDto>(department);
    }

    [Authorize(EmployeeMSPermissions.Departments.Edit)]
    public async Task UpdateAsync(Guid id, UpdateDepartmentDto input)
    {
        var department = await _departmentRepository.GetAsync(id);

        if (department.Name != input.Name)
        {
            await _departmentManager.ChangeNameAsync(department, input.Name);
        }

        department.ShortBio = input.ShortBio;

        await _departmentRepository.UpdateAsync(department);
    }

    [Authorize(EmployeeMSPermissions.Departments.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _departmentRepository.DeleteAsync(id);
    }

}
