using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;
using TeamProgrammer.UniversityManagement.DataRepository.Base_Repository;
using TeamProgrammer.UniversityManagement.DataRepository.Context;

namespace TeamProgrammer.UniversityManagement.DataRepository.Repository
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository,IDisposable
    {
        public UniversityDbContext Context
        {
            get
            {
                return context as UniversityDbContext;
            }
        }
        public DepartmentRepository(DbContext context) : base(context)
        {
            base.context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public bool IsDeptCodeExists(string deptCode)
        {
            bool isExists = Context.Departments.Any(c => c.DeptCode == deptCode);
            if (isExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsDeptNameExists(string deptName)
        {
            bool isExists = Context.Departments.Any(c => c.DeptName == deptName);
            if (isExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

