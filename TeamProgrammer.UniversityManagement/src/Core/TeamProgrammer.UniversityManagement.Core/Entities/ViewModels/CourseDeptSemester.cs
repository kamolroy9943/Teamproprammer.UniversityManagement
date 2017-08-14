using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProgrammer.UniversityManagement.Core.Entities.ViewModels
{
    public class CourseDeptSemester : EntityTypeConfiguration<CourseDeptSemester>
    {
        public CourseDeptSemester()
        {
            this.HasKey(t => t.CourseId);
            this.ToTable("Course_Dept_Semester");
        }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string DeptName { get; set; }
        public string SemesterName { get; set; }
        public string CourseCode { get; set; }
        public double Credit { get; set; }
        public string Discription { get; set; }
    }
}
