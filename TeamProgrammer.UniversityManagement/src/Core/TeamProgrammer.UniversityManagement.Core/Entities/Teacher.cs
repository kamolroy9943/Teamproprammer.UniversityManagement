using System;
using System.ComponentModel.DataAnnotations;

namespace TeamProgrammer.UniversityManagement.Core.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Teacher name is required")]
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",ErrorMessage = "Please provide a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Joining date is required")]
        [Display(Name = "Joining Date")]
        public DateTime JoinDate { get; set; }
        
        [Required(ErrorMessage = "Contact number is required")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Credit number is required")]
        [Display(Name = "CreditToBeTaken")]
        public int CreditToBeTaken { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

        public virtual Designation Designation{ get; set; }

        public virtual Department Department { get; set; }

    }
}