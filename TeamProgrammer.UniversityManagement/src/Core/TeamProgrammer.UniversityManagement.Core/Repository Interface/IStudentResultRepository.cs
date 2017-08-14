using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProgrammer.UniversityManagement.Core.Base_Repository_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;

namespace TeamProgrammer.UniversityManagement.Core.Repository_Interface
{
    public interface IStudentResultRepository:IRepository<StudentResult>
    {
        bool IsResultAlreayGiven(int studentId, int courseId);
        double GetGpa(double classTest, double assignMent, double midterm, double subjectMark);
    }
}
