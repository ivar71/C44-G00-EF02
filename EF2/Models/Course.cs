using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    internal class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

    }
}
