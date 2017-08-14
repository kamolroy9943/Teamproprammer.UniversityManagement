using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProgrammer.UniversityManagement.Core.Base_Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;

namespace TeamProgrammer.UniversityManagement.Core.Business_Interface
{
    public interface IStudentResultBusiness:IBusiness<StudentResult>
    {
        bool IsResultAlreayGiven(int studentId, int courseId);
        double GetGpa(double classTest, double assignMent, double midterm, double subjectMark);
    }
}
