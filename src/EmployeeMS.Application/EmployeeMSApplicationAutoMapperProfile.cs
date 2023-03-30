using AutoMapper;
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
        CreateMap<Employee, CreateUpdateEmployeeDto>();
    }
}
