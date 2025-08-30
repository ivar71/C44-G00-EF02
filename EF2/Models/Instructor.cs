using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Salary { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [Range(0, double.MaxValue)]
        public decimal HourRateBouns { get; set; } = 0;

        // FK
        public int Dept_ID { get; set; }

        [ForeignKey("Dept_ID")]
        [InverseProperty("Instructors")]
        public Department Department { get; set; }

        // لو هو رئيس قسم
        [InverseProperty("Head")]
        public ICollection<Department> HeadOfDepartments { get; set; }

        [InverseProperty("Instructor")]
        public ICollection<Course_Inst> Course_Insts { get; set; }
    }
}
