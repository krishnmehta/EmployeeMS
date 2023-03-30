using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace EmployeeMS.Pages;

public class Index_Tests : EmployeeMSWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
