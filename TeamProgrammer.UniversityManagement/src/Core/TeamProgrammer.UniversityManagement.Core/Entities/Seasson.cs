using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProgrammer.UniversityManagement.Core.Entities
{
    public class Seasson
    {
        public int SeassonId { get; set; }
        public string SeassonName { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}
