using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace TeamProgrammer.UniversityManagement.Core.Entities
{
    public class StudentResult
    {
        public int StudentResultId { get; set; }

        [Required(ErrorMessage = "Registration is repuired")]
        [Display(Name = "Registration No")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        
        [Required(ErrorMessage = "Course is required")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        

        [Display(Name = "Class Test Mark")]
        [Range(1, 5)]
        public double ClassTest { get; set; }

        [Display(Name = "Assignment Mark")]
        [Range(1, 5)]
        public double AssignMent { get; set; }
        
        [Display(Name = "Midterm Mark")]
        [Range(1, 10)]
        public double Midterm { get; set; }
        
        [Display(Name = "Subject Exam Mark")]
        [Range(1, 80)]
        public double SubjectMark { get; set; }

        [Display(Name = "Grade Point")]
        [Required(ErrorMessage = "Gpa is required")]
        public double Gpa { get; set; }

    }
}
