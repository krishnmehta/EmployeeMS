using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace EmployeeMS.Departments;


public class DepartmentAppService_Tests : EmployeeMSApplicationTestBase
{
    private readonly IDepartmentAppService _departmentAppService;

    public DepartmentAppService_Tests()
    {
        _departmentAppService = GetRequiredService<IDepartmentAppService>();
    }

    [Fact]
    public async Task Should_Get_All_Departments_Without_Any_Filter()
    {
        var result = await _departmentAppService.GetListAsync(new GetDepartmentListDto());

        result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
        result.Items.ShouldContain(department => department.Name == "BMW");
        result.Items.ShouldContain(department => department.Name == "Mercedes");
    }

    [Fact]
    public async Task Should_Get_Filtered_Departments()
    {
        var result = await _departmentAppService.GetListAsync(
            new GetDepartmentListDto { Filter = "BM" });

        result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
        result.Items.ShouldContain(department => department.Name == "BMW");
        result.Items.ShouldNotContain(department => department.Name == "Mercedes");
    }

    [Fact]
    public async Task Should_Create_A_New_Department()
    {
        var departmentDto = await _departmentAppService.CreateAsync(
            new CreateDepartmentDto
            {
                Name = "Edward Bellamy",
                ShortBio = "Edward Bellamy was an American author..."
            }
        );

        departmentDto.Id.ShouldNotBe(Guid.Empty);
        departmentDto.Name.ShouldBe("Edward Bellamy");
    }

    [Fact]
    public async Task Should_Not_Allow_To_Create_Duplicate_Department()
    {
        await Assert.ThrowsAsync<DepartmentAlreadyExistsException>(async () =>
        {
            await _departmentAppService.CreateAsync(
                new CreateDepartmentDto
                {
                    Name = "Douglas Adams",
                    ShortBio = "..."
                }
            );
        });
    }

    //TODO: Test other methods...
}
