using System.Collections.Generic;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;

namespace TeamProgrammer.UniversityManagement.Business.Business
{
    public class CourseBusiness:ICourseBusiness
    {
        private readonly ICourseRepository _repository;
        
        public CourseBusiness(ICourseRepository repository)
        {
            this._repository = repository;
        }
        public bool Add(Course entity)
        {
            return _repository.Add(entity);
        }

        public bool Update(Course entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(Course entity)
        {
            return _repository.Delete(entity);
        }

        public ICollection<Course> GetAll()
        {
            return _repository.GetAll();
        }

        public Course GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool IsCourseNameExists(string courseName)
        {
            return _repository.IsCourseNameExists(courseName);
        }

        public bool IsCourseCodeExists(string courseCode)
        {
            return _repository.IsCourseCodeExists(courseCode);
        }

        public bool IsCourseNameEnrolled(string courseName, int departmentId)
        {
            return _repository.IsCourseNameEnrolled(courseName, departmentId);
        }

        public bool IsCourseCodeEnrolled(string courseCode, int departmentId)
        {
            return _repository.IsCourseCodeEnrolled(courseCode, departmentId);
        }
    }
}
