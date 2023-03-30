using System;
using System.Threading.Tasks;
using EmployeeMS.Departments;
using EmployeeMS.Employees;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace EmployeeMS.Employees;

public class EmployeeMSDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Employee, Guid> _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly DepartmentManager _departmentManager;

    public EmployeeMSDataSeederContributor(IRepository<Employee, Guid> employeeRepository,
        IDepartmentRepository departmentRepository,
        DepartmentManager departmentManager)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _departmentManager = departmentManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _employeeRepository.GetCountAsync() <= 0)
        {
            await _employeeRepository.InsertAsync(
                new Employee
                {
                    Name = "Krishn Mehta",
                    Age = 21,
                    Email = "kri@gmail.com",
                    Salary = 2900.84f
                },
                autoSave: true
            );

            await _employeeRepository.InsertAsync(
                new Employee
                {
                    Name = "Ramesh",
                    Age = 23,
                    Email = "rame@gmail.com",
                    Salary = 2100.30f
                },
                autoSave: true
            );
        }

        // ADDED SEED DATA FOR AUTHORS

        if (await _departmentRepository.GetCountAsync() <= 0)
        {
            await _departmentRepository.InsertAsync(
                await _departmentManager.CreateAsync(
                    "BMW",
                    "Sheer Driving Pleasure"
                )
            );

            await _departmentRepository.InsertAsync(
                await _departmentManager.CreateAsync(
                    "Mercedes",
                    "Best or Nothing"
                )
            );
        }
    }
}
