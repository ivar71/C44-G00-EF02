using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    internal class Instructor
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Salary { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [Range(0, double.MaxValue)]
        public decimal HourRateBouns { get; set; } = 0;

    }
}
