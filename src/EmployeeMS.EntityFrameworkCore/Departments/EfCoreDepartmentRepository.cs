using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using EmployeeMS.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EmployeeMS.Departments;

public class EfCoreDepartmentRepository
    : EfCoreRepository<EmployeeMSDbContext, Department, Guid>,
        IDepartmentRepository
{
    public EfCoreDepartmentRepository(
        IDbContextProvider<EmployeeMSDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<Department> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(department => department.Name == name);
    }

    public async Task<List<Department>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                author => author.Name.Contains(filter)
                )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
