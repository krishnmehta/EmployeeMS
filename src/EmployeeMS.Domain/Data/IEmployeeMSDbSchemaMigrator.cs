using System.Threading.Tasks;

namespace EmployeeMS.Data;

public interface IEmployeeMSDbSchemaMigrator
{
    Task MigrateAsync();
}
