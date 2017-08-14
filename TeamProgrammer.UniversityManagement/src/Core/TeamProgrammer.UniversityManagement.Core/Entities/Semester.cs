using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamProgrammer.UniversityManagement.Core.Entities
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        [Display(Name = "Semester")]
        public string SemesterName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
