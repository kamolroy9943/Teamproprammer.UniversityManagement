using System;
using System.Data.Entity;
using System.Linq;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;
using TeamProgrammer.UniversityManagement.DataRepository.Base_Repository;
using TeamProgrammer.UniversityManagement.DataRepository.Context;

namespace TeamProgrammer.UniversityManagement.DataRepository.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository, IDisposable
    {
        public UniversityDbContext Context
        {
            get { return context as UniversityDbContext; }
        }


        public StudentRepository(DbContext context) : base(context)
        {
            base.context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public string GetRegistrationNo(int deptId, string seasson)
        {
            string regNo = "";
            string deptCode = Context.Departments.Where(x => x.DepartmentId == deptId)
                .Select(x => x.DeptCode).FirstOrDefault();

            int toralstudent = Context.Students.Count(x => x.DepartmentId == deptId) + 1;

            regNo = deptCode + "-" + seasson + "-" + toralstudent;
            return regNo;
        }
    }
}

