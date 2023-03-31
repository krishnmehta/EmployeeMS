using Volo.Abp.Application.Dtos;

namespace EmployeeMS.Departments;

public class GetDepartmentListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
