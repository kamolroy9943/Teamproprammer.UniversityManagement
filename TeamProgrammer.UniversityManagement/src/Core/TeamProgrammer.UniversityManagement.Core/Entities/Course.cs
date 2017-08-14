using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;

namespace TeamProgrammer.UniversityManagement.Core.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        
        [Required(ErrorMessage = "Course name is required")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course code is required")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Credit is required")]
        [Display(Name = "Credit")]
        public double Credit { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        
        [Required(ErrorMessage = "Semester is required")]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        //public virtual ICollection<Student> Students { get; set; }

         

    }
}
