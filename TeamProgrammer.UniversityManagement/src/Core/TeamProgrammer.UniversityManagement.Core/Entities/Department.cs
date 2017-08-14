using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamProgrammer.UniversityManagement.Core.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        [Required(ErrorMessage = "Department code is required")]
        [Display(Name = "Department Code")]
        public string DeptCode { get; set; }

        [Required(ErrorMessage = "Credit is required")]
        [Display(Name = "Department Credit")]
        public double DeptCredit { get; set; }

        [Required(ErrorMessage = "Administrator is required")]
        public string Adminstrator { get; set; }

        [Required(ErrorMessage = "Department start date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StratDate { get; set; }

        [Required(ErrorMessage = "Department Building is required")]
        [Display(Name = "Building Name")]
        public string Building { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }


    }
}
