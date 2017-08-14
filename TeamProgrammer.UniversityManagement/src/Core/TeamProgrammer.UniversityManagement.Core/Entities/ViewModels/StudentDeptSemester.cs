using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace TeamProgrammer.UniversityManagement.Core.Entities.ViewModels
{
    public class StudentDeptSemester:EntityTypeConfiguration<StudentDeptSemester>
    {
        public StudentDeptSemester()
        {
            this.HasKey(t => t.StudentId);
            this.ToTable("Student_Dept_Semester");
        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Registration { get; set; }
        public string DeptName { get; set; }
        public string SemesterName { get; set; }
    }
}

