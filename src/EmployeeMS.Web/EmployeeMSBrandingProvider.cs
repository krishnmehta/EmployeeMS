using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EmployeeMS.Web;

[Dependency(ReplaceServices = true)]
public class EmployeeMSBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EmployeeMS";
}
