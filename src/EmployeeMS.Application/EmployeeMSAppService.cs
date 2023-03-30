using System;
using System.Collections.Generic;
using System.Text;
using EmployeeMS.Localization;
using Volo.Abp.Application.Services;

namespace EmployeeMS;

/* Inherit your application services from this class.
 */
public abstract class EmployeeMSAppService : ApplicationService
{
    protected EmployeeMSAppService()
    {
        LocalizationResource = typeof(EmployeeMSResource);
    }
}
