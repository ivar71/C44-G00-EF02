using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{

    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string FName { get; set; }

        [Required, MaxLength(50)]
        public string LName { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [Range(18, 60)]
        public int Age { get; set; }

        // FK
        public int Dep_Id { get; set; }

        [ForeignKey("Dep_Id")]
        [InverseProperty("Students")]
        public Department Department { get; set; }

        [InverseProperty("Student")]
        public ICollection<Stud_Course> Stud_Courses { get; set; }
    }
}
