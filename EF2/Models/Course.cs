using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Range(1, int.MaxValue)]
        public int Duration { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        // FK
        public int Top_ID { get; set; }

        [ForeignKey("Top_ID")]
        [InverseProperty("Courses")]
        public Topic Topic { get; set; }

        [InverseProperty("Course")]
        public ICollection<Stud_Course> Stud_Courses { get; set; }

        [InverseProperty("Course")]
        public ICollection<Course_Inst> Course_Insts { get; set; }
    }

}
