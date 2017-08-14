using System.Collections.Generic;
using TeamProgrammer.UniversityManagement.Core.Base_Repository_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;

namespace TeamProgrammer.UniversityManagement.Core.Repository_Interface
{
    public interface ICourseRepository:IRepository<Course>
    {
        bool IsCourseCodeEnrolled(string courseCode, int departmentId);
        bool IsCourseCodeExists(string courseCode);
        bool IsCourseNameEnrolled(string courseName, int departmentId);
        bool IsCourseNameExists(string courseName);
    }
}
