using EmployeeMS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EmployeeMS;

[DependsOn(
    typeof(EmployeeMSEntityFrameworkCoreTestModule)
    )]
public class EmployeeMSDomainTestModule : AbpModule
{

}
