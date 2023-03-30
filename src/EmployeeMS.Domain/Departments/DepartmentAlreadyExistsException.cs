using Volo.Abp;

namespace EmployeeMS.Departments;

public class DepartmentAlreadyExistsException : BusinessException
{
    public DepartmentAlreadyExistsException(string name)
        : base(EmployeeMSDomainErrorCodes.DepartmentAlreadyExists)
    {
        WithData("name", name);
    }
}
