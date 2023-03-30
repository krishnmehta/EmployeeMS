using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace EmployeeMS.Departments;

public class DepartmentManager : DomainService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentManager(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Department> CreateAsync(
        [NotNull] string name,
        [CanBeNull] string shortBio = null)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingAuthor = await _departmentRepository.FindByNameAsync(name);
        if (existingAuthor != null)
        {
            throw new DepartmentAlreadyExistsException(name);
        }

        return new Department(
            GuidGenerator.Create(),
            name,
            shortBio
        );
    }

    public async Task ChangeNameAsync(
        [NotNull] Department department,
        [NotNull] string newName)
    {
        Check.NotNull(department, nameof(department));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingAuthor = await _departmentRepository.FindByNameAsync(newName);
        if (existingAuthor != null && existingAuthor.Id != department.Id)
        {
            throw new DepartmentAlreadyExistsException(newName);
        }

        department.ChangeName(newName);
    }
}
