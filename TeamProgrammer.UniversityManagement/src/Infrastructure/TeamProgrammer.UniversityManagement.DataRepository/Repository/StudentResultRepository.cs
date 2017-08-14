using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;
using TeamProgrammer.UniversityManagement.DataRepository.Base_Repository;
using TeamProgrammer.UniversityManagement.DataRepository.Context;

namespace TeamProgrammer.UniversityManagement.DataRepository.Repository
{
    public class StudentResultRepository:Repository<StudentResult>,IStudentResultRepository,IDisposable
    {
        public UniversityDbContext Context
        {
            get
            {
                return context as UniversityDbContext;
            }
        }

        public StudentResultRepository(DbContext context) : base(context)
        {
            base.context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public bool IsResultAlreayGiven(int studentId, int courseId)
        {
            bool gpa = Context.StudentResults.Any(x => x.StudentId == studentId && x.CourseId == courseId);      
            if (gpa)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetGpa(double classTest, double assignMent, double midterm, double subjectMark)
        {
            double totalMark = classTest + assignMent + midterm + subjectMark;
            if (totalMark>=80 && totalMark<=100)
            {
                return 4.00;
            }
            else if (totalMark >= 75 && totalMark <= 79)
            {
                return 3.75;
            }
            else if (totalMark >= 70 && totalMark <= 74)
            {
                return 3.50;
            }
            else if (totalMark >= 65 && totalMark <= 69)
            {
                return 3.25;
            }
            else if (totalMark >= 60 && totalMark <= 64)
            {
                return 3.00;
            }
            else if (totalMark >= 55 && totalMark <= 59)
            {
                return 2.75;
            }
            else if (totalMark >= 50 && totalMark <= 54)
            {
                return 2.50;
            }
            else if (totalMark >= 45 && totalMark <= 49)
            {
                return 2.25;
            }

            else if (totalMark >= 40 && totalMark <= 44)
            {
                return 2.00;
            }
            else
            {
                return 0.00;
            }
        }
    }
}
