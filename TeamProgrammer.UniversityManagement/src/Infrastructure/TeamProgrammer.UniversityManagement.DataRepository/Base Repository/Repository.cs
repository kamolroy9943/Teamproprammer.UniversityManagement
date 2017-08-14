using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeamProgrammer.UniversityManagement.Core.Base_Repository_Interface;

namespace TeamProgrammer.UniversityManagement.DataRepository.Base_Repository
{
    public class Repository<T> :IRepository<T>where T:class
    {
        protected DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public DbSet<T> Table
        {
            get { return context.Set<T>(); }
        }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return context.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            Table.Attach(entity);
            context.Entry(entity).State=EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            Table.Attach(entity);
            context.Entry(entity).State=EntityState.Deleted;
            return context.SaveChanges() > 0;
        }

        public ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }
    }
}
