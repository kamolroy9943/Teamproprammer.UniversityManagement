using System.Collections.Generic;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;

namespace TeamProgrammer.UniversityManagement.Business.Business
{
    public class TeacherBusiness:ITeacherBusiness
    {
        private readonly ITeacherRepository _repository;

        public TeacherBusiness(ITeacherRepository repository)
        {
            this._repository = repository;
        }
        public bool Add(Teacher entity)
        {
            return _repository.Add(entity);
        }

        public bool Update(Teacher entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(Teacher entity)
        {
            return _repository.Delete(entity);
        }

        public ICollection<Teacher> GetAll()
        {
            return _repository.GetAll();
        }

        public Teacher GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
