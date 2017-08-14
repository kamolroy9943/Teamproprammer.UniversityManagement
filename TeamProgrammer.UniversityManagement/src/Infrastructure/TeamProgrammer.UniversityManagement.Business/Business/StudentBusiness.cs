using System.Collections.Generic;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;

namespace TeamProgrammer.UniversityManagement.Business.Business
{
    public class StudentBusiness:IStudentBusiness
    {
        private readonly IStudentRepository _repository;

        public StudentBusiness(IStudentRepository repository)
        {
            this._repository = repository;
        }
        public bool Add(Student entity)
        {
            return _repository.Add(entity);
        }

        public bool Update(Student entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(Student entity)
        {
            return _repository.Delete(entity);
        }

        public ICollection<Student> GetAll()
        {
            return _repository.GetAll();
        }

        public Student GetById(int id)
        {
            return _repository.GetById(id);
        }

        public string GetRegistrationNo(int deptId, string seasson)
        {
            return _repository.GetRegistrationNo(deptId, seasson);
        }
    }
}