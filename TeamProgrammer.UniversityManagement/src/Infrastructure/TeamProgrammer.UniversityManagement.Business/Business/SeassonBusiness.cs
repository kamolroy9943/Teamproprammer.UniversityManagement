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
    public class SeassonBusiness:ISeassonBusiness
    {
        private readonly ISeassonRepository _seassonRepository;

        public SeassonBusiness(ISeassonRepository seassonRepository)
        {
            _seassonRepository = seassonRepository;
        }
        public bool Add(Seasson entity)
        {
            return _seassonRepository.Add(entity);
        }

        public bool Update(Seasson entity)
        {
            return _seassonRepository.Update(entity);
        }

        public bool Delete(Seasson entity)
        {
            return _seassonRepository.Delete(entity);
        }

        public ICollection<Seasson> GetAll()
        {
            return _seassonRepository.GetAll();
        }

        public Seasson GetById(int id)
        {
            return _seassonRepository.GetById(id);
        }
    }
}
