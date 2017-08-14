using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamProgrammer.UniversityManagement.Core.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        
        [Required(ErrorMessage = "Student name is required")]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        public string Registration { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",ErrorMessage = "Please provide a valid email")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Seasson is required")]
        [Display(Name = "Seasson")]
        public int SeassonId { get; set; }

        public virtual Seasson Seasson { get; set; }



        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
 


        [Required(ErrorMessage = "Semester is required")]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; }

       // public virtual ICollection<Course> Courses { get; set; }


         
    }
}

