using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    internal class Student
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column("FName",TypeName = "NVARCHAR")]
        [MaxLength(50)]
        public string FName { get; set; }

        [Required, StringLength(50)]
        public string LName { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [Range(18, 60)]
        public int Age { get; set; }
    }
}
