using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Head of Department
        public int? Ins_ID { get; set; }

        [ForeignKey("Ins_ID")]
        [InverseProperty("HeadOfDepartments")]
        public Instructor Head { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }

        [InverseProperty("Department")]
        public ICollection<Student> Students { get; set; }

        [InverseProperty("Department")]
        public ICollection<Instructor> Instructors { get; set; }
    }

}
