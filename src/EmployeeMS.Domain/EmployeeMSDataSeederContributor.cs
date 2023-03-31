using System;
using System.Threading.Tasks;
using EmployeeMS.Employees;
using EmployeeMS.Departments;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace EmployeeMS;

public class EmployeeMSDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Employee, Guid> _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly DepartmentManager _departmentManager;

    public EmployeeMSDataSeederContributor(
        IRepository<Employee, Guid> employeeRepository,
        IDepartmentRepository departmentRepository,
        DepartmentManager departmentManager)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _departmentManager = departmentManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _employeeRepository.GetCountAsync() > 0)
        {
            return;
        }

        var orwell = await _departmentRepository.InsertAsync(
            await _departmentManager.CreateAsync(
                "BMW",
                "Sheer Driving Pleasure"
            )
        );

        var douglas = await _departmentRepository.InsertAsync(
            await _departmentManager.CreateAsync(
                "Mercedes",
                "Best or Nothing"
            )
        );

        await _employeeRepository.InsertAsync(
            new Employee
            {
                DepartmentId = orwell.Id, // SET THE Department
                Name = "Krishn",
                Age = 21,
                Email = "kri@gmail.com",
                Salary = 2900.84f
            },
            autoSave: true
        );

        await _employeeRepository.InsertAsync(
            new Employee
            {
                DepartmentId = douglas.Id, // SET THE Department
                Name = "Haresh",
                Age = 22,
                Email = "har@gmail.com",
                Salary = 2300.80f
            },
            autoSave: true
        );
    }
}
