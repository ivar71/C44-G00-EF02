using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    internal class Topic
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Name {  get; set; }


    }  


}
