using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace EmployeeMS.Employees;


public class EmployeeAppService_Tests : EmployeeMSApplicationTestBase
{
    private readonly IEmployeeAppService _employeeAppService;

    public EmployeeAppService_Tests()
    {
        _employeeAppService = GetRequiredService<IEmployeeAppService>();
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
        result.Items.ShouldContain(b => b.Name == "Krishn Mehta");
    }
    [Fact]
    public async Task Should_Create_A_Valid_Employee()
    {
        //Act
        var result = await _employeeAppService.CreateAsync(
            new CreateUpdateEmployeeDto
            {
                Name = "Mahesh",
                Age = 29,
                Email = "ma@gmail.com",
                Salary = 3900f
            }
        );

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe("Mahesh");
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
                    Email = "abc@gmail.com",
                    Salary = 2400f
                }
            );
        });

        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
    }


}
