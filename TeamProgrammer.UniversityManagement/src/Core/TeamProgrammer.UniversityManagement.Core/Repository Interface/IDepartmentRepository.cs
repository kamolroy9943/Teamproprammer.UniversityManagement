using System.Collections.Generic;
using TeamProgrammer.UniversityManagement.Core.Base_Repository_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;

namespace TeamProgrammer.UniversityManagement.Core.Repository_Interface
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        bool IsDeptCodeExists(string deptCode);
        bool IsDeptNameExists(string deptName);
       
    }
}
