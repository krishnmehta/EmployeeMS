using EmployeeMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EmployeeMS.Permissions;

public class EmployeeMSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var employeeMSGroup = context.AddGroup(EmployeeMSPermissions.GroupName, L("Permission:EmployeeMS"));

        var employeesPermission = employeeMSGroup.AddPermission(EmployeeMSPermissions.Employees.Default, L("Permission:Employees"));
        employeesPermission.AddChild(EmployeeMSPermissions.Employees.Create, L("Permission:Employees.Create"));
        employeesPermission.AddChild(EmployeeMSPermissions.Employees.Edit, L("Permission:Employees.Edit"));
        employeesPermission.AddChild(EmployeeMSPermissions.Employees.Delete, L("Permission:Employees.Delete"));

        var departmentsPermission = employeeMSGroup.AddPermission(EmployeeMSPermissions.Departments.Default, L("Permission:Departments"));
        departmentsPermission.AddChild(EmployeeMSPermissions.Departments.Create, L("Permission:Departments.Create"));
        departmentsPermission.AddChild(EmployeeMSPermissions.Departments.Edit, L("Permission:Departments.Edit"));
        departmentsPermission.AddChild(EmployeeMSPermissions.Departments.Delete, L("Permission:Departments.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EmployeeMSResource>(name);
    }
}
