using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProgrammer.UniversityManagement.Core.Entities.ViewModels
{
    public class StudentResultViewModel:EntityTypeConfiguration<StudentResultViewModel>
    {
        public StudentResultViewModel()
        {
            this.HasKey(t => t.StudentId);
            this.ToTable("StudentResultView");
        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Registration { get; set; }
        public string CourseName { get; set; }
        public string CourseCode{ get; set; }
        public double Gpa { get; set; }


    }
}
