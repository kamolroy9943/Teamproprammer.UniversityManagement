using System;
using System.Data.Entity;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;
using TeamProgrammer.UniversityManagement.DataRepository.Base_Repository;
using TeamProgrammer.UniversityManagement.DataRepository.Context;

namespace TeamProgrammer.UniversityManagement.DataRepository.Repository
{
   public class DesignationRepository:Repository<Designation>,IDesignationRepositoty,IDisposable
    {

        public UniversityDbContext Context
        {
            get
            {
                return context as UniversityDbContext;
            }
        }

        public DesignationRepository(DbContext context) : base(context)
        {
            base.context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

