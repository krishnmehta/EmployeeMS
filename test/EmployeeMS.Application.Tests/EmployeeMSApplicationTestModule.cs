using Volo.Abp.Modularity;

namespace EmployeeMS;

[DependsOn(
    typeof(EmployeeMSApplicationModule),
    typeof(EmployeeMSDomainTestModule)
    )]
public class EmployeeMSApplicationTestModule : AbpModule
{

}
