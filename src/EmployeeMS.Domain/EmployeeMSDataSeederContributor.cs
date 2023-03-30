using System;
using System.Threading.Tasks;
using EmployeeMS.Employees;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace EmployeeMS.Employees;

public class EmployeeMSDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Employee, Guid> _employeeRepository;

    public EmployeeMSDataSeederContributor(IRepository<Employee, Guid> employeeRepository)
    {
        _employeeRepository = employeeRepository;
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
    }
}
