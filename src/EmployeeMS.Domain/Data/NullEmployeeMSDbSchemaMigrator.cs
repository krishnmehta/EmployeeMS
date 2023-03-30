using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EmployeeMS.Data;

/* This is used if database provider does't define
 * IEmployeeMSDbSchemaMigrator implementation.
 */
public class NullEmployeeMSDbSchemaMigrator : IEmployeeMSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
