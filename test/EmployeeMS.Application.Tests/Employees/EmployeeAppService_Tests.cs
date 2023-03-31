using System;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMS.Departments;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace EmployeeMS.Employees;


public class EmployeeAppService_Tests : EmployeeMSApplicationTestBase
{
    private readonly IEmployeeAppService _employeeAppService;
    private readonly IDepartmentAppService _departmentAppService;

    public EmployeeAppService_Tests()
    {
        _employeeAppService = GetRequiredService<IEmployeeAppService>();
        _departmentAppService = GetRequiredService<IDepartmentAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Employees()
    {
        //Act
        var result = await _employeeAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
        );

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(b => b.Name == "Krishn" &&
                                    b.DepartmentName == "BMW");
    }

    [Fact]
    public async Task Should_Create_A_Valid_Employee()
    {
        var departments = await _departmentAppService.GetListAsync(new GetDepartmentListDto());
        var firstDepartment = departments.Items.First();

        //Act
        var result = await _employeeAppService.CreateAsync(
            new CreateUpdateEmployeeDto
            {
                DepartmentId = firstDepartment.Id,
                Name = "Krishn",
                Age = 21,
                Email = "kri@gmail.com",
                Salary = 2900.20f
            }
        );

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe("Krishn");
    }

    [Fact]
    public async Task Should_Not_Create_A_Employee_Without_Name()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _employeeAppService.CreateAsync(
                new CreateUpdateEmployeeDto
                {
                    Name = "",
                    Age = 10,
                    Email = "h@gmail.com",
                    Salary = 1900.25f
                }
            );
        });

        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(m => m == "Name"));
    }
}
