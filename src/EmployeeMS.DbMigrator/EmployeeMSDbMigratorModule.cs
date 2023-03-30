using EmployeeMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EmployeeMS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EmployeeMSEntityFrameworkCoreModule),
    typeof(EmployeeMSApplicationContractsModule)
    )]
public class EmployeeMSDbMigratorModule : AbpModule
{

}
