using TeamProgrammer.UniversityManagement.Core.Base_Repository_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;

namespace TeamProgrammer.UniversityManagement.Core.Repository_Interface
{
    public interface IStudentRepository:IRepository<Student>
    {
        string GetRegistrationNo(int deptId, string seasson);
    }
}
