using AutoMapper;
using EmployeeMS.Departments;
using EmployeeMS.Employees;

namespace EmployeeMS.Web;

public class EmployeeMSWebAutoMapperProfile : Profile
{
    public EmployeeMSWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<EmployeeDto, CreateUpdateEmployeeDto>();

        // ADD a NEW MAPPING
        CreateMap<Pages.Departments.CreateModalModel.CreateDepartmentViewModel,
                    CreateDepartmentDto>();
        CreateMap<DepartmentDto, Pages.Departments.EditModalModel.EditDepartmentViewModel>();
        CreateMap<Pages.Departments.EditModalModel.EditDepartmentViewModel,
                    UpdateDepartmentDto>();
    }
}
