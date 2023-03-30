using EmployeeMS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EmployeeMS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EmployeeMSController : AbpControllerBase
{
    protected EmployeeMSController()
    {
        LocalizationResource = typeof(EmployeeMSResource);
    }
}
