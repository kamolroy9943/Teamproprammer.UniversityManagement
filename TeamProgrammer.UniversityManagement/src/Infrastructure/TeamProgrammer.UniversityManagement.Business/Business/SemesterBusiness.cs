using System.Collections.Generic;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;

namespace TeamProgrammer.UniversityManagement.Business.Business
{
    public class SemesterBusiness:ISemesterBusiness
    {
        private readonly ISemesterRepository _repository;

        public SemesterBusiness(ISemesterRepository repository)
        {
            _repository = repository;
        }
        public bool Add(Semester entity)
        {
            return _repository.Add(entity);
        }

        public bool Update(Semester entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(Semester entity)
        {
            return _repository.Delete(entity);
        }

        public ICollection<Semester> GetAll()
        {
            return _repository.GetAll();
        }

        public Semester GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
