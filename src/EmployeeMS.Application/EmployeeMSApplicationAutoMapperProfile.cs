using AutoMapper;
using EmployeeMS.Departments;
using EmployeeMS.Employees;

namespace EmployeeMS;

public class EmployeeMSApplicationAutoMapperProfile : Profile
{
    public EmployeeMSApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Employee, EmployeeDto>();
        CreateMap<CreateUpdateEmployeeDto, Employee>();
        CreateMap<Department, DepartmentDto>();
        CreateMap<Department, DepartmentLookupDto>();


    }
}
