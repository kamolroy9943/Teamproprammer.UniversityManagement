using System.Collections.Generic;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;

namespace TeamProgrammer.UniversityManagement.Business.Business
{
    public class DepartmentBusiness:IDepartmentBusiness
    {
        private readonly IDepartmentRepository _repository;
        
        public DepartmentBusiness(IDepartmentRepository repository)
        {
            this._repository = repository;
        }

        public bool Add(Department entity)
        {
            return _repository.Add(entity);
        }

        public bool Update(Department entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(Department entity)
        {
            return _repository.Delete(entity);
        }

        public ICollection<Department> GetAll()
        {
            return _repository.GetAll();
        }

        public Department GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool IsDeptCodeExists(string deptCode)
        {
            return _repository.IsDeptCodeExists(deptCode);
        }

        public bool IsDeptNameExists(string deptName)
        {
            return _repository.IsDeptNameExists(deptName);
        }
    }
}
