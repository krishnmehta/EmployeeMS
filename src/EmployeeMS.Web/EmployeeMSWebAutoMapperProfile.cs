﻿using AutoMapper;
using EmployeeMS.Employees;

namespace EmployeeMS.Web;

public class EmployeeMSWebAutoMapperProfile : Profile
{
    public EmployeeMSWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<EmployeeDto, CreateUpdateEmployeeDto>();
    }
}
