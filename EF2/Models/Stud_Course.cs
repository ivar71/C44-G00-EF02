using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    public class Stud_Course
    {
        
        public int stud_ID { get; set; }
        public int Course_ID { get; set; }

        [ForeignKey("stud_ID")]
        [InverseProperty("Stud_Courses")]
        public Student Student { get; set; }

        [ForeignKey("Course_ID")]
        [InverseProperty("Stud_Courses")]
        public Course Course { get; set; }

        [Range(0, 100)]
        public int? Grade { get; set; }
    }
}
