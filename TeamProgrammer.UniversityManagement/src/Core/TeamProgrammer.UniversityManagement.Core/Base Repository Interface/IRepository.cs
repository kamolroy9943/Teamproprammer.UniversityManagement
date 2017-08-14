using System.Collections.Generic;

namespace TeamProgrammer.UniversityManagement.Core.Base_Repository_Interface
{
    public interface IRepository<T> where T:class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        ICollection<T> GetAll();
        T GetById(int id);
    }
}
