using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeamProgrammer.UniversityManagement.Core.Base_Repository_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;
using TeamProgrammer.UniversityManagement.DataRepository.Base_Repository;
using TeamProgrammer.UniversityManagement.DataRepository.Context;

namespace TeamProgrammer.UniversityManagement.DataRepository.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository, IDisposable
    {

        public UniversityDbContext Context
        {
            get
            {
                return context as UniversityDbContext;
            }
        }
        public CourseRepository(DbContext context) : base(context)
        {
            base.context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public bool IsCourseCodeEnrolled(string courseCode, int departmentId)
        {
            int courseId = Context.Courses.Where(x => x.DepartmentId == departmentId && x.CourseCode == courseCode)
                    .Select(x => x.CourseId).FirstOrDefault();
            if (courseId > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool IsCourseNameEnrolled(string courseName, int departmentId)
        {
            int courseId = Context.Courses.Where(x => x.DepartmentId == departmentId && x.CourseName == courseName)
                   .Select(x => x.CourseId).FirstOrDefault();
            if (courseId > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsCourseCodeExists(string courseCode)
        {
            bool isExists = Context.Courses.Any(x => x.CourseCode == courseCode);
            if (isExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public bool IsCourseNameExists(string courseName)
        {
            bool isExists = Context.Courses.Any(x => x.CourseName == courseName);
            if (isExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

