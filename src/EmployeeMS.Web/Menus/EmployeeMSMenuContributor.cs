using System.Threading.Tasks;
using EmployeeMS.Localization;
using EmployeeMS.MultiTenancy;
using EmployeeMS.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace EmployeeMS.Web.Menus;

public class EmployeeMSMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<EmployeeMSResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                EmployeeMSMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
                context.Menu.AddItem(
            new ApplicationMenuItem(
                "EmployeeMS",
                l["Menu:EmployeeMS"],
                icon: "fa fa-book"
            ).AddItem(
                new ApplicationMenuItem(
                    "EmployeeMS.Employees",
                    l["Menu:Employees"],
                    url: "/Employees"
                ).RequirePermissions(EmployeeMSPermissions.Employees.Default) //checking the permission
            ).AddItem(
                new ApplicationMenuItem(
                    "EmployeeMS.Departments",
                    l["Menu:Departments"],
                    url: "/Departments"
                ).RequirePermissions(EmployeeMSPermissions.Employees.Default)
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
