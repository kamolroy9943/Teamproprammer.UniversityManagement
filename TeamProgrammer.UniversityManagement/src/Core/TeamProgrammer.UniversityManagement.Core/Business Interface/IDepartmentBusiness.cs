using System.Collections.Generic;
using TeamProgrammer.UniversityManagement.Core.Base_Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;

namespace TeamProgrammer.UniversityManagement.Core.Business_Interface
{
    public interface IDepartmentBusiness:IBusiness<Department>
    {
        bool IsDeptCodeExists(string deptCode);
        bool IsDeptNameExists(string deptName);
    }
}
