using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamProgrammer.UniversityManagement.Core.Entities
{
    public class Designation
    {
        public int DesignationId { get; set; }

        [Display(Name = "Designation")]
        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

    }
}
