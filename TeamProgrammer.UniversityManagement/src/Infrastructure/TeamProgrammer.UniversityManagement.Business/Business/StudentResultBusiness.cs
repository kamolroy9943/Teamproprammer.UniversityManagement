using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;

namespace TeamProgrammer.UniversityManagement.Business.Business
{
    public class StudentResultBusiness:IStudentResultBusiness
    {
        private readonly IStudentResultRepository _repository;

        public StudentResultBusiness(IStudentResultRepository repository)
        {
            _repository = repository;
        }

        public bool Add(StudentResult entity)
        {
            return _repository.Add(entity);
        }

        public bool Update(StudentResult entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(StudentResult entity)
        {
            return _repository.Delete(entity);
        }

        public ICollection<StudentResult> GetAll()
        {
            return _repository.GetAll();
        }

        public StudentResult GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool IsResultAlreayGiven(int studentId, int courseId)
        {
            return _repository.IsResultAlreayGiven(studentId, courseId);
        }

        public double GetGpa(double classTest, double assignMent, double midterm, double subjectMark)
        {
            return _repository.GetGpa(classTest, assignMent, midterm, subjectMark);
        }
    }
}
