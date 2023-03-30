using EmployeeMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EmployeeMS.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EmployeeMSPageModel : AbpPageModel
{
    protected EmployeeMSPageModel()
    {
        LocalizationResourceType = typeof(EmployeeMSResource);
    }
}
