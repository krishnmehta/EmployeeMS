using Volo.Abp.Settings;

namespace EmployeeMS.Settings;

public class EmployeeMSSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EmployeeMSSettings.MySetting1));
    }
}
