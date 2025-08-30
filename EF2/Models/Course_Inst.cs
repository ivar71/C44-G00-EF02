using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    public class Course_Inst
    {
        public int inst_ID { get; set; }

        public int Course_ID { get; set; }

        [ForeignKey("inst_ID")]
        [InverseProperty("Course_Insts")]
        public Instructor Instructor { get; set; }

        [ForeignKey("Course_ID")]
        [InverseProperty("Course_Insts")]
        public Course Course { get; set; }

        [Range(1, 10)]
        public int? Evaluate { get; set; }
    }
}
