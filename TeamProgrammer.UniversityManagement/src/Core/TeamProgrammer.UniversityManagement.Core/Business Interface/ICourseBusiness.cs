using TeamProgrammer.UniversityManagement.Core.Base_Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;

namespace TeamProgrammer.UniversityManagement.Core.Business_Interface
{
    public interface ICourseBusiness:IBusiness<Course>
    {
        bool IsCourseNameExists(string courseName);
        bool IsCourseCodeExists(string courseCode);
        bool IsCourseNameEnrolled(string courseName, int departmentId);
        bool IsCourseCodeEnrolled(string courseCode, int departmentId);
    }
}
