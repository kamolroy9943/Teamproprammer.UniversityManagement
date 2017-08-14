using TeamProgrammer.UniversityManagement.Core.Base_Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;

namespace TeamProgrammer.UniversityManagement.Core.Business_Interface
{
    public interface IStudentBusiness:IBusiness<Student>
    {
        string GetRegistrationNo(int deptId, string seasson);
    }
}
