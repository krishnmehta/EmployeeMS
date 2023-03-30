using EmployeeMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EmployeeMS.Permissions;

public class EmployeeMSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EmployeeMSPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(EmployeeMSPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EmployeeMSResource>(name);
    }
}
