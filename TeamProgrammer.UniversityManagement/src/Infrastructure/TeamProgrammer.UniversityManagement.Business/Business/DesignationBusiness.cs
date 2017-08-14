using System.Collections.Generic;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;

namespace TeamProgrammer.UniversityManagement.Business.Business
{
    public class DesignationBusiness:IDesignationBusiness
    {
        private readonly IDesignationRepositoty _repositoty;

        public DesignationBusiness(IDesignationRepositoty repositoty)
        {
            _repositoty = repositoty;
        }
        public bool Add(Designation entity)
        {
            return _repositoty.Add(entity);
        }

        public bool Update(Designation entity)
        {
            return _repositoty.Update(entity);
        }

        public bool Delete(Designation entity)
        {
            return _repositoty.Delete(entity);
        }

        public ICollection<Designation> GetAll()
        {
            return _repositoty.GetAll();
        }

        public Designation GetById(int id)
        {
            return _repositoty.GetById(id);
        }
    }
}
